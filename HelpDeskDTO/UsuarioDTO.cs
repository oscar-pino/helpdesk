using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Principal;
using System.DirectoryServices;

namespace HelpDeskDTO
{
    public class UsuarioDTO
    {
        public int IdUser { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public ROLES RolUser { get; set; }

        public UsuarioDTO()
        { 
        
        }
        public UsuarioDTO(String username, String password)
        {
            Username = username;
            Password = password;
        }

        public UsuarioDTO(int idUsuario, String username, String password, ROLES rol) {

            IdUser = idUsuario;
            Username = username;
            Password = password;
            RolUser = rol;
        }

        public override String ToString()
        {
            return String.Format("id: {0}, username: {1}, password: {2}, rol: {3}"
                , IdUser, Username, Password, RolUser);
        }
    }
}
