using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tut7.Models;

[Table("PCs")]
public class PC
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }

    public ICollection<PCComponent> PCComponents { get; set; } = null!;


}