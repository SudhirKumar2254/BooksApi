using BooksApi.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Service.Interface
{
    public interface IJwtTokenService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request);


    }
}
