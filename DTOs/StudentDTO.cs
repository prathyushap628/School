using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record StudentDTO

{
    [JsonPropertyName("student_id")]
    public int StudentId { get; set; }
     [JsonPropertyName("student_name")]
    public string StudentName { get; set; }
     [JsonPropertyName("date_of_birth")]
     
    public string DateOfBirth { get; set; }
    [JsonPropertyName("gender")]
    public String Gender { get; set; }

     [JsonPropertyName("parent_mobile")]
    public long ParentMobile { get; set; }
     [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

      [JsonPropertyName("teacher")]
    public List<TeacherDTO> Teacher { get; set; }
    
      [JsonPropertyName("subject")]
    public List<SubjectsDTO> Subject { get; set; }
}

public record StudentCreateDTO

{

    [JsonPropertyName("student_name")]
    public string StudentName { get; set; }
     [JsonPropertyName("parent_mobile")]
    public long ParentMobile { get; set; }
}