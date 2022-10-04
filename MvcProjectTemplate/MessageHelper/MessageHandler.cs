using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MessageHelper
{
          public abstract class MessageHandler : DelegatingHandler
          {
                    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
                    {
                              var corrId = string.Format("{0}{1}", DateTime.Now.Ticks, Thread.CurrentThread.ManagedThreadId);
                              var requestInfo = string.Format("{0} {1}", request.Method, request.RequestUri);

                              await Request(corrId, requestInfo, request);

                              var response = await base.SendAsync(request, cancellationToken);

                              await Response(corrId, requestInfo, response);

                              return response;
                    }


                    protected abstract Task Request(string correlationId, string requestInfo, HttpRequestMessage message);
                    protected abstract Task Response(string correlationId, string requestInfo, HttpResponseMessage message);
          }
}