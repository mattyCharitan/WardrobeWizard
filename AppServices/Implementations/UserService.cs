using AppServices.DTO;
using AppServices.Interfaces;
using Repositories.DataObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace AppServices.Implementations
{
    public class UserService : IUserSer
    {
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<int> Create(UserDTO entity)
        {
            User user = Mapping.Mapper.Map<User>(entity);
            //check how should i get the missing pieces of the object
            user.Password = "123";
            return userRepository.Create(user);
        }

        public Task<bool> Delete(int id)
        {
            return userRepository.Delete(id);  
        }

        public async Task<List<UserDTO>> GetAll()
        {
            List<User> users = await userRepository.GetAll();
            List<UserDTO> usersDtos = new List<UserDTO>();
            foreach (User user in users)
            {
                UserDTO userDTO = Mapping.Mapper.Map<UserDTO>(user);
                usersDtos.Add(userDTO);


            }
            return usersDtos;


        }

        public async Task<UserDTO> GetById(int id)
        {
            User user = await userRepository.GetById(id);
            UserDTO userDTO = Mapping.Mapper.Map<UserDTO>(user);
            return userDTO;
            
        }

        public async Task<int> Update(int id, UserDTO entity)
        {
            User user = Mapping.Mapper.Map<User>(entity);
            //check how should i get the missing pieces of the object
            user.Password = "123";
            return await userRepository.Update(id, user);
        }
    }
}
