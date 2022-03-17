using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repositories;
using School.DTOs;


namespace School.Controllers;

[ApiController]
[Route("api/Classroom")]
public class ClassroomController : ControllerBase
{
    private readonly ILogger<ClassroomController> _logger;
    private readonly IClassroomRepository _Classroom;
    //  private readonly IProductRepository _Product;
    // private readonly IOrderRepository _order;

    public ClassroomController(ILogger<ClassroomController> logger,
    IClassroomRepository Classroom)
    {
        _logger = logger;
        _Classroom = Classroom;
        //// _Product = Product;
        //  this._order = _order;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClassroomDTO>>> GetList()
    {
        var res = await _Classroom.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var res = await _Classroom.GetById(id);

        if (res == null)
            return NotFound();

        var dto = res.asDto;
        // dto.Products = (await _Product.GetListByClassroomId(id))
        //.Select(x => x.asDto).ToList();
        // dto.Orders = (await _order.GetListByClassroomId(id)).Select(x => x.asDto).ToList();

        return Ok(dto);
    }



}
