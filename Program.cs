using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using backend_thorin.Context;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdminContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoAdm")));
    
builder.Services.AddDbContext<ProdutosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoProdutos")));
    
builder.Services.AddDbContext<ClienteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoClientes")));

builder.Services.AddDbContext<FornecedorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoFornecedores")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();
app.UseRouting();
 app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "admin/{controller=Admin}/{action=Index}/{id?}");
    });
app.Run();

