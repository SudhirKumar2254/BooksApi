using Books.BusinessService.IBusinessService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class BooksController : BaseApiController
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService bookService)
        {
            this._booksService = bookService;
        }

        /// <summary>
        /// This is to get list of all books of v2
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


    }
}
