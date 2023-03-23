using AppServices.DTO;
using AppServices.Implementations;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  
    public class MeasurementsController : WardrobeBaseController
    {
        IMeasurementSer measurementService;

        public MeasurementsController(IMeasurementSer measurementService)
        {
            this.measurementService = measurementService;
        }

        [HttpGet]

        public async Task<List<MeasurementDTO>> GetAll()
        {
            return await measurementService.GetAll();
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
