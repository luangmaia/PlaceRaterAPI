using PlaceRaterAPI;
using PlaceRaterAPI.UOW;
using PlaceRaterAPI.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlaceRater.BLLs
{
    public class UsersBLL
    {
        public User CadastrarUsuario(User user)
        {
            User userReturn = new User();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                userReturn = unitOfWork.Users.CadastrarUsuario(user);
                unitOfWork.Complete();
            }

            return userReturn;
        }

        public bool existeUsuario(User user)
        {
            bool existe = true;
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                if (unitOfWork.Users.GetUser(user) == null)
                {
                    existe = false;
                } else
                {
                    existe = true;
                }
            }

            return existe;
        }

        public User LogarUsuario(User user)
        {
            User userReturn = new User();
            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                userReturn = unitOfWork.Users.LoginUsuario(user);
            }

            return userReturn;
        }
    }
}
