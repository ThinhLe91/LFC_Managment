using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LFC_Management.Domain.Members;

namespace LFC_Management.Application.Common.Persistence
{
    internal class IMemberRepository
    {
        Task<Member> GetByIdAsync(int id);
        Task<IEnumerable<Member>> GetAllAsync(string searchTerm = null);
        Task AddAsync(Member member);
        Task UpdateAsync(Member member);
        Task DeleteAsync(Member member);
    }
}
