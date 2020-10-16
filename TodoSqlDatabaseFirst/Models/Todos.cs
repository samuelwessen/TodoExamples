using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoSqlDatabaseFirst.Models
{
    public partial class Todos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Activity { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }

        public Todos(string activity)
        {
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }
    }
}
