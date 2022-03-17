

using School.DTOs;

namespace School.Models;


public record Teacher
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string Gender { get; set; }
    
    public long Mobile { get; set; }
  
    public DateTimeOffset DateOfJoining { get; set; }

   

    public TeacherDTO asDto => new TeacherDTO
    {
         TeacherName = TeacherName,
         Mobile = Mobile,
        
    };
}