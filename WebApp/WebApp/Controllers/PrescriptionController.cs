using Microsoft.AspNetCore.Mvc;
using WebApp.Models.DTO;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("hospital/prescription")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _prescriptionService;

    public PrescriptionController(IPrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription(AddPrescription addPrescription, CancellationToken cancellationToken)
    {
        var result = await _prescriptionService.AddPrescription(addPrescription,cancellationToken);
        return Ok(result);
    }
     
}