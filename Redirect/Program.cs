var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => Results.LocalRedirect("/new"));
app.Map("/old", () => Results.Redirect("/new", true, true));
app.Map("/google", () => Results.Redirect("https://google.com"));
app.Map("/new", () => Results.Content("New Page"));

app.Run();
