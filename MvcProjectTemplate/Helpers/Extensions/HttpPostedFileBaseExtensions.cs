﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Util.Helpers.Extensions
{
          public static class HttpPostedFileBaseExtensions
          {
                    public const int ImageMaxBytes = 10000000;// 10 MB

                    /// <summary>
                    /// Check this is an Image, default 10 MB max limit
                    /// </summary>
                    /// <param name="postedFile"></param>
                    /// <returns></returns>
                    public static bool IsImage(this HttpPostedFileBase postedFile)
                    {
                              //-------------------------------------------
                              //  Check the image mime types
                              //-------------------------------------------
                              if(postedFile.ContentType.ToLower() != "image/jpg" &&
                                          postedFile.ContentType.ToLower() != "image/jpeg" &&
                                          postedFile.ContentType.ToLower() != "image/pjpeg" &&
                                          postedFile.ContentType.ToLower() != "image/gif" &&
                                          postedFile.ContentType.ToLower() != "image/x-png" &&
                                          postedFile.ContentType.ToLower() != "image/png")
                              {
                                        return false;
                              }

                              //-------------------------------------------
                              //  Check the image extension
                              //-------------------------------------------
                              if(Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                                  && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                                  && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                                  && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
                              {
                                        return false;
                              }

                              //-------------------------------------------
                              //  Attempt to read the file and check the first bytes
                              //-------------------------------------------
                              try
                              {
                                        //------------------------------------------
                                        //check whether the image size exceeding the limit or not
                                        //------------------------------------------ 
                                        if(postedFile.ContentLength > ImageMaxBytes)
                                        {
                                                  return false;
                                        }

                                        byte [] buffer = new byte [ImageMaxBytes];
                                        postedFile.InputStream.Read(buffer, 0, ImageMaxBytes);
                                        string content = System.Text.Encoding.UTF8.GetString(buffer);
                                        if(Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                                            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                                        {
                                                  return false;
                                        }

                              }
                              catch(Exception)
                              {
                                        return false;
                              }

                              return true;
                    }
          }
}