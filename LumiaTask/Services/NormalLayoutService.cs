using LumiaTask.DAL;
using LumiaTask.Models;
using Microsoft.EntityFrameworkCore;

namespace LumiaTask.Services
{
    public class NormalLayoutService
    {
        private readonly AppDbContext _context;

        public NormalLayoutService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Setting>> GetSettingsAsync()
        {
            return await _context.Settings.ToListAsync();
        }
    }
}
