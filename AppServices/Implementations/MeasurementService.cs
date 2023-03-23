using AppServices.DTO;
using AppServices.Interfaces;
using Repositories.DataObjects;
using Repositories.Implantation;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    internal class MeasurementService : IMeasurementSer
    {
        IMeasurementRepository measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            this.measurementRepository = measurementRepository;
        }

        
            

        public async Task<int> Create(MeasurementDTO entity)
        {
                Measurement measurement = Mapping.Mapper.Map<Measurement>(entity);
               //changed to a create DTO
                measurement.UserId = 9;
                return await measurementRepository.Create(measurement);
        }
        

        public async Task<bool> Delete(int id)
        {
            return await measurementRepository.Delete(id);
        }

        public async Task<List<MeasurementDTO>> GetAll()
        {
            List<Measurement> measurements = await measurementRepository.GetAll();
            List<MeasurementDTO> measurementsDtos = new List<MeasurementDTO>();
            foreach (Measurement measurement in measurements)
            {
                MeasurementDTO measurementDto = Mapping.Mapper.Map<MeasurementDTO>(measurement);
                measurementsDtos.Add(measurementDto);
            }
            return measurementsDtos;
        }

        public async Task<MeasurementDTO> GetById(int id)
        {
            Measurement measurement = await measurementRepository.GetById(id);
            MeasurementDTO measurementDTO = Mapping.Mapper.Map<MeasurementDTO>(measurement);
            return measurementDTO;
        }

        public  async Task<int> Update(int id, MeasurementDTO entity)
        {
            Measurement measurement = Mapping.Mapper.Map<Measurement>(entity);
            //changed to a update DTO
            measurement.UserId = 13;
            return await measurementRepository.Update(id, measurement);
        }
    }
}
