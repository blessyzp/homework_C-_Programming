
using Microsoft.EntityFrameworkCore;
using OrderApp;
using OrderApp;

namespace Assignment9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            String? connnectionString = builder.Configuration.GetConnectionString("orderDB");
            if (string.IsNullOrEmpty(connnectionString))
            {
                // 抛出一个异常
                throw new Exception("未找到MySQL数据库连接字符串，请在配置文件中配置正确的连接字符串。");
            }
            builder.Services.AddDbContext<OrderDbContext>(opt => opt.UseMySQL(connnectionString));
            builder.Services.AddScoped<OrderService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}