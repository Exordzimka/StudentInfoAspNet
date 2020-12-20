using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentInfoAspNet.Models;

namespace StudentInfoAspNet.Repositories.Implementation
{
    public sealed class StudentRepository : IRepository<Students>
    {
        private readonly StudentInfoContext _context;
        public StudentRepository()
        {
            _context = new StudentInfoContext();
        }

        public async Task<List<Students>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }
        
        public async Task<List<Students>> GetTop()
        {
            return await _context.Students.OrderByDescending(groups => groups.AverageScore).Take(3).ToListAsync();
        }

        public async Task<Students> GetById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(students => students.Id==id);
        }

        public void Create(Students item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public async void Update(Students item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var studentForDeleting = await _context.Students.FirstOrDefaultAsync(student => student.Id == id);
            _context.Students.Remove(studentForDeleting);
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