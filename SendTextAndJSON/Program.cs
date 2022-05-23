using SendTextAndJSON;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/", () => Results.Text("Main Page"));
app.Map("/text", () => Results.Text("<h1>Text Page</h1>", "text/html", System.Text.Encoding.Unicode));

app.Map("/con", () => Results.Content("Content Page"));
app.Map("/content", () => Results.Text("<h1>Content Page</h1>", "text/html", System.Text.Encoding.Unicode));

app.Map("/greed", () => Results.Json(new { Name = "Greed", Age = 20}));
app.Map("/sem", () => Results.Json(new Person("Sem", 24)));
app.Map("/marc", () => Results.Json(new Person("Marc", 40),
    new()
    {
        PropertyNameCaseInsensitive = true,
        NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.WriteAsString
    }));
app.Map("/henry", () => Results.Json(new Person("Henry", 25), 
    new (System.Text.Json.JsonSerializerDefaults.Web)));
app.Map("/terry", () => Results.Json(new Person("Terry", 28), 
    new (System.Text.Json.JsonSerializerDefaults.General), "application/json; charset=utf-8", 201));
app.Map("/error", () => Results.Json(new { message = "Server Error" }, statusCode: 500));


app.Run();
