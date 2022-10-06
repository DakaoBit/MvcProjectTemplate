using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectTemplate.Models
{
          /// <summary>
          /// 書籍分類
          /// </summary>
          public class Category
          {
                    /// <summary>
                    /// PK
                    /// </summary>
                    public int Id { get; set; }
                    /// <summary>
                    /// Name
                    /// </summary>
                    public string Name { get; set; }
                    /// <summary>
                    /// 分類排序
                    /// </summary>
                    public int DisplayOrder { get; set; }
                    public DateTime CreateTime { get; set; }
                    public DateTime UpdateTime { get; set; }
                    /// <summary>
                    /// Create User Id
                    /// </summary>
                    public int CreateUser { get; set; }
                    /// <summary>
                    /// Update User Id
                    /// </summary>
                    public int UpdateUser { get; set; }
          }
}