using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entity;

namespace API.Repositories
{
    public interface IDesenvolvedorRepository
    {
        Task<IEnumerable<Desenvolvedor>> GetAll();
        Task<Desenvolvedor> GetById(int id);
        Task<Desenvolvedor> Create(Desenvolvedor task);
        Task<Desenvolvedor> Update(Desenvolvedor task);
        Task Delete(int id);
    }
}