using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using LFC_Management.Application; // Nạp để xử lý tầng nghiệp vụ


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
            // 1. Khởi tại thùng chứa dich vụ (DI Container)
            var service = new ServiceCollection ();

            //2. Kich hoạt MediatR quét các Command/Query ở tầng Application
            service.AddApplicationServices();

            //3. Đăng ký Form1 vào hệ thống DI Container
            service.AddTransient<Form1>();
            // Build bộ nạp dịch vụ
            ServiceProvider = service.BuildServiceProvider ();

            //4. Gọi Form1 thông qua ServiceProvider thay vì dùng: new Form1 ()
            // Viết tường minh 'System.Windows.Forms.Application' để tránh bị trùng tên với tầng Application.
            var mainForm = ServiceProvider.GetRequiredService<Form1>();
            System.Windows.Forms.Application.Run(mainForm);
        }
    }
}