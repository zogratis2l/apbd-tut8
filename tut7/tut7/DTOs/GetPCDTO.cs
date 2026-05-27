namespace tut7.DTOs;

public class GetPCDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock {get; set;}
    public List<GetComponentsDTO> Components { get; set; }
}