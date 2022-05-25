namespace CreateCustomIResult
{
    public class HtmlResult : IResult
    {
        string html = string.Empty;

        public HtmlResult(string html)
        {
            this.html = html;
        }

        public async Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.ContentType = "text/html; charset=utf-8";
            await httpContext.Response.WriteAsync(html);
        }
    }
}
