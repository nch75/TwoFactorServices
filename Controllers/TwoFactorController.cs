using Microsoft.AspNetCore.Mvc;
namespace TwoFactorService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwoFactorController : ControllerBase
    {
        public readonly TwoFactorServices _twoFactorService;

        public TwoFactorController(TwoFactorServices twoFactorService)
        {
            _twoFactorService = twoFactorService;
        }

        [HttpPost("send")]
        public IActionResult SendCode([FromBody] SendCodeRequest request)
        {
            if (!_twoFactorService.CanSendCode(request.Phone))
            {
                return BadRequest("Too many active codes for this phone number.");
            }

            var code = _twoFactorService.GenerateAndStoreCode(request.Phone);
            Console.WriteLine($"DEBUG: Code for {request.Phone}: {code}");  // Debug logging
            return Ok(new { Message = "Code sent successfully." });
        }

        [HttpPost("validate")]
        public IActionResult ValidateCode([FromBody] ValidateCodeRequest request)
        {
            if (_twoFactorService.ValidateCode(request.Phone, request.Code))
            {
                return Ok(new { Message = "Code validated successfully." });
            }

            return BadRequest("Invalid code.");
        }
    }

    public record SendCodeRequest(string Phone);
    public record ValidateCodeRequest(string Phone, string Code);
}
