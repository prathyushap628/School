using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repositories;
using School.DTOs;


namespace School.Controllers;

[ApiController]
[Route("api/Teacher")]
public class TeacherController : ControllerBase
{
    private readonly ILogger<TeacherController> _logger;
    private readonly ITeacherRepository _Teacher;
  //  private readonly IProductRepository _Product;
   // private readonly IOrderRepository _order;

    public TeacherController(ILogger<TeacherController> logger,
    ITeacherRepository Teacher)
    {
        _logger = logger;
        _Teacher = Teacher;
       //// _Product = Product;
      // this._order = _order;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeacherDTO>>> GetList()
    {
        var res = await _Teacher.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var res = await _Teacher.GetById(id);

        if (res == null)
            return NotFound();

        var dto = res.asDto;
       // dto.Products = (await _Product.GetListByTeacherId(id))
                        //.Select(x => x.asDto).ToList();
       // dto.Orders = (await _order.GetListByTeacherId(id)).Select(x => x.asDto).ToList();

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] TeacherDTO Data)
    {
        var toCreateTeacher = new Teacher
        {
            TeacherName = Data.TeacherName?.Trim(),
            Mobile = Data.Mobile,
            Gender = Data.Gender,
            DateOfJoining = Data.DateOfJoining
         };

        var res = await _Teacher.Create(toCreateTeacher);

        return StatusCode(StatusCodes.Status201Created, res.asDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] TeacherCreateDTO Data)
    {
        var existingTeacher = await _Teacher.GetById(id);

        if (existingTeacher == null)
            return NotFound();

        var toUpdateTeacher = existingTeacher with
        {
           
            TeacherName = Data.TeacherName?.Trim(),
            Mobile = Data.Mobile
        };

        var didUpdate = await _Teacher.Update(toUpdateTeacher);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError);

        return NoContent();
    }
}
