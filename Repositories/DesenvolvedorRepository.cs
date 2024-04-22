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

        public async Task<Desenvolvedor> GetById(int id)
        {
             return await _context.Desenvolvedores.FindAsync(id);
        }

        // METODO HTTP POST ---------------------------------------------------------------------------
        public async Task<Desenvolvedor> Create(Desenvolvedor dev)
        {
            _context.Desenvolvedores.Add(dev);
           await _context.SaveChangesAsync();
           return dev;
        }

        // METODO HTTP DELETE ---------------------------------------------------------------------------
        public async Task Delete(int id)
        {
             var devdelete = await _context.Desenvolvedores.FindAsync(id);
            _context.Desenvolvedores.Remove(devdelete);
            await _context.SaveChangesAsync();
        }

        
        // METODO HTTP PUT ---------------------------------------------------------------------------

        public async Task<Desenvolvedor> Update(Desenvolvedor dev)
        {
           _context.Desenvolvedores.Update(dev);
           await _context.SaveChangesAsync();
            return dev;
        }



    }
}