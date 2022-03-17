using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record TeacherDTO

{
    [JsonPropertyName("teacher_id")]
    public int TeacherId { get; set; }
     [JsonPropertyName("teacher_name")]
      public string TeacherName { get; set; }
          [JsonPropertyName("gender")]
      public string Gender { get; set; }
     [JsonPropertyName("mobile")]
    public long Mobile { get; set; }
     [JsonPropertyName("date_of_joining")]
    public DateTimeOffset DateOfJoining { get; set; }
    //   [JsonPropertyName("orders")]
    // public List<OrderDTO> Orders { get; set; }
}

public record TeacherCreateDTO

{

    [JsonPropertyName("teacher_name")]
    public string TeacherName { get; set; }
     [JsonPropertyName("mobile")]
    public long Mobile{ get; set; }
     [JsonPropertyName("date_of_joining")]
    public long DateOfJoining { get; set; }
}