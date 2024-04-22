using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entity;
using Api.Exceptions;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly IMyTaskRepository _Repository;

        public MyTasksController(IMyTaskRepository repository)
        {
            _Repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<MyTask>> GetTasks()
        {
            return await _Repository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<MyTask> GetTasks(int id)
        {
            return await _Repository.GetById(id);
        }


        [HttpPost]
        public async Task<ActionResult<MyTask>> Create([FromBody]MyTask task)
        {
            try
            {

                if (task.DesenvolvedorId == 0 ) 
                {
                    throw new MyTaskException("Selecione um desenvolvedor responsavel pela criação");
                }
                var newTask = await _Repository.Create(task);
                return Ok(newTask);
                
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

        [HttpPut]
        public async Task<ActionResult<MyTask>> Update(int id, MyTask task)
        {
            if (await GetTasks(id) == null )
            {
                return NotFound("Tarefa não encontrada dou já foi excluida");
            }
            await _Repository.Update(task);
            return  NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
             var taskToDelete = await _Repository.GetById(id);
            if (taskToDelete == null)
            {
                return NotFound();

            }
            await _Repository.Delete(taskToDelete.Id);
            return NoContent();
        }
    }
}