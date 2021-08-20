using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
       
    }
}
