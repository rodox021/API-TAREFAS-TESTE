using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Api.Entity;
using Api.Exceptions;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Controller
{
    [Route("[controller]")]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly IDesenvolvedorRepository _Repository;

        //constructor
        public DesenvolvedorController(IDesenvolvedorRepository repository)
        {
            _Repository = repository;
        }



        // * METODOS *


        // ----------- HTTP GET ----------------------------------------
        [HttpGet]
        public async  Task<IEnumerable<Desenvolvedor>> GetAllDevelopers()
        {
            return await _Repository.GetAll();
        }

         // ----------- HTTP POST ----------------------------------------
        [HttpPost]
        public async Task<ActionResult<Desenvolvedor>> Create([FromBody]Desenvolvedor dev)
        {
            try
            {

                if (dev.Name.Equals("")) 
                {
                    throw new MyTaskException("Selecione um desenvolvedor responsavel pela criação");
                }
                var newdev = await _Repository.Create(dev);
                return Ok(newdev);
                
            }
            catch (MyTaskException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception)
            {
                
                return BadRequest("Erro inesperado!");
            }


        }
    }
}