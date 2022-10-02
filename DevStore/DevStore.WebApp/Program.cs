// O builder � respons�vel por fornecer os m�todos de controle
// dos servi�os e demais funcionalidades na configura��o da App
using DevStore.Repository.Concrete;
using DevStore.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Daqui para baixo � conte�do que vinha dentro do m�todo ConfigureServices() na antiga Startup.cs
// Nesta �rea adicionamos servi�os ao pipeline

// Essa � a nova forma de adicionar o MVC ao projeto
// N�o se usa mais services.AddMvc();
builder.Services.AddControllersWithViews();

// Adicionando inje��o de depend�ncia
builder.Services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();

// Essa linha precisa sempre ficar por �ltimo na configura��o dos servi�os
var app = builder.Build();

// Daqui para baixo � conte�do que vinha dentro do m�todo Configure() na antiga Startup.cs
// Aqui se configura comportamentos do request dentro do pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Note a ligeira mudan�a na declara��o da rota padr�o
// No caso de precisar mapear mais de uma rota duplique o c�digo abaixo
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Essa linha precisa sempre ficar por �ltimo na configura��o do request pipeline
app.Run();
