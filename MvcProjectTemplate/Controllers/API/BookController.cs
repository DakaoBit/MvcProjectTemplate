using MvcProjectTemplate.Models;
using MvcProjectTemplate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace MvcProjectTemplate.Controllers
{
          /// <summary>
          /// API Demo: Book Basic CRUD
          /// </summary>
          public class BookController : ApiController
          {
                    private BookService _bookService;

                    public BookController()
                    {
                              _bookService = new BookService();
                    }

                    #region CRUD Example
                    /// <summary>
                    /// GetAllBook
                    /// </summary>
                    /// <returns></returns>
                    [Route("api/Book/Get")]
                    public async Task<IEnumerable<Book>> GetAllBook()
                    {
                              var obj = await _bookService.GetBooksAsync();

                              return obj.AsEnumerable();
                    }

                    /// <summary>
                    /// Get an Book
                    /// </summary>
                    /// <param name="id"></param>
                    /// <returns></returns>
                    [Route("api/Book/Get/{id}")]
                    public async Task<Book> GetBook(int id)
                    {
                              var obj = await _bookService.GetBookAsync(id);

                              return obj;
                    }

                    /// <summary>
                    /// Create/Update Book
                    /// </summary>
                    /// <param name="book"></param>
                    /// <returns></returns>
                    [Route("api/Book/Post")]
                    public async Task<bool> UpsertBook(Book book)
                    {
                              bool result;

                              if(book.Id == 0)
                                        result = await _bookService.AddBookAsync(book);
                              else
                                        result = await _bookService.UpdateBookAsync(book);
 
                              return result;
                    }

                    /// <summary>
                    /// Delete an Book
                    /// </summary>
                    /// <param name="book"></param>
                    /// <returns></returns>
                    [Route("api/Book/Delete/{id}")]
                    public async Task<bool> DeleteBook(int id)
                    {
                             var result = await _bookService.DeleteBookAsync(id);
                              return result;
                    }
 
                    #endregion

                    #region Default

                    // GET: api/Values
                    [Route("api/Values")]
                    public IEnumerable<string> Get()
                    {
                              return new string [] { "value1", "value2" };
                    }


                    // GET: api/Values/5
                    [Route("api/Values/id/{id}")]
                    public string Get(int id)
                    {
                              return "value";
                    }

                    // POST: api/Values
                    public void Post([FromBody] string value)
                    {
                    }

                    // PUT: api/Values/5
                    public void Put(int id, [FromBody] string value)
                    {
                    }

                    // DELETE: api/Values/5
                    public void Delete(int id)
                    {
                    }
                    #endregion
          }
}
