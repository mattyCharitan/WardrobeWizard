using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace API.Controllers
{
  
    public class MeasurementsController : WardrobeBaseController
    {
        IMeasurementSer measurementService;
        IAuthenticationService _authenticationService;

        public MeasurementsController(IMeasurementSer measurementService, IAuthenticationService authenticationService)
        {
            this.measurementService = measurementService;
            _authenticationService = authenticationService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Measurements/GetAll" }, "Google");
            }
            var measurments = await measurementService.GetAll();
            return Ok(measurments);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Measurements/GetById" }, "Google");
            }
            var measurements = await measurementService.GetById(id);
            return Ok(measurements);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Measurements/Delete" }, "Google");
            }
            var delete = await measurementService.Delete(id);
            return Ok(delete);
        }


        [HttpPut]

        public async Task<IActionResult> Create(MeasurementDTO measurement)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Measurements/Create" }, "Google");
            }
            var create = await measurementService.Create(measurement);
            return Ok(create);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int id, MeasurementDTO measurement)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Challenge(new AuthenticationProperties { RedirectUri = "/Measurements/Update" }, "Google");
            }
            var update = await measurementService.Update(id, measurement);
            return Ok(update);
        }

    }
}
