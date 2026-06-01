using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LFC_Management.Domain.Members;
using LFC_Management.Domain.Common;

namespace LFC_Management.Infrastructure.Persistence
{
    public class LFCDbContext : DbContext
    {
        //Contructor để nhận cấu hình Connection String từ tâng ngoài truyền vào
        public LFCDbContext (DbContextOptions<LFCDbContext> options) : base(options)
        {
        }
        // Khai báo bảng dữ liệu Members
        public DbSet <Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cấu hình bảng member bằng Fluent API (chuần DDD)
            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Members");
                entity.HasKey(e => e.Id); // khóa chính kế thừa từ base class Entity
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Nationality).HasMaxLength(100);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.Position).HasMaxLength(50);
                entity.Property(e => e.FavorableFoot).HasMaxLength(20);

                // Bảo EF Core bỏ qua (Không tạo cột dưới DB) cho các thuộc tính tự tính toán (Computed Properties)
                entity.Ignore(e => e.Age);
                entity.Ignore(e => e.TotalServiceYears);
                entity.Ignore(e => e.Status);
            });
        }
    }
}
