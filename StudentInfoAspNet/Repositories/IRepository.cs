using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentInfoAspNet.Models;

namespace StudentInfoAspNet.Repositories
{
    public interface IRepository<T> : IDisposable
    where T : class
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetTop();
        Task<T> GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}