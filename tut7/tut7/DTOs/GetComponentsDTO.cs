namespace tut7.DTOs;

public class GetComponentsDTO
{
    public int Amount { get; set; }
    public GetComponentInfoDTO Component { get; set; }
    
    
}

public class GetComponentInfoDTO
{
    public string Code  { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public GetManufacturerDTO  Manufacturer { get; set; }
    public GetTypeDTO Type { get; set; }
}


public class GetManufacturerDTO
{
   public int Id { get; set; }
   public string Abbreviation { get; set; }
   public string FullName { get; set; }
   public DateOnly FoundationDate { get; set; }
   
}

public class GetTypeDTO
{
    public int Id { get; set; }
    public string Abbreviation { get; set; }
    public string Name { get; set; }
}