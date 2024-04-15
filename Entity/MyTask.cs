using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Enumerator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Entity
{
    public class MyTask
    {
        [Key]
        public int Id { get; set;}  
        public string Name { get; set;}
        public string Description { get; set; }
        public Status StatusToDo { get; set; } = Status.New;
        public bool IsActive { get; set; } = true;
        public DateTime CreatAt { get; set; } = DateTime.Now;
        
        //----------------------------
        public Desenvolvedor Desenvolvedor { get; set; }
        public int DesenvolvedorId { get; set; }


    }
}