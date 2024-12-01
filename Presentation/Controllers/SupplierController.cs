using inventory_api.Domain.Repository;
using inventory_api.Presentation.Dtos.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace inventory_api.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class SupplierController : Controller
{
    private readonly ILogger<SupplierController> _logger;
    private readonly ISupplierRepository _repository;

    [HttpGet]
    [Route("/")]
    public ActionResult<IEnumerator<SupplierResponseDTO>> GetAll()
    {
        // List<SupplierResponseDTO> response = _repository.FindAll();

        return Ok();
    }

    [HttpGet]
    [Route("/ping")]
    public ActionResult<IEnumerator<SupplierResponseDTO>> Ping()
    {
        // List<SupplierResponseDTO> response = _repository.FindAll();

        return Ok(new { Pong = true });
    }
}