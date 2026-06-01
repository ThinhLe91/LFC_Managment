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
        public string Name { get; set; }
        public int YearOfBirth { get; set; }
        public int Age { get; set; } // Nhận giá trị tính toán từ Domain
        public string Nationality { get; set; }
        public int TitleNumber { get; set; }
        public int Score { get; set; }
        public string Role { get; set; }
        public string Position { get; set; }
        public string FavorableFoot { get; set; }
        public int From { get; set; }
        public string Status { get; set; } // Nhận giá trị tính toán từ Domain
        public int TotalServiceYears { get; set; } // Nhận giá trị tính toán từ Domain
    }
}
