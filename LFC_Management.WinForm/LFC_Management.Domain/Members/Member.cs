using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFC_Management.Domain.Common;

namespace LFC_Management.Domain.Members
{
    public class Member : AggregateRoot
    {
        //1. Các thuộc tính cơ bản (lưu trữ trong Database)
        public string Name { get; private set; }
        public int YearOfBirth { get; private set; } //chỉ lưu năm sinh dạng số nguyên để tính số tuổi
        public int? YearOfDeath { get; private set; } //dùng int? vì cầu thủ còn sống chưa có năm mất
        public string Nationality { get; private set; }
        public int TitleNumber { get; private set; }
        public int Score { get; private set; }
        public string Role { get; private set; }
        public string Position { get; private set; }
        public string FavorableFoot { get; private set; }
        public int From { get; private set; }
        public int? To { get; private set; } //dùng int? vì cầu thủ còn hợp đồng chưa có năm kết thúc

        //2. Cac thuộc tính tính toán (Computed Properties) không cần lưu trong Database
        // Số tuổi = năm mất (nếu đã mât) hoặc năm hiện tại - năm sinh
        public int Age
        {
            get
            {
                int endYear = YearOfDeath.HasValue ? YearOfDeath.Value : DateTime.Now.Year;
                int age = endYear - YearOfBirth;
                return age < 0 ? 0 : age;
            }
        }

        // số năm phục vụ = năm kết thúc (nếu có) hoặc năm hiện tại (nếu còn hợp đồng) - năm bắt đầu
        public int totalServiceYears
        {
            get
            {
                int endYear = To.HasValue ? To.Value : DateTime.Now.Year;
                int years = endYear - From;
                return years < 0 ? 0 : years;
            }
        }

        //Trạng thái hợp đông, dựa trên dữ liệu đã có năm kêt thúc (To) hay chưa, nếu chưa hoặc năm kết thúc > năm hiện tại -> In Contract
        public string Status
        {
            get
            {
                if (!To.HasValue || To.Value > DateTime.Now.Year)
                {
                    return "In Contract";
                }
                return "Out Of Contract";
            }
        }

        // Contructor bắt buộc của Entity Framework Core
        protected Member() { }

        // Ctor dùng khi tạo mới thành viên (Add)
        public Member(string name, int yearOfBirth, int? yearOfDeath, string nationality,int titleNumber, int score, string role, string position, string favorableFoot, int from, int? to)
        {
            // Phương thức/hàm Kiểm tra các quy tắc trước khi gán dữ liệu
            ValidateMemberRules(name, yearOfBirth, yearOfDeath, from, to);
            Name = name;
            YearOfBirth = yearOfBirth;
            YearOfDeath = yearOfDeath;
            Nationality = nationality;
            TitleNumber = titleNumber;
            Score = score;
            Role = role;
            Position = position;
            FavorableFoot = favorableFoot;
            From = from;
            To = to;      
        }
            // Phương thức/hàm cập nhật thông tin member (Edit)
        public void UpdateInfo (string name, int yearOfBirth, int? yearOfDeath, string nationality,int titleNumber, int score, string role, string position, string favorableFoot, int from, int? to)
        {
            // Phương thức/hàm Kiểm tra các quy tắc trước khi gán dữ liệu
            ValidateMemberRules(name, yearOfBirth, yearOfDeath, from, to);
            Name = name;
            YearOfBirth = yearOfBirth;
            YearOfDeath = yearOfDeath;
            Nationality = nationality;
            TitleNumber = titleNumber;
            Score = score;
            Role = role;
            Position = position;
            FavorableFoot = favorableFoot;
            From = from;
            To = to;
        }

        // Các quy tắc kiểm tra nghiệp vụ (data validation principle)
        private void ValidateMemberRules (string name, int birth, int? death, int from, int? to)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException ("Member name can not be blank!");
            if (birth > DateTime.Now.Year)
                throw new ArgumentException ("Year of birth can not greater than current year!");
            if (death.HasValue && death.Value > birth)
                throw new ArgumentException ("Year Of Death can not happend before year of birth!");
            if (from < birth)
                throw new ArgumentException ("Year of start sever can not before year of birth!");
            if (to.HasValue && to.Value <from)
                throw new ArgumentException ("Year of end sever can not less than year of start!");
        }
    }
}