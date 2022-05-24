var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => Results.Ok(new { message = "root"}));
app.Map("/main", () => Results.Ok("Main Page"));
app.Map("/status", () => Results.StatusCode(500));
app.Map("/notfound", () => Results.NotFound(new { message = "Not Found" }));
app.Map("/unauth", () => Results.Unauthorized());

app.Run();
