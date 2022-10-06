using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjectTemplate.Models
{
          /// <summary>
          /// 書
          /// </summary>
          public class Book
          {
                    /// <summary>
                    /// PK
                    /// </summary>
                    public int Id { get; set; }
                    /// <summary>
                    /// [FK] CategoryId
                    /// </summary>
                    public int CategoryId { get; set; }
                    /// <summary>
                    /// ISBN
                    /// </summary>
                    public String ISBN { get; set; }
                    /// <summary>
                    /// Author
                    /// </summary>
                    public string Author { get; set; }
                    /// <summary>
                    /// Title
                    /// </summary>
                    public string Title { get; set; }
                    /// <summary>
                    /// Description
                    /// </summary>
                    public string Description { get; set; }
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