using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDeskDTO;
using HelpDeskDAO;
using System.Data.SqlClient;
using System.Data;

namespace HelpDeskDAO
{
    public class SdsDAO : IDAO<SdsDTO>
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private String sql;
        private SdsDTO sdsDTO;
        private List<SdsDTO> sdssDTO;

        public SdsDAO() {
            con = DAO.Instancia;
        }

        public SdsDTO create(SdsDTO sds)
        {

            try
            {
                sql = "CREATE_SDS";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_estados", sds.Estado);
                cmd.Parameters.AddWithValue("@asunto", sds.Asunto);
                cmd.Parameters.AddWithValue("@detalle", sds.Detalle);
                cmd.ExecuteNonQuery();

                return readById(sds.IdSds);                
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

        public SdsDTO create_simple(SdsDTO sds)
        {

            try
            {
                sql = "CREATE_SIMPLE_SDS";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_estados", sds.Estado);
                cmd.Parameters.AddWithValue("@asunto", sds.Asunto);
                cmd.Parameters.AddWithValue("@detalle", sds.Detalle);
                cmd.Parameters.AddWithValue("@nom_usu_crea", sds.Nom_Usu_Crea);
                cmd.ExecuteNonQuery();

                return sds;
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

        public List<SdsDTO> readAlls()
        {
            List<SdsDTO> listaSds;

            try
            {
                sql = "READ_SDS";
                executeQuery(sql);
                listaSds = new List<SdsDTO>();
                dr = cmd.ExecuteReader();
                
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        sdsDTO = new SdsDTO();
                        sdsDTO.IdSds = Int32.Parse(dr["id_sds"].ToString());
                        sdsDTO.Estado = (ESTADOS) dr["id_estados"];
                        sdsDTO.Asunto = dr["asunto"].ToString();
                        sdsDTO.Detalle = dr["detalle"].ToString();
                        sdsDTO.Fec_Crea = DateTime.Parse( dr["fec_crea"].ToString());
                        sdsDTO.Fec_Cierre = DateTime.Parse(dr["fec_cierre"].ToString());
                        sdsDTO.Fec_Comp = DateTime.Parse(dr["fec_comp"].ToString());
                        sdsDTO.Nom_Usu_Crea = dr["nom_usu_crea"].ToString();
                        sdsDTO.Nom_Usu_Resp = dr["nom_usu_resp"].ToString();

                        sdssDTO.Add(sdsDTO);
                    }
                    return sdssDTO;
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

        public List<SdsDTO> readAllsByCreatorUserAndState(String creador, int idEstado)
        {
            List<SdsDTO> listaSds;

            try
            {
                sql = "READ_SDS_BY_CREADOR_AND_STATE";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@nom_usu_crea", creador);
                cmd.Parameters.AddWithValue("@id_estados", idEstado);
                listaSds = new List<SdsDTO>();
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    sdssDTO = new List<SdsDTO>();

                    while (dr.Read())
                    {
                        sdsDTO = new SdsDTO();
                        sdsDTO.IdSds = Int32.Parse(dr["id_sds"].ToString());
                        sdsDTO.Asunto = dr["asunto"].ToString();
                        sdsDTO.Fec_Crea = getFecha(dr["fec_crea"].ToString());
                        sdsDTO.Estado = (ESTADOS)dr["id_estados"];
                        sdsDTO.Fec_Comp = null;//getFecha(dr["fec_comp"].ToString());                        
                        sdsDTO.Nom_Usu_Crea = dr["nom_usu_crea"].ToString();
                        sdsDTO.Nom_Usu_Resp = dr["nom_usu_resp"].ToString();

                        sdssDTO.Add(sdsDTO);
                    }
                    return sdssDTO;
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

        public SdsDTO readById(int id)
        {
            try
            {
                sql = "READ_SDS_BY_ID";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_sds", id);
                dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    if (dr.Read())
                    {
                        sdsDTO = new SdsDTO();
                        sdsDTO.IdSds = Int32.Parse(dr["id_sds"].ToString());
                        sdsDTO.Estado = (ESTADOS)dr["id_estados"];
                        sdsDTO.Asunto = dr["asunto"].ToString();
                        sdsDTO.Detalle = dr["detalle"].ToString();
                        sdsDTO.Fec_Crea = getFecha(dr["fec_crea"].ToString());
                        sdsDTO.Fec_Cierre = getFecha(dr["fec_cierre"].ToString());
                        sdsDTO.Fec_Comp = getFecha(dr["fec_comp"].ToString());
                        sdsDTO.Nom_Usu_Crea = dr["nom_usu_crea"].ToString();
                        sdsDTO.Nom_Usu_Resp = dr["nom_usu_resp"].ToString();
                    }

                    return sdsDTO;
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

        public SdsDTO update(SdsDTO sds)
        {
            try
            {
                sql = "UPDATE_SDS";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_estados", sds.Estado);
                cmd.Parameters.AddWithValue("@asunto", sds.Asunto);
                cmd.Parameters.AddWithValue("@detalle", sds.Detalle);
                cmd.Parameters.AddWithValue("@fec_crea", sds.Estado);
                cmd.Parameters.AddWithValue("@fec_cierre", sds.Asunto);
                cmd.Parameters.AddWithValue("@fec_comp", sds.Detalle);
                cmd.Parameters.AddWithValue("@nom_usu_crea", sds.Asunto);
                cmd.Parameters.AddWithValue("@nom_usu_resp", sds.Detalle);
                cmd.ExecuteNonQuery();

                return readById(sds.IdSds);
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

        public SdsDTO update_commitment_date(SdsDTO sds)
        {
            try
            {
                sql = "UPDATE_COMMITMENT_DATE_SDS";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_sds", sds.IdSds);
                cmd.Parameters.AddWithValue("@fec_crea", sds.Estado);
                cmd.ExecuteNonQuery();

                return readById(sds.IdSds);
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
                sql = "DELETE_SDS";
                executeQuery(sql);
                cmd.Parameters.AddWithValue("@id_sds", id);

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

        private DateTime getFecha(String fecha)
        {

            DateTime dt;
            String[] date;
            String[] time;

            try
            {

                date = fecha.Substring(0, 10).Split('-');
                time = fecha.Split(' ')[1].Split(':');

                dt = new DateTime(Int32.Parse(date.GetValue(2).ToString()), Int32.Parse(date.GetValue(1).ToString()), Int32.Parse(date.GetValue(0).ToString()),
                    Int32.Parse(time.GetValue(0).ToString()), Int32.Parse(time.GetValue(1).ToString()), Int32.Parse(time.GetValue(2).ToString()));


                return dt;

            }
            catch (Exception e)
            {

                Console.WriteLine("error al crear un datetime!\n" + e.Message);
            }

            return DateTime.MinValue;
        }
    }
}
