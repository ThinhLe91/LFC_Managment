using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LFC_Management.Application.Common.Persistence;
using LFC_Management.Infrastructure.Persistence;
using LFC_Management.Infrastructure.Persistence.Repositories;

namespace LFC_Management.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            //1. Đăng ký DbContext với connection String kết nối tới SQL Server
            services.AddDbContext<LFCDbContext>(options =>
                 options.UseSqlServer(connectionString));
            //2. Đăng ký liên kết Interface Repo và Implementation thực tế dưới dạng Scoped
            services.AddScoped<IMemberRepository, MemberRepository>();
            return services;
        }
    }
}
