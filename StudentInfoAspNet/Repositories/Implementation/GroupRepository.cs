using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentInfoAspNet.Models;

namespace StudentInfoAspNet.Repositories.Implementation
{
    public sealed class GroupRepository : IRepository<Groups>
    {
        private readonly StudentInfoContext _context;

        public GroupRepository()
        {
            _context = new StudentInfoContext();
        }

        public async Task<List<Groups>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }
        
        public async Task<List<Groups>> GetTop()
        {
            return await _context.Groups.OrderByDescending(groups => groups.AverageScore).Take(3).ToListAsync();
        }

        public async Task<Groups> GetById(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(groups => groups.Id == id);
        }

        public void Create(Groups item)
        {
            try
            {
                _context.Groups.Add(item);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
            }
        }

        public async void Update(Groups item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var groupForDelete = await _context.Groups.FirstOrDefaultAsync(groups => groups.Id == id);
            _context.Groups.Remove(groupForDelete);
            await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        private async void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                if (disposing)
                {
                    await _context.DisposeAsync();
                }
            }
            _disposed = true;
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}