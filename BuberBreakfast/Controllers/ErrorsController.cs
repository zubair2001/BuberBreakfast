using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class ErrorsControllers : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}