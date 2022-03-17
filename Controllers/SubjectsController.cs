using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repositories;
using School.DTOs;


namespace School.Controllers;

[ApiController]
[Route("api/Subjects")]
public class SubjectsController : ControllerBase
{
    private readonly ILogger<SubjectsController> _logger;
    private readonly ISubjectsRepository _Subjects;
    //  private readonly IProductRepository _Product;
    // private readonly IOrderRepository _order;

    public SubjectsController(ILogger<SubjectsController> logger,
    ISubjectsRepository Subjects)
    {
        _logger = logger;
        _Subjects = Subjects;
        //// _Product = Product;
        // this._order = _order;
    }

    [HttpGet]
    public async Task<ActionResult<List<SubjectsDTO>>> GetList()
    {
        var res = await _Subjects.GetList();

        return Ok(res.Select(x => x.asDto));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] int id)
    {
        var res = await _Subjects.GetById(id);

        if (res == null)
            return NotFound();

        var dto = res.asDto;
        // dto.Products = (await _Product.GetListBySubjectsId(id))
        //.Select(x => x.asDto).ToList();
        //dto.Orders = (await _order.GetListBySubjectsId(id)).Select(x => x.asDto).ToList();

        return Ok(dto);
    }




}
