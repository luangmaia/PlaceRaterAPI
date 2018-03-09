using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PlaceRaterAPI.Repositories.Interfaces;

namespace PlaceRaterAPI.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PlaceRaterContext context) : base(context)
        {
        }

        public User CadastrarUsuario(User user)
        {
            return ((PlaceRaterContext)Context).Users.Add(user);
        }

        public User GetUser(User user)
        {
            User userBD = ((PlaceRaterContext)Context).Users
                .Where(u => u.Login.Equals(user.Login))
                .SingleOrDefault();

            return userBD;
        }

        public User LoginUsuario(User user)
        {
            User userBD = ((PlaceRaterContext)Context).Users
                .Where(u => u.Login.Equals(user.Login) && u.HashPass.Equals(user.HashPass))
                .SingleOrDefault();

            return userBD;
        }
    }
}
