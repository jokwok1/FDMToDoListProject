using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FDMToDoListProjectWeb.Models
{
    public class Category
    {
        [Key] //annotation to state it is a primary key
        public int Id { get; set; }
        // if name is Id, they will automatically recognize as primary key
        [Required]
        public string Name { get; set; } = string.Empty;

        public int DisplayOrder { get; set; } // method to display order of categories in our webpage

    }
}
