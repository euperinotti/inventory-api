using InventoryApi.Domain.Repository;
using InventoryApi.Presentation.Dtos.Supplier;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Presentation.Controllers;

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