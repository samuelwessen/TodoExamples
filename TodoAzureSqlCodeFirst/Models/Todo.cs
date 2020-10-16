using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoAzureSqlCodeFirst.Models
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Activity { get; set; }

        [Required]
        public bool Completed { get; set; }


        [Required]
        public DateTime Created { get; set; }


        // var todo = new Todo()
        //      todo.Activity = "activity text";
        //      todo.Completed = false;
        // new Todo { Activity = "activity text", Completed = false,Created = DateTime.Now }
        public ToDo()
        {

        }

        // var todo = new Todo("activity text")
        // new Todo ("activity text")
        public ToDo(string activity)
        {
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }
    }
}
