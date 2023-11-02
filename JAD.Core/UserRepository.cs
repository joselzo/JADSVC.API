using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JADSVC.Data.DataDB;
using JADSVC.Intefaces;
using JADSVC.Models;
using JADSVC.Models.StoreProcedures.UserSP;
using Microsoft.EntityFrameworkCore;

namespace JAD.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly JadsvcsContext _context;
        private readonly IMapper _mapper;
        public UserRepository(JadsvcsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO); // Mapea el DTO a la entidad
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<UserDTO>(user);
                return result;
            }
            catch (Exception ex)
            {
                return null; // ServiceOrder not found
            }

        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return _mapper.Map<UserDTO>(user); // Mapea la entidad a DTO
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users); // Mapea las entidades a DTOs
        }

        public async Task<UserDTO> UpdateUserAsync(int id, UserDTO userDTO)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(id);
                if (existingUser == null)
                {
                    return null; // User not found
                }

                // Mapea las propiedades del DTO a la entidad existente
                _mapper.Map(userDTO, existingUser);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserDTO>(existingUser); // Mapea la entidad actualizada a DTO
            }
            catch (Exception ex)
            {
                return null; // ServiceOrder not found
            }

        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false; // User not found
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        //STORED PROCEDURES---------------------------------------------------------
        public async Task<List<UserDTO>> spGetUser(int id)
        {
            try
            {
                // Utiliza FromSqlRaw para ejecutar el procedimiento almacenado y mapear los resultados a la clase UserResult
                var user = await _context.Users.FromSqlRaw("spGetUser {0}", id).ToListAsync();
                return _mapper.Map<List<UserDTO>>(user);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
