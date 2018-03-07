using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User CadastrarUsuario(User user);
        User LoginUsuario(User user);
    }
}
