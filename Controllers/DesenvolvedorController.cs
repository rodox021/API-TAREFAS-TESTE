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


        [HttpGet("{id}")]
        public async Task<Desenvolvedor> GetDesenvolvedorById(int id)
        {
            return await _Repository.GetById(id);
        }


         // ----------- HTTP POST ----------------------------------------
        [HttpPost]
        public async Task<ActionResult<Desenvolvedor>> Create([FromBody]Desenvolvedor dev)
        {
            try
            {

                if (dev.Name.Equals("")) 
                {
                    throw new MyTaskException("Nome do desenvolvedor é obrigatório");
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
        // ----------- HTTP PUT ------------------------------------------

    
        [HttpPut]
        public async Task<ActionResult<MyTask>> Update(int id, [FromBody] Desenvolvedor dev)
        {
            if (await GetDesenvolvedorById(id) == null )
            {
                return NotFound("Desenvolvedor não encontrado");
            }
            await _Repository.Update(dev);
            return  Ok(dev);
        }



        // ----------- HTTP DELETE ----------------------------------------
         [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
             var devDelete = await _Repository.GetById(id);
            if (devDelete == null)
            {
                return NotFound();

            }
            await _Repository.Delete(devDelete.Id);
            return NoContent();
        }
    }
}