using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using LFC_Management.Application; // Nạp để xử lý tầng nghiệp vụ
using LFC_Management.Infrastructure;


namespace LFC_Management.WinForm
{
    internal static class Program
    {
        // Biến toàn cục để quản lý việc cấp phát các Handler sau này
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //0. Cấu hình Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = @"Server=DESKTOP-FQ5KDJN\SQLEXPRESS;Initial Catalog=LFC_Database;Integrated Security=True;TrustServerCertificate=True;";

            // 1. Khởi tại thùng chứa dich vụ (DI Container)
            var service = new ServiceCollection ();

            // Thêm dòng kích hoạt dịch vụ Logging băt buộc cho MediatR V14
            service.AddLogging();

            //2. Kich hoạt MediatR quét các Command/Query ở tầng Application
            service.AddApplicationServices();

            //3 . NẠP DỊCH VỤ CỦA TẤNG APPLICATION (MediatR)
            service.AddApplicationServices();
            // 🌟 Liên kết IMemberRepository với MemberRepository thực tế
            service.AddInfrastructureServices(connectionString);

            //4. Đăng ký các Form vào hệ thống DI Container
            service.AddTransient<Form1>();
            service.AddTransient<FormAddMember>();

            // 🌟 Kích hoạt gán giá trị cho ServiceProvider:
            ServiceProvider = service.BuildServiceProvider();

            //5. Gọi Form1 thông qua ServiceProvider thay vì dùng: new Form1 () -> Viết tường minh 'System.Windows.Forms.Application' để tránh bị trùng tên với tầng Application.
            var mainForm = ServiceProvider.GetRequiredService<Form1>();
            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}