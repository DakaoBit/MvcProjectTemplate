using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectTemplate.Controllers
{
          public class BaseController : Controller
          {
                    /// <summary>
                    /// 辨識使用者從瀏覽器按下 F5 或 Ctrl + R 重新整理頁面
                    /// </summary>
                    public bool IsRefresh
                    {
                              get
                              {
                                        return this.Request.Headers ["Pragma"] == "no-cache" ||
                                               this.Request.Headers ["Cache-Control"] == "max-age=0";
                              }
                    }
          }
}