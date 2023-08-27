using ConceptArchitect.Data;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.Ado
{
    public class AdoUserRepository : IRepository<User, string>
    {
        DbManager db;
        public AdoUserRepository(DbManager db)
        {
            this.db = db;
        }


        public async Task<User> Add(User user)
        {
            var query = $"insert into users(Email, Password, Name, profile_photo) " +
                              $"values('{user.Email}','{user.Password}','{user.Name}','{user.Photo}')";

            await db.ExecuteUpdateAsync(query);

            return user;
        }


        public async Task Delete(string id)
        {
            await db.ExecuteUpdateAsync($"delete from users where Email='{id}'");
        }

        private User UserExtractor(IDataReader reader)
        {
            return new User()
            {
                Email = reader["Email"].ToString(),
                Password = reader["Password"].ToString(),
                Name = reader["Name"].ToString(),
                Photo = reader["profile_photo"].ToString()

            };
        }

        public async Task<List<User>> GetAll()
        {
            return await db.QueryAsync("select * from users", UserExtractor);
        }

        public async Task<List<User>> GetAll(Func<User, bool> predicate)
        {
            var users = await GetAll();

            return (from user in users
                    where predicate(user)
                    select user).ToList();

        }

        public async Task<User> GetById(string id)
        {
            return await db.QueryOneAsync($"select * from users where Email='{id}'", UserExtractor);
        }

        public async Task<User> Update(User entity, Action<User, User> mergeOldNew)
        {
            var oldUser = await GetById(entity.Email);
            if (oldUser != null)
            {
                mergeOldNew(oldUser, entity);
                var query = $"update users set " +
                            $"Email='{oldUser.Email}', " +
                            $"Password='{oldUser.Password}', " +
                            $"Name='{oldUser.Name}', " +
                            $"profile_photo='{oldUser.Photo}'";

                await db.ExecuteUpdateAsync(query);
            }

            return entity;



        }

        public Task<List<User>> GetAllFavorites(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> AddFavorite(User entity, string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFavorite(string bookId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
