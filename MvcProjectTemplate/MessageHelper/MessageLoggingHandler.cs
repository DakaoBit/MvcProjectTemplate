using log4net;
using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace MessageHelper
{
          public class MessageLoggingHandler : MessageHandler
          {
                    static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

                    protected override async Task Request(string correlationId, string requestInfo, HttpRequestMessage message)
                    {
                              var parameter = message.Content != null ? Encoding.UTF8.GetString(await message.Content.ReadAsByteArrayAsync()) : null;
                              var log = $@"{correlationId} Request: {requestInfo} Parameter: {parameter} ";
                              await Task.Run(() => _log.Debug(log));
                    }

                    protected override async Task Response(string correlationId, string requestInfo, HttpResponseMessage message)
                    {
                              var status = message.StatusCode;
                              var content = message.Content != null ? Encoding.UTF8.GetString(await message.Content.ReadAsByteArrayAsync()) : null;
                              var log = $@"{correlationId} Response: {requestInfo} StatusCode: {(int)status} {status} Content: {content} ";

                              if((int)status < 400)
                                        await Task.Run(() => _log.Debug(log));
                              else
                                        await Task.Run(() => _log.Error(log));
                    }
          }
}