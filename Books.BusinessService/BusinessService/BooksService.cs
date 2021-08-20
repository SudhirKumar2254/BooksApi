using AutoMapper;
using Books.BusinessService.IBusinessService;
using Books.Common.DTO;
using Books.DataAccess.Entities;
using Books.DataAccess.Repositories.IRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.BusinessService
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;
        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        public async Task<List<BooksDTO>> GetAllBooks()
        {
            return _mapper.Map<List<BooksDTO>>(await _booksRepository.GetList());
        }
        public async Task<BooksDTO> AddBook(BooksDTO addBook)
        {
            return _mapper.Map<BooksDTO>(await _booksRepository.Add(_mapper.Map<Book>(addBook)));
        }
    }
}
