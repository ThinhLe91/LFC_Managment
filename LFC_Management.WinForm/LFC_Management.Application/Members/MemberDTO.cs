using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC_Management.Application.Members
{
    internal class MemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int YearOfBirth { get; set; }
        public int Age { get; set; } // Nhận giá trị tính toán từ Domain
        public string Nationality { get; set; } = string.Empty;
        public int TitleNumber { get; set; }
        public int Score { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string FavorableFoot { get; set; } = string.Empty;
        public int From { get; set; }
        public string Status { get; set; } = string.Empty;// Nhận giá trị tính toán từ Domain
        public int TotalServiceYears { get; set; } // Nhận giá trị tính toán từ Domain
    }
}
