using System;
namespace CreateCustomIResult
{
    public static class ResultsExtensions
    {
        public static IResult Html(this IResultExtensions extensions, string html)
        {
            return new HtmlResult(html);
        }
    }
}
