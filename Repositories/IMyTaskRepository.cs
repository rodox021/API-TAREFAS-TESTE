using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entity;

namespace Api.Repositories
{
    public interface IMyTaskRepository
    {
        Task<IEnumerable<MyTask>> GetAll();
        Task<MyTask> GetById(int id);
        Task<MyTask> Create(MyTask task);
        Task Update(MyTask task);
        Task Delete(int id);
      

    }
}