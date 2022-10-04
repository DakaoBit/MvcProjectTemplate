using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Util.Helpers
{
          public static class UtilsHelper
          {
                    #region extensions
                    /// <summary>
                    /// 檢查目前之頁面的Routes
                    /// </summary>
                    /// <param name="helper"></param>
                    /// <param name="controllerName"></param>
                    /// <param name="actionName"></param>
                    /// <returns></returns>
                    public static bool IsCurrentPage(this HtmlHelper helper, string controllerName, string actionName)
                    {
                              var currentControllerName = (string)helper.ViewContext.RouteData.Values ["controller"];
                              var currentActionName = (string)helper.ViewContext.RouteData.Values ["action"];

                              if(currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase)
                                  && currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                              {
                                        return true;
                              }
                              return false;
                    }

                    /// <summary>
                    ///  Url Link
                    /// </summary>
                    /// <param name="helper"></param>
                    /// <param name="httpRequest"></param>
                    /// <param name="Action"></param>
                    /// <param name="Controller"></param>
                    /// <param name="routeValues"></param>
                    /// <returns></returns>
                    // <a href="@Html.UrlLink(HttpContext.Current.Request,"Index","Home",new {area="", id= item.PK} )"><span>閱讀更多</span></a>
                    public static string UrlLink(this HtmlHelper helper, HttpRequest httpRequest, string Action, string Controller, object routeValues)
                    {
                              var requestContext = httpRequest.RequestContext;
                              return new UrlHelper(requestContext).Action(Action, Controller, routeValues);
                    }

                    /// <summary>
                    /// Tag Builder - HightLightText
                    /// </summary>
                    /// <param name="helper"></param>
                    /// <param name="text"></param>
                    /// <returns></returns>
                    public static MvcHtmlString HightLightText(this HtmlHelper helper, string text)
                    {
                              List<TagBuilder> builderList = new List<TagBuilder>();
                              string strOutput = "";

                              string [] strArray = text.Split(';');
                              string desc = strArray.First();
                              strArray = strArray.Skip(1).ToArray();

                              foreach(var item in strArray)
                              {
                                        var builder = new TagBuilder("a");
                                        builder = new TagBuilder("a");
                                        builder.InnerHtml = item;
                                        builderList.Add(builder);
                              }

                              foreach(var item in builderList)
                              {
                                        strOutput += item + " ; ";

                              }
                              return MvcHtmlString.Create(desc + "<br/>" + strOutput);
                    }

                    #endregion

                    #region helpers
                    /// <summary>
                    /// Absolute url
                    /// </summary>
                    /// <param name="url"></param>
                    /// <param name="actionName"></param>
                    /// <param name="controllerName"></param>
                    /// <param name="routeValues"></param>
                    /// <returns></returns>
                    public static string AbsoluteAction(string actionName,
                           string controllerName, object routeValues)
                    {
                              UrlHelper url = new UrlHelper();

                              string scheme = url.RequestContext.HttpContext.Request.Url.Scheme;

                              return url.Action(actionName, controllerName, routeValues, scheme);
                    }

                    /// <summary>
                    /// Generate Fake Img
                    /// </summary>
                    /// <param name="width"></param>
                    /// <param name="height"></param>
                    /// <param name="text"></param>
                    /// <returns></returns>
                    public static string GetFakeImg(string width, string height, string text)
                    {
                              return  $"https://fakeimg.pl/{width}x{height}/?retina=1&text={text}&font=noto";
                    }

                    /// <summary>
                    /// 確認檔案是否存在
                    /// </summary>
                    /// <param name="remoteUrl"></param>
                    /// <returns></returns>
                    public static bool RemoteFileExists(string remoteUrl)
                    {
                              try
                              {
                                        //Creating the HttpWebRequest
                                        HttpWebRequest request = WebRequest.Create(remoteUrl) as HttpWebRequest;

                                        //Setting the Request method HEAD, you can also use GET too.
                                        request.Method = "HEAD";

                                        //Getting the Web Response.
                                        HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                                        //Returns TRUE if the Status code == 200
                                        return (response.StatusCode == HttpStatusCode.OK);
                              }
                              catch(Exception)
                              {
                                        //Any exception will return false.
                                        return false;
                              }
                    }
                    #endregion              
          }
}