using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Util.Helpers
{
          /// <summary>
          /// Auto update JS & CSS version
          /// </summary>
          public static class AssetVersionHelper
          {
                    /// <summary>
                    /// Auto update JS version
                    /// </summary>
                    /// <param name="html"></param>
                    /// <param name="src"></param>
                    /// <returns></returns>
                    public static MvcHtmlString Script(this HtmlHelper html, string src)
                    => MvcHtmlString.Create($@"<script src=""{GetPathWithHash(src)}""></script>");

                    /// <summary>
                    /// Auto update CSS version
                    /// </summary>
                    /// <param name="html"></param>
                    /// <param name="href"></param>
                    /// <returns></returns>
                    public static MvcHtmlString Css(this HtmlHelper html, string href)
                        => MvcHtmlString.Create($@"<link href=""{GetPathWithHash(href)}"" rel=""stylesheet"" />");

                    public static string GetPathWithHash(string path)
                        => $"{VirtualPathUtility.ToAbsolute(path)}?v={GetFileHash(path)}";

                    static MemoryCache cache = MemoryCache.Default;
                    public static string GetFileHash(string path)
                    {
                              var physicalPath = HostingEnvironment.MapPath(path);
                              if(!File.Exists(physicalPath)) return string.Empty;
                              string cacheKey = $"__asset_hash__{path}";
                              if(cache.Contains(cacheKey)) return cache [cacheKey] as string;
                              using(SHA256 sha256 = SHA256.Create())
                              {
                                        var hash = HttpServerUtility.UrlTokenEncode(
                                            sha256.ComputeHash(File.ReadAllBytes(physicalPath)));
                                        var policy = new CacheItemPolicy();
                                        policy.ChangeMonitors.Add(new HostFileChangeMonitor(new string [] { physicalPath }));
                                        cache.Add(cacheKey, hash, policy);
                                        return hash;
                              }
                    }
          }
}