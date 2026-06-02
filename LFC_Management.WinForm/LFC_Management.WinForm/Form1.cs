using System;
using System.Windows.Forms;
using MediatR;
using LFC_Management.Application.Members.Queries.GetMemberList;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;


namespace LFC_Management.WinForm
{
    public partial class Form1 : Form
    {
        private readonly IMediator _mediator;

        // 1. Tiêm IMediator vào thông qua Dependency Injection đã cấu hình ở Program.cs
        public Form1(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;
        }

        //2. Sự kiện Form1 load: Tự động nạp danh sách 
        private async void Form1_Load(Object sender, EventArgs e)
        {
            await LoadMemberListAsync();
        }

        //3. Sự kiện Click Search
        private async void btnSearch_Click(Object sender, EventArgs e)
        {
            // Lấy từ khóa ngườ dùng nhập vào Textbox
            string searchTerm = txtSearch.Text.Trim();
            await LoadMemberListAsync(searchTerm);
        }

        //4. Hàm để nạp dữ liệu từ MediaR vào DataGridView
        private async System.Threading.Tasks.Task LoadMemberListAsync(string searchTerm = null)
        {
            try
            {
                // Gửi yêu cầu query lấy dữ liệu thông qua MediatR
                var query = new GetMemberListQuery(searchTerm);
                var memberList = await _mediator.Send(query);

                // Gán danh sách DTO nhận được vào bảng hiển thị
                dgvMembers.DataSource = null; // Reset lại bảng trước khi nạp mới

                // Chuyển danh sách sang BindingSource hoặc List để DataGridView hiển thị mượt mà hơn
                System.Windows.Forms.BindingSource bindingSource = new System.Windows.Forms.BindingSource();
                bindingSource.DataSource = memberList;
                dgvMembers.DataSource = bindingSource;

                // Tối ưu giao diện: Tự động căn chỉnh độ rộng cho đẹp mắt
                dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Load data Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Gọi FormAddMember ra từ bộ nạp DI Container thay vì dùng lệnh new truyền thống
            var addForm = Program.ServiceProvider.GetRequiredService<FormAddMember>();
            if(addForm.ShowDialog() == DialogResult.OK)
            {
                await LoadMemberListAsync();
            }    
        }
    }
}
