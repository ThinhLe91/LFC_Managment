using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LFC_Management.Infrastructure.Persistence;

namespace LFC_Management.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LFCDbContext>
    {
        public LFCDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LFCDbContext>();

            // Khai báo chính xác chuỗi kết nối SQL Server giống như trong file Program.cs của bạn
            string connectionString = @"Server=DESKTOP-FQ5KDJN\SQLEXPRESS;Initial Catalog=LFC_Database;Integrated Security=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new LFCDbContext(optionsBuilder.Options);
        }
    }
}