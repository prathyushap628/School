

using School.DTOs;

namespace School.Models;


public record Classroom
{
    public long ClassId { get; set; }
    public string ClassName { get; set; }
   

   

    public ClassroomDTO asDto => new ClassroomDTO
    {
         ClassName = ClassName,
        
        
    };
}