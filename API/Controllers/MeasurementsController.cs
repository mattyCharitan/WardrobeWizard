using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace API.Controllers
{
  
    //hi
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
                return Challenge(new AuthenticationProperties { RedirectUri = "/Measurments/GetAll" }, "Google");
            }
            var measurments = await measurementService.GetAll();
            return Ok(measurments);
        }


        [HttpGet("{id}")]
        public async Task<MeasurementDTO> GetById(int id)
        {
            return await measurementService.GetById(id);
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            return await measurementService.Delete(id);
        }


        [HttpPut]

        public async Task<int> Create(MeasurementDTO measurement)
        {
            return await measurementService.Create(measurement);
        }

        [HttpPost]

        public async Task<int> Update(int id, MeasurementDTO measurement)
        {
            return await measurementService.Update(id, measurement);
        }

    }
}
