using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameWebApi
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _request;
        public ErrorHandlingMiddleware(RequestDelegate request)
        {
            _request = request;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch (NotFoundException e)
            {
                Console.Writeline("Invalid Argument: " + e.Message);
                context.Response.StatusCode = 404;
            }
        }
    }
}