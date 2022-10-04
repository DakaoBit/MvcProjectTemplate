using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace  Util.Config
{
          public class ConfigService
          {
                    #region DBConnectionString
                    public string GetDBConString() {
                              var ConString = ConfigurationManager.ConnectionStrings ["DefaultConnection"].ToString();

                              return ConString;
                    }
                    #endregion

                    #region API
                    public string GetAPIString() {
                              var apiUrl = ConfigurationManager.AppSettings ["API"];
                              
                              return apiUrl;
                    }
                    #endregion

          }
}