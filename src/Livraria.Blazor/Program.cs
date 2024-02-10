using Livraria.Infra.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfra(builder.Configuration);

var app = builder.Build();

CreateDatabase(app);

if (!app.Environment.IsDevelopment()) {
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

static void CreateDatabase(WebApplication app) {
  var serviceScope = app.Services.CreateScope();
  var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
  dataContext?.Database.EnsureCreated();
}