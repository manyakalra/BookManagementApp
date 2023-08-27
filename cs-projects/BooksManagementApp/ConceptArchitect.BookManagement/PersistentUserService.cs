using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentUserService : IUserService
    {
        IRepository<User, string> repository;

        public PersistentUserService(IRepository<User, string> repository)
        {
            this.repository = repository;
        }


        public async Task<User> AddUser(User user)
        {
            if (user == null)
                throw new InvalidDataException("User can't be null");


            return await repository.Add(user);
        }

        
        public async Task DeleteUser(string userId)
        {
            await repository.Delete(userId);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await repository.GetAll();
        }

        public async Task<User> GetUserById(string id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<User>> SearchUser(string term)
        {
            term = term.ToLower();

            return await repository.GetAll(u => u.Email.ToLower().Contains(term) || u.Name.ToLower().Contains(term));
        }

        public async Task<User> UpdateUser(User user)
        {

            return await repository.Update(user, (old, newDetails) =>
            {
                old.Email = newDetails.Email;
                old.Password = newDetails.Password;
                old.Name = newDetails.Name;
                old.Photo = newDetails.Photo;
            });
        }
    }
}
