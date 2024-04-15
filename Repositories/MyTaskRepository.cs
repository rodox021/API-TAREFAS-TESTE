using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Context;
using Api.Entity;
using Api.Enumerator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MyTaskRepository : IMyTaskRepository
    {
        private readonly MyTaskContext _context;

        public MyTaskRepository(MyTaskContext context)
        {
            _context = context;
        }

        public async Task<MyTask> Create(MyTask task)
        {
           
           _context.Tasks.Add(task);
           await _context.SaveChangesAsync();
           return task;
        }

        public async Task Delete(int id)
        {
            var taskDelete = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskDelete);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<MyTask>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<MyTask> GetById(int id)
        {
            return await _context.Tasks.FindAsync(id);
            
        }

        public async Task Update(MyTask task)
        {
           _context.Entry(task).State = EntityState.Modified;
           await _context.SaveChangesAsync();

           
        }
    }
}