using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediatR;
using LFC_Management.Application.Members.Commands.CreateMember;

namespace LFC_Management.WinForm
{
    public partial class FormAddMember : Form
    {
        private readonly IMediator _mediator;
        public FormAddMember(IMediator mediator)
        {
            InitializeComponent();
            _mediator = mediator;

            // Thiêt lập giá trị mặc định cho các ô chọn năm phù hợp GẦN thời gian thực năm 2026
            numBirth.Value = 2000;
            numFrom.Value = 2020;
            numDeath.Value = 2026;
            numTo.Value = 2026;
        }
        private void chkIsDead_CheckedChanged(object sender, EventArgs e)
        {
            numDeath.Enabled = chkIsDead.Checked;
        }
        private void chkInOutContract_CheckedChanged(object sender, EventArgs e)
        {
            numTo.Enabled = chkInOutContract.Checked;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                // Thu thập dũ liệu từ giao diện, xử lý giá trị Nullable theo chuẩn DDD
                String name = txtName.Text.Trim();
                int birth = (int)numBirth.Value;
                int? death = chkIsDead.Checked ? (int?)numDeath.Value : null;
                string nationality = txtNationality.Text.Trim();
                string role = txtRole.Text.Trim();
                string position = txtPosition.Text.Trim();
                string foot = txtFoot.Text.Trim();
                int from = (int)numFrom.Value;
                int? to = chkInOutContract.Checked ? (int?)numTo.Value : null;

                // tạo lệnh command đóng gói dũ liệu gửi đi qua MediatR
                var command = new CreateMemberCommand(
                    name, birth, death, nationality, TitleNumber: 0, Score: 0, // tạm thời để 0 bổ sung sau
                    role, position, foot, from, to
                );
                // Gửi qua MediatR, tầng Application sẽ tự lo validation và gọi xuống Repos lưu xuống DB
                int newMemberId = await _mediator.Send(command);
                MessageBox.Show($"Thêm thành công cầu thủ mới! ID: {newMemberId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;// Đánh dấu để Form1 load lại bảng dgv
                this.Close();
            }
            catch (Exception ex)
            {
                // Nếu vi phạm quy tắc ở lớp Domain (ví dụ năm phục vụ trước năm sinh), lỗi sẽ bắn ra ở đây
                MessageBox.Show($"Lỗi nghiệp vụ : {ex.Message}", "Data input Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
