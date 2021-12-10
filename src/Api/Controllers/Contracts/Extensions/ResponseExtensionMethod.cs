using System.Net;
using Microsoft.AspNetCore.Mvc;
using unifesopoo.Api.Controllers.Contracts;


namespace unifesopoo.Api.Controllers.Extensions

{
    public static class ResponseExtensionMethod
    {
        public static IActionResult AsResponse(this object data, HttpStatusCode statusCode)
        {
            return new ObjectResult(new ResponseDto(data))
            {
                StatusCode = (int) statusCode
            };
        }
    }
}