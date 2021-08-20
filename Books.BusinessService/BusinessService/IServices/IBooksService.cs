using Books.Common.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.BusinessService.IBusinessService
{
    public interface IBooksService
    {
        Task<List<BooksDTO>> GetAllBooks();

        Task<BooksDTO> AddBook(BooksDTO addBook);
    }
}
