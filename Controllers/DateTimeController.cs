using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using React_ASPNETCore.Data;
using React_ASPNETCore.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace React_ASPNETCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        [HttpPost("convert")]
        public IActionResult ConvertDateTime([FromBody] DateTimeWithTimezone request)
        {
            try
            {
                // Combine date and time
                DateTime localDateTime = request.Date.Add(request.Time);

                // Convert to DateTimeOffset based on timezone
                TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(request.Timezone);
                DateTimeOffset dateTimeWithOffset = new DateTimeOffset(localDateTime, timeZoneInfo.GetUtcOffset(localDateTime));

                return Ok(new
                {
                    OriginalDate = request.Date,
                    OriginalTime = request.Time,
                    Timezone = request.Timezone,
                    DateTimeWithOffset = dateTimeWithOffset
                });
            }
            catch (TimeZoneNotFoundException)
            {
                return BadRequest("Invalid Timezone Identifier");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
