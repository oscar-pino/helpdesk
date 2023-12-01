using HelpDeskDAO;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelpDeskBO
{
    public class UsuarioBO
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();
        public UsuarioDTO isAuthenticated(String username, String password) {
            
            return usuarioDAO.isAuthenticated(username, password);
        }
        public UsuarioDTO create(UsuarioDTO usuario)
        {
            return usuarioDAO.create(usuario);
        }
        public List<UsuarioDTO> readAlls()
        {
            return usuarioDAO.readAlls();
        }
        public UsuarioDTO readById(int id)
        {
            return usuarioDAO.readById(id);
        }
        public UsuarioDTO update(UsuarioDTO usuario)
        {
            return usuarioDAO.update(usuario);
        }
        public int delete(int id)
        {
            return usuarioDAO.delete(id);
        }
        public List<String> readByRolId(int id)
        {
            return usuarioDAO.readByRolId(id);
        }
        public void executeQuery(String sql)
        {
            usuarioDAO.executeQuery(sql);
        }
    }
}
