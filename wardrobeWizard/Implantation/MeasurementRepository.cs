using Microsoft.EntityFrameworkCore;
using Repositories.DataObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implantation
{
    public class MeasurementRepository : IMeasurementRepository
    {
        WardrobeWizard context;

        public MeasurementRepository(WardrobeWizard context)
        {
            this.context = context;
        }
        public async Task<int> Create(Measurement entity)
        {
            await context.Measurements.AddAsync(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var measurement = await context.Measurements.FindAsync(id);

            if (measurement == null)
            {
                return false;
            }

            context.Measurements.Remove(measurement);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Measurement>> GetAll()
        {
            return await context.Measurements.ToListAsync<Measurement>();
        }

        public async Task<Measurement> GetById(int id)
        {
            return await context.Measurements
                .FirstOrDefaultAsync(measurement => measurement.MeasurementsId == id);
        }

        public async Task<int> Update(int id, Measurement entity)
        {
            var measurement = await context.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return 0;
            }

            measurement.Size = entity.Size;
            measurement.Weight = entity.Weight;
            measurement.Height = entity.Height;
            measurement.Hip = entity.Hip;
            measurement.Waist = entity.Waist;
            measurement.Bust = entity.Bust;
            return await context.SaveChangesAsync();
        }
    }
}
