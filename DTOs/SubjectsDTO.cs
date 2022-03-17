using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record SubjectsDTO

{
    [JsonPropertyName("subject_id")]
    public int SubjectId { get; set; }
     [JsonPropertyName("subject_name")]
    public string SubjectName { get; set; }
     
    //  [JsonPropertyName("orders")]
   // public List<OrderDTO> Orders { get; set; }
}

public record SubjectsCreateDTO

{

    [JsonPropertyName("subject_name")]
    public string SubjectName { get; set; }
   
}