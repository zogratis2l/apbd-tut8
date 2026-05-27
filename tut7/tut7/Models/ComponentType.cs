using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tut7.Models;

[Table("ComponentTypes")]
public class ComponentType
{
    [Key]
    public int Id { get; set; }
    
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    
    public ICollection<Component> Components { get; set; }
}