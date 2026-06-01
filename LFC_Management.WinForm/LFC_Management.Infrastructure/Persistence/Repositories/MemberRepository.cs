using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LFC_Management.Domain.Members;
using LFC_Management.Application.Common.Persistence;

namespace LFC_Management.Infrastructure.Persistence.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LFCDbContext _dbContext;

        public MemberRepository (LFCDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await _dbContext.Members.FindAsync(id);
        }

        public async Task<IEnumerable<Member>> GetAllAsync(string searchTerm = null)
        {
            IQueryable<Member> query = _dbContext.Members;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(m => m.Name.Contains(searchTerm) ||
                                         m.Nationality.Contains(searchTerm));
            }

            return await query.ToListAsync();
        }

        public async Task AddAsync(Member member)
        {
            await _dbContext.Members.AddAsync(member);
            await _dbContext.SaveChangesAsync(); // Lưu thay đổi thực tế xuống DB
        }

        public async Task UpdateAsync(Member member)
        {
            _dbContext.Members.Update(member);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Member member)
        {
            _dbContext.Members.Remove(member);
            await _dbContext.SaveChangesAsync();
        }       
    }
}
