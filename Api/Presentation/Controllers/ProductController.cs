using Api.Application.Services.Interfaces;
using Api.Domain.Dto.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _service;

    public ProductController(ILogger<ProductController> logger, IProductService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ProductDTO>> GetAll()
    {
        List<ProductDTO> response = _service.FindAll();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> GetById(int id)
    {
        ProductDTO response = _service.FindById(id);

        return Ok(response);
    }

    [HttpPost]
    public ActionResult<ProductDTO> Create(ProductDTO dto)
    {
        ProductDTO response = _service.Create(dto);

        return Ok(response);
    }

    [HttpPut("{id}")]
    public ActionResult<ProductDTO> Update(ProductDTO dto)
    {
        ProductDTO response = _service.Update(dto);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _service.Delete(id);

        return NoContent();
    }
}
