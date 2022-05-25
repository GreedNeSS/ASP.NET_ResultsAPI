var builder = WebApplication.CreateBuilder(
    new WebApplicationOptions { WebRootPath = "Files"});
var app = builder.Build();

app.Map("/", () => "Hello World!");
app.Map("/byte", async () =>
{
    string path = "Files/Forest.jpg";
    byte[] buffer = await File.ReadAllBytesAsync(path);
    string contentType = "image/jpeg";
    string downloadName = "Byte Forest.jpg";
    return Results.File(buffer, contentType, downloadName);
});
app.Map("/stream", () =>
{
    string path = "Files/Forest.jpg";
    FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
    string contentType = "image/jpeg";
    string downloadName = "Stream Forest.jpg";
    return Results.File(stream, contentType, downloadName);
});
app.Map("/file", () =>
{
    string path = "Forest.jpg";
    string contentType = "image/jpeg";
    string downloadName = "String Forest.jpg";
    return Results.File(path, contentType, downloadName);
});

app.Run();
