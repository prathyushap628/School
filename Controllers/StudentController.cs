using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repositories;
using School.DTOs;


namespace School.Controllers;

[ApiController]
[Route("api/Student")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentRepository _Student;
    private readonly ITeacherRepository _teacher;
    private readonly ISubjectsRepository _subject;

    public StudentController(ILogger<StudentController> logger,
    IStudentRepository Student, ITeacherRepository teacher, ISubjectsRepository subject)
    {
        _logger = logger;
        _Student = Student;
        _teacher = teacher;
        _subject = subject;
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentDTO>>> GetList()
    {
        var res = await _Student.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var res = await _Student.GetById(id);

        if (res == null)
            return NotFound();

        var dto = res.asDto;
        // dto.Products = (await _Product.GetListByStudentId(id))
        //.Select(x => x.asDto).ToList();
        //dto.Orders = (await _order.GetListByStudentId(id)).Select(x => x.asDto).ToList();

        dto.Teacher = await _teacher.GetListByTeacher(res.StudentId);
        dto.Subject = await _subject.GetListBySubjects(res.StudentId);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] StudentDTO Data)
    {
        var toCreateStudent = new Student
        {
            StudentName = Data.StudentName?.Trim(),
            Gender = Data.Gender,
            ClassId = Data.ClassId,
            ParentMobile = Data.ParentMobile



        };

        var res = await _Student.Create(toCreateStudent);

        return StatusCode(StatusCodes.Status201Created, res.asDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] StudentCreateDTO Data)
    {
        var existingStudent = await _Student.GetById(id);

        if (existingStudent == null)
            return NotFound();

        var toUpdateStudent = existingStudent with
        {

            StudentName = Data.StudentName?.Trim(),

            ParentMobile = Data.ParentMobile
        };

        var didUpdate = await _Student.Update(toUpdateStudent);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();
    }
}
