using Books.BusinessService.IBusinessService;
using Books.Common.DTO;
using BooksApi.Authentication;
using BooksApi.Service;
using BooksApi.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        private IJwtTokenService _jwtTokenService;

        public TokenController(IConfiguration config, IJwtTokenService jwtTokenService)
        {
            _config = config;
            _jwtTokenService = jwtTokenService;
        }
       
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _jwtTokenService.AuthenticateAsync(request));
        }
    }
}

