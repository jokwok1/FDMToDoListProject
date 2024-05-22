using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FDMToDoListProject.Models
{
    public class Category
    {
        [Key] //annotation to state it is a primary key
        public int Id { get; set; }
        // if name is Id, they will automatically recognize as primary key
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)] // maximum length of 30
        public string Name { get; set; } = string.Empty;

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be 1-100")] //range of display order
        public int DisplayOrder { get; set; } // method to display order of categories in our webpage

        [JsonIgnore] // remove when serailizing to Json as it can lead to an infinite loop
        public virtual List<ToDoList> ToDoLists { get; set; }
        // virtual toDoLists that might below to the same category
    }
}
