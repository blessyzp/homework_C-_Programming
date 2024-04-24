
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
                // �׳�һ���쳣
                throw new Exception("δ�ҵ�MySQL���ݿ������ַ��������������ļ���������ȷ�������ַ�����");
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