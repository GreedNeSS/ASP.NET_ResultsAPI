var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        await Results.NoContent().ExecuteAsync(context);
    }
});

app.Map("/", MainPage);
app.Map("/users", () => Results.Content("Users Page"));

app.Run();

IResult MainPage()
{
    return Results.Text("Main Page");
}