using Api.Application.Services.Interfaces;
using Api.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : Controller
{
    private readonly ILogger<SupplierController> _logger;
    private readonly ISupplierService _service;

    public SupplierController(ILogger<SupplierController> logger, ISupplierService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerator<SupplierDTO>> GetAll()
    {
        List<SupplierDTO> response = _service.FindAll();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<SupplierDTO> GetById(int id)
    {
        SupplierDTO response = _service.FindById(id);

        return Ok(response);
    }

    [HttpPost]
    public ActionResult<SupplierDTO> Create(SupplierDTO dto)
    {
        SupplierDTO response = _service.Create(dto);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public ActionResult<SupplierDTO> Update(SupplierDTO dto)
    {
        SupplierDTO response = _service.Update(dto);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _service.Delete(id);

        return NoContent();
    }
}
