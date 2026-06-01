using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using LFC_Management.Domain.Members;
using LFC_Management.Application.Common.Persistence;

namespace LFC_Management.Application.Members.Commands.CreateMember
{
        //1. Command: Định nghĩa các dữ liệu đầu vào nhận từ UI
        // IRequest <int> mean sau khi sử lý xong, MediatR sẽ trả về kiểu dữ liệu int (chính là Id của Member mới tạo)
        public record CreateMemberCommand(
            string Name,
            int YearOfBirth,
            int? YearOfDeath,
            string Nationality,
            int TitleNumber,
            int Score,
            string Role,
            string Position,
            string FavorableFoot,
            int From,
            int? To
        ) : IRequest<int>;

        //2. Handler; Mơi thực thi xử lý logic nghiệp vụ 
        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, int>
        {
            private readonly IMemberRepository _memberRepository;
            // Tiêm Interface Repository vào thông qua Contructor (Dependency Injection)
            public CreateMemberCommandHandler(IMemberRepository memberRepository)
            {
                _memberRepository = memberRepository;
            }

            public async Task<int> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                // Khởi tạo đối tượng Member chuẩn DDD. Logic validation nằm trong Ctor này sẽ tự chạy.
                var member = new Member(
                    request.Name,
                    request.YearOfBirth,
                    request.YearOfDeath,
                    request.Nationality,
                    request.TitleNumber,
                    request.Score,
                    request.Role,
                    request.Position,
                    request.FavorableFoot,
                    request.From,
                    request.To
                );
                // Gọi Repository lưu xuống DB
                await _memberRepository.AddAsync(member);
                // Trả vể Id của Member vừa được tạo
                return member.Id;
            }
        }    
}
