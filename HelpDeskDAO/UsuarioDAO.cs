using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDeskDTO;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Data;

namespace HelpDeskDAO
{
    public class UsuarioDAO
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private String sql;
        private UsuarioDTO userDTO;
        private List<UsuarioDTO> usersDTO;

        public UsuarioDAO() {

            con = DAO.Instancia;
        }

        public UsuarioDTO isAuthenticated(String user, String password) {

            try {

                sql = "AUTHENTICATE_USER";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@contrasena", password);
                dr = cmd.ExecuteReader();

                if (dr != null) {

                    if (dr.Read())
                    {
                        userDTO = new UsuarioDTO();
                        userDTO.IdUser = Int32.Parse(dr["id_Usuarios"].ToString());
                        userDTO.Username = dr["username"].ToString();
                        userDTO.Password = dr["contrasena"].ToString();
                        userDTO.RolUser = (ROLES)dr["id_roles"];
                    }

                    return userDTO;
                        
                }                   

            }catch{

                return null;
            }
            finally{
            con.Close();
            }
            return null;
        }

        public UsuarioDTO create(UsuarioDTO user)
        {
            try
            {
                sql = "CREATE_USER";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@contrasena", user.Password);
                cmd.Parameters.AddWithValue("@id_roles", (ROLES)user.RolUser);
                cmd.ExecuteNonQuery();

                return readById(user.IdUser);
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<UsuarioDTO> readAlls(){

            try
            {
                sql = "READ_USERS";
                executeQuery(sql);
                usersDTO = new List<UsuarioDTO>();
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        userDTO = new UsuarioDTO();
                        userDTO.IdUser = Int32.Parse(dr["id_usuarios"].ToString());
                        userDTO.Username = dr["username"].ToString();
                        userDTO.Password = dr["contrasena"].ToString();
                        userDTO.RolUser = (ROLES)dr["id_usuarios"];

                        usersDTO.Add(userDTO);
                    }
                    return usersDTO;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public UsuarioDTO readById(int id)
        {
            try
            {
                sql = "READ_USER_BY_ID";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_usuarios", id);
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        userDTO = new UsuarioDTO();
                        userDTO.IdUser = Int32.Parse(dr["id_usuarios"].ToString());
                        userDTO.Username = dr["username"].ToString();
                        userDTO.Password = dr["contrasena"].ToString();
                        userDTO.RolUser = (ROLES)dr["id_roles"];
                    }

                    return userDTO;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public List<String> readByRolId(int id)
        {
            String nombre;
            List<String> nombres;

            try
            {
                nombres = new List<String>();
                sql = "READ_USER_BY_ROL_ID";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_roles", id);
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        nombre = dr["username"].ToString();

                        nombres.Add(nombre);
                    }

                    return nombres;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }

        public UsuarioDTO update(UsuarioDTO user)
        {
            try
            {
                sql = "UPDATE_USER";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_usuarios", user.IdUser);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@contrasena", user.Password);
                cmd.Parameters.AddWithValue("@id_roles", user.RolUser);
                cmd.ExecuteNonQuery();

                return readById(user.IdUser);                                        
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public int delete(int id)
        {
            try
            {
                sql = "DELETE_USER";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_usuarios", id);

                if (cmd.ExecuteNonQuery() > 0)
                    return id;
                else
                    return 0;
            }
            catch
            {
                return -1;
            }
            finally
            {
                con.Close();
            }
        }

        public void executeQuery(String sql)
        {
            if(con.State == ConnectionState.Open)
            con.Close();

            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sql;
            cmd.Connection = con;

            if (con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            con.Open();
        }       
    }
}
