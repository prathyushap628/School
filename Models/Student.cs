

using School.DTOs;

namespace School.Models;



public record Student
{
    public long StudentId { get; set; }
    public string StudentName { get; set; }
    public String Gender { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public long ParentMobile { get; set; }
    public long ClassId { get; set; }

   

    public StudentDTO asDto => new StudentDTO
    {
         StudentName = StudentName,
        ParentMobile = ParentMobile,
        
    };
}