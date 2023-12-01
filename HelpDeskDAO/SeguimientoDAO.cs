using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using HelpDeskDTO;
using System.Data;

namespace HelpDeskDAO
{
    public class SeguimientoDAO : IDAO<SeguimientoDTO>
    {
        private SqlConnection con;
        private SdsDAO sdsDAO;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private String sql;
        private List<SeguimientoDTO> seguimientosDTO;
        private SeguimientoDTO seguimientoDTO;

         public SeguimientoDAO() {

             con = DAO.Instancia;
             sdsDAO = new SdsDAO();
         }

         public SeguimientoDTO create(SeguimientoDTO seguimiento) {

             try
             {
                 sql = "CREATE_SEGUIMIENTO";
                 executeQuery(sql);
                 cmd.Parameters.AddWithValue("@id_sds", seguimiento.SDS.IdSds);
                 cmd.Parameters.AddWithValue("@fec_seg", seguimiento.Fec_Seg);
                 cmd.Parameters.AddWithValue("@detalle", seguimiento.Detalle);
                 cmd.Parameters.AddWithValue("@nom_usu_seg", seguimiento.Nom_Usu_Seg);
                 cmd.ExecuteNonQuery();

                 return readById(seguimiento.IdSeg);
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
         public List<SeguimientoDTO> readAlls() {

             try
             {
                 seguimientosDTO = new List<SeguimientoDTO>();
                 sql = "READ_SEGUIMIENTOS";
                 executeQuery(sql);
                 dr = cmd.ExecuteReader();

                 if (dr != null) { 
                 
                    while(dr.Read()){

                        seguimientoDTO = new SeguimientoDTO();
                        seguimientoDTO.IdSeg = Int32.Parse(dr["id_seg"].ToString());
                        seguimientoDTO.SDS = sdsDAO.readById(Int32.Parse(dr["id_sds"].ToString()));
                        seguimientoDTO.Detalle = dr["detalle"].ToString();
                        seguimientoDTO.Fec_Seg = DateTime.Parse(dr["fec_seg"].ToString());
                        seguimientoDTO.Nom_Usu_Seg = dr["nom_usu_seg"].ToString();

                        seguimientosDTO.Add(seguimientoDTO);
                    }

                    return seguimientosDTO;
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
         public SeguimientoDTO readById(int id) {

             try
             {
                 sql = "READ_SEGUIMIENTO_BY_ID";
                 executeQuery(sql);
                 cmd.Parameters.AddWithValue("@id_seg", id);
                 dr = cmd.ExecuteReader();

                 if (dr != null)
                 {
                     if (dr.Read())
                     {

                         seguimientoDTO = new SeguimientoDTO();
                         seguimientoDTO.IdSeg = Int32.Parse(dr["id_seg"].ToString());
                         seguimientoDTO.SDS = sdsDAO.readById(Int32.Parse(dr["id_sds"].ToString()));
                         seguimientoDTO.Detalle = dr["detalle"].ToString();
                         seguimientoDTO.Fec_Seg = DateTime.Parse(dr["fec_seg"].ToString());
                         seguimientoDTO.Nom_Usu_Seg = dr["nom_usu_seg"].ToString();                         

                     }

                     return seguimientoDTO;
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
         public SeguimientoDTO update(SeguimientoDTO seguimiento) {

             try
             {
                 sql = "UPDATE_SEGUIMIENTO";
                 executeQuery(sql);
                 cmd.Parameters.AddWithValue("@id_sds", seguimiento.SDS.IdSds);
                 cmd.Parameters.AddWithValue("@fec_seg", seguimiento.Fec_Seg);
                 cmd.Parameters.AddWithValue("@detalle", seguimiento.Detalle);
                 cmd.Parameters.AddWithValue("@nom_usu_seg", seguimiento.Nom_Usu_Seg);
                 cmd.Parameters.AddWithValue("@id_seg", seguimiento.IdSeg);
                 cmd.ExecuteNonQuery();

                 return readById(seguimiento.IdSeg);                 
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

         public int delete(int id) {

             try
             {
                 sql = "DELETE_SEGUIMIENTO";
                 executeQuery(sql);                 
                 cmd.Parameters.AddWithValue("@id_seg", seguimientoDTO.IdSeg);

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
             if (con.State == ConnectionState.Open)
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
