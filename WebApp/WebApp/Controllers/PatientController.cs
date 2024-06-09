using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

[Route("hospital/patient")]
[ApiController]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id, CancellationToken cancellationToken)
    {
        var result = await _patientService.GetPatient(id, cancellationToken);
        if (result == null)
        {
            return NotFound("Patient not found");
        }
        return Ok(result);
    }

}