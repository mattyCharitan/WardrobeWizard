using Microsoft.EntityFrameworkCore;
using Repositories.DataObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implantation
{
    internal class UserRepository:IUserRepository
    {
        WardrobeWizard context;

        public UserRepository(WardrobeWizard context)
        {
            this.context = context;
        }

         public async Task<List<User>> GetAll()
        {
            return await context.Users
                .Include(user => user.Measurements)
                .Include(user => user.Items)
                .Include(user => user.Outfits)
                .ToListAsync<User>();

        }

        public async Task<User> GetById(int id)
        {
            return await context.Users
                .Include(user => user.Measurements)
                .Include(user => user.Items)
                .Include(user => user.Outfits)
                .FirstOrDefaultAsync(user => user.UserId == id);
        }

        public async Task<int> Create(User entity)
        {
            await context.Users.AddAsync(entity);
             await context.SaveChangesAsync();
            return entity.UserId;


        }

        public async Task<int> Update(int id, User entity)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return 0; 
            }

            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Phone= entity.Phone;
            user.Gender = entity.Gender;
            user.Age= entity.Age;



            //TODO: check wher whould i update: Outfits, items, Measurement
            /*var measurement = await context.Measurements.FirstOrDefaultAsync(m => m.UserId == entity.UserId);
            if (measurement != null)
            {
                await MeasurementRepository.Update(measurement.MeasurementsId, entity.Measurements);
            }*/

            

             await context.SaveChangesAsync();
            return id;

        }

        public async Task<bool> Delete(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<User> find(int id)
        {
            User user = await context.Users.FindAsync(id);
            return user;
        }
    }
}
