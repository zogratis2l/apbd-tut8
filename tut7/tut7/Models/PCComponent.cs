using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace tut7.Models;

[Table("PCComponents")]
[PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    [ForeignKey(nameof(PC))]
    public int PCId { get; set; }
    [ForeignKey(nameof(Component))]
    public string ComponentCode { get; set; }
    
    public int Amount { get; set; }

    public PC PC { get; set; } = null!;
    public Component Component { get; set; } = null!;
}