using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tut7.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    [Key]
    public int Id { get; set; }
    
    public string Abbreviation { get; set; }
    public string FullName { get; set; }

    public DateOnly FoundationDate { get; set; }

    public ICollection<Component> Components { get; set; } = [];
}