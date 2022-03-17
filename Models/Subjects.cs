

using School.DTOs;

namespace School.Models;


public record Subjects
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    
   

    public SubjectsDTO asDto => new SubjectsDTO
    {
         SubjectName = SubjectName,
        
        
    };
}