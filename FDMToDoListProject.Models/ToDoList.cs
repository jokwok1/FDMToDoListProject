using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FDMToDoListProject.Models
{
    public class ToDoList
    {
        [Key] //annotation to state it is a primary key
        public int Id { get; set; }
        // if name is Id, they will automatically recognize as primary key
        [Required]
        [DisplayName("ToDoList Title")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; } = DateTime.Now;
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
        public bool HighPriority { get; set; }

        public bool Completed { get; set; } = false;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public virtual Category? Category { get; set; }
    }
}
