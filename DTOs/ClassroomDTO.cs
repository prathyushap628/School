using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record ClassroomDTO

{
    [JsonPropertyName("class_id")]
    public int ClassId { get; set; }
     [JsonPropertyName("class_name")]
    public string ClassName { get; set; }
    
     // [JsonPropertyName("orders")]
    //public List<OrderDTO> Orders { get; set; }
}

public record ClassroomCreateDTO

{

    [JsonPropertyName("class_name")]
    public string ClassName { get; set; }
  
}