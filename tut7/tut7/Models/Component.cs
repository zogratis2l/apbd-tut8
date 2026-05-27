using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tut7.Models;

[Table("Components")]
public class Component
{
    [Key]
    public string Code { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }
    
    [ForeignKey(nameof(ComponentManufacturer))]
    public int ComponentManufacturersId { get; set; }
    [ForeignKey(nameof(ComponentType))]
    public int ComponentTypesId { get; set; }
    
    public ComponentType ComponentType { get; set; }
    public ComponentManufacturer ComponentManufacturer { get; set; }
}