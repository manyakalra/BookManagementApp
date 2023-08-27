using ConceptArchitect.Data;
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

        //constructor based DI
        public PersistentUserService(IRepository<User, string> repository)
        {
            this.repository = repository;
        }

        public async Task<User> AddUser(User user)
        {
            if (user == null)
                throw new InvalidDataException("User can't be null");

            if (string.IsNullOrEmpty(user.Email))
            {
                user.Email = await GenerateId(user.Name)+"@gmail.com";
            }

            return await repository.Add(user);
        }

        private async Task<string> GenerateId(string title)
        {
            var id = title.ToLower().Replace(" ", "-");

            try
            {
                await repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                {
                    return id;
                }
            }

            int d = 1;
            while (await repository.GetById($"{id}-{d}") != null)
                d++;

            return $"{id}-{d}";
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

        public async Task<List<User>> SearchUsers(string term)
        {
            term = term.ToLower();
            return await repository.Search(term);
            //  return await repository.GetAll(a => a.Name.ToLower().Contains(term) || a.Biography.ToLower().Contains(term));
        }

        public async Task<User> UpdateUser(User user)
        {

            return await repository.Update(user, (old, newDetails) =>
            {
                old.Name = newDetails.Name;
                old.Email = newDetails.Email;
                old.Password = newDetails.Password;
                old.Photo = newDetails.Photo;
            });
        }
    }
}
