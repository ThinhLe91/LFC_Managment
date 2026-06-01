using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using LFC_Management.Application.Common.Persistence;

namespace LFC_Management.Application.Members.Queries.GetMemberList
{
    // 1. QUERY: Định nghĩa tham số đầu vào (ví dụ: tìm kiếm theo tên hoặc quốc tịch).
    // IRequest<IEnumerable<MemberDTO>> nghĩa là MediatR sẽ trả về một danh sách các MemberDTO cho UI.
    public record GetMemberListQuery(string SearchTerm = null) : IRequest<IEnumerable<MemberDTO>>;

    // 2. HANDLER: Nơi tiếp nhận yêu cầu, truy vấn dữ liệu và chuyển đổi sang DTO
    public class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, IEnumerable<MemberDTO>>
    {
        private readonly IMemberRepository _memberRepository;

        // Tiêm Repository thông qua Dependency Injection
        public GetMemberListQueryHandler(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<MemberDTO>> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
        {
            // 1. Gọi Repository để lấy danh sách từ cơ sở dữ liệu lên
            var members = await _memberRepository.GetAllAsync(request.SearchTerm);

            // 2. Chuyển đổi dữ liệu từ thực thể Domain (Member) sang cấu trúc phẳng (MemberDto) để đẩy ra UI
            var memberDtos = members.Select(m => new MemberDTO
            {
                Id = m.Id,
                Name = m.Name,
                YearOfBirth = m.YearOfBirth,
                Age = m.Age,// Tự lấy giá trị tính toán từ Domain
                Nationality = m.Nationality,
                TitleNumber = m.TitleNumber,
                Score = m.Score,
                Role = m.Role,
                Position = m.Position,
                FavorableFoot = m.FavorableFoot,
                From = m.From,
                Status = m.Status,// Tự lấy giá trị tính toán từ Domain
                TotalServiceYears = m.TotalServiceYears // Tự lấy giá trị tính toán từ Domain
            });

            return memberDtos;
        }
    }
}
