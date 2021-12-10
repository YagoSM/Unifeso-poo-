

namespace UnifesoPoo.Pedido.Api.Controllers.Middlewares
{
public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpServiceCollectionExtensions context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch(Exception exception)
            {
                var statusCode = exception switch
                {
                    NotFoundException => (int) HttpStatusCode.NotFound,
                   _ => (int) HttpStatusCode.InternalServerError
                       
                };
                var content = JsonConvert.SerializeObject(new ResponseDto(exception));
                      
                context.Response.StatusCode = statusCode;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.WriteAsJsonAsync(new ResponseDto(excepetion));
            }
        }
    }
}