using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Api.Context;
using Api.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace API.Repositories
{
    public class DesenvolvedorRepository : IDesenvolvedorRepository
    {
        private readonly MyTaskContext _context;

        public DesenvolvedorRepository(MyTaskContext context)
        {
            _context = context;
        }


        // MEODOS HTTP GET ---------------------------------------------------------------------------
        public async Task<IEnumerable<Desenvolvedor>> GetAll()
        {
            return await _context.Desenvolvedores.ToListAsync();
        }

        public Task<Desenvolvedor> GetById(int id)
        {
            throw new NotImplementedException();
        }

        // METODO HTTP POST ---------------------------------------------------------------------------
        public async Task<Desenvolvedor> Create(Desenvolvedor dev)
        {
            _context.Desenvolvedores.Add(dev);
           await _context.SaveChangesAsync();
           return dev;
        }

        // METODO HTTP DELETE ---------------------------------------------------------------------------
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        
        // METODO HTTP PUT ---------------------------------------------------------------------------

        public Task Update(Desenvolvedor task)
        {
            throw new NotImplementedException();
        }



    }
}