using System.Diagnostics;

namespace MyMiddleware.Middlewares
{
    public class LogginMiddleware
    {
        private readonly RequestDelegate _next;
        public LogginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;

            string requestInfo = "Scheme: " + request.Scheme +
            "\t Host: " + request.Host +
            "\t Path: " + request.Path +
            "\t QueryString: " + request.QueryString +
            "\t RequestBody: " + request.Body;

            Debug.Write(requestInfo);
            File.WriteAllText("textInfomation.txt", requestInfo);

            await _next(context);
        }
    }
}