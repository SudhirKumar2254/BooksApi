using Books.BusinessService.IBusinessService;
using Books.Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers.v1
{
    [ApiVersion("1.0")]    
    public class BooksController : BaseApiController
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService bookService)
        {
            this._booksService = bookService;
        }

        /// <summary>
        /// This is to get list of all books
        /// </summary>        
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                return Ok(await _booksService.GetAllBooks());
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }

        /// <summary>
        /// This method is to add a new book
        /// </summary>
        /// <param name="addBook"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> AddBook(BooksDTO addBook)
        {
            try
            {
                return Ok(await _booksService.AddBook(addBook));
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
