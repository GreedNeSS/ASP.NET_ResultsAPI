using CreateCustomIResult;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () =>
{
    string html = await File.ReadAllTextAsync("Html/Root.html");
    return Results.Extensions.Html(html);
});

app.MapGet("/main", async () =>
{
    string html = await File.ReadAllTextAsync("Html/Main.html");
    return new HtmlResult(html);
});

app.Run();
