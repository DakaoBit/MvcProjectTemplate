using MvcProjectTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Util.DB;
using Dapper;
using System.Threading.Tasks;

namespace MvcProjectTemplate.Services
{
          /// <summary>
          /// BookService 此服務為簡易CRUD範例，說明以靜態方式呼叫DBService的方式
          /// </summary>
          public class BookService
          {
                    private DBService _dbService;

                    public BookService()
                    {
                              _dbService = new DBService();
                    }

                    /// <summary>
                    /// Get an book
                    /// </summary>
                    /// <param name="id"></param>
                    /// <returns></returns>
                    public Book GetBook(int id)
                    {
                              string sql = @"SELECT b.Id * FROM Book b WHERE b.Id = @Id";
                              DynamicParameters dynamics = new DynamicParameters();
                              dynamics.Add("Id", id);

                              var obj = _dbService.MysqlQueryFirstOrDefault<Book>(sql, dynamics);
                              return obj;
                    }

                    /// <summary>
                    /// Get an book - async
                    /// </summary>
                    /// <param name="id"></param>
                    /// <returns></returns>
                    public async Task<Book> GetBookAsync(int id)
                    {
                              string sql = @"SELECT * FROM Book b WHERE b.Id = @Id";
                              DynamicParameters dynamics = new DynamicParameters();
                              dynamics.Add("Id", id);

                              var obj = await _dbService.MysqlQueryFirstOrDefaultAsync<Book>(sql, dynamics);
                              return obj;
                    }

                    /// <summary>
                    /// Get all books
                    /// </summary>
                    /// <returns></returns>
                    public IEnumerable<Book> GetBooks()
                    {
                              string sql = @"SELECT * FROM Book";
                              DynamicParameters dynamics = new DynamicParameters();

                              var obj = _dbService.MysqlQuery<Book>(sql, dynamics);
                              return obj;
                    }

                    /// <summary>
                    /// Get all book - async
                    /// </summary>
                    /// <returns></returns>
                    public async Task<IEnumerable<Book>> GetBooksAsync()
                    {
                              string sql = @"SELECT * FROM Book";
                              DynamicParameters dynamics = new DynamicParameters();

                              var obj = await _dbService.MysqlQueryAsync<Book>(sql, dynamics);
                              return obj;
                    }

                    /// <summary>
                    /// Add an book
                    /// </summary>
                    /// <param name="book"></param>
                    /// <returns></returns>
                    public async Task<bool> AddBookAsync(Book book)
                    {
                              string sql = @" INSERT INTO Book (CategoryId, ISBN, Author, Title, Description, CreateTime, CreateUser) 
                                       VALUES(@CategoryId, @ISBN, @Author, @Title, @Description, @CreateTime, @CreateUser); ";
                              DynamicParameters parameters = new DynamicParameters();
                              parameters.Add("CategoryId", book.CategoryId);
                              parameters.Add("ISBN", book.ISBN);
                              parameters.Add("Author", book.Author);
                              parameters.Add("Title", book.Title);
                              parameters.Add("Description", book.Description);
                              parameters.Add("CreateTime", DateTime.Now);
                              parameters.Add("CreateUser", book.CreateUser);
                              return await _dbService.MysqlExecuteAsync(sql, parameters);
                    }

                    /// <summary>
                    /// Update an Book
                    /// </summary>
                    /// <param name="book"></param>
                    /// <returns></returns>
                    public async Task<bool> UpdateBookAsync(Book book)
                    {
                              string sql = $@" UPDATE  Book SET CategoryId = @CategoryId,  
                                                            ISBN = @ISBN,  Author = @Author,Title = @Title, 
                                                            Description = @Description,  UpdateTime = @UpdateTime,UpdateUser = @UpdateUser 
                                                            WHERE Id = @Id ;";
                              DynamicParameters parameters = new DynamicParameters();
                              parameters.Add("CategoryId", book.CategoryId);
                              parameters.Add("ISBN", book.ISBN);
                              parameters.Add("Author", book.Author);
                              parameters.Add("Title", book.Title);
                              parameters.Add("Description", book.Description);
                              parameters.Add("UpdateTime", DateTime.Now);
                              parameters.Add("UpdateUser", book.UpdateUser);
                              parameters.Add("Id", book.Id);
                              return await _dbService.MysqlExecuteAsync(sql, parameters);
                    }

                    /// <summary>
                    /// Delete an book
                    /// </summary>
                    /// <param name="id"></param>
                    /// <returns></returns>
                    public async Task<bool> DeleteBookAsync(int id)
                    {
                              string sql = @"DELETE From Book WHERE Id = @Id";
                                        
                              DynamicParameters parameters = new DynamicParameters();
                              parameters.Add("Id", id);
                              return await _dbService.MysqlExecuteAsync(sql, parameters);
                    }
          }
}