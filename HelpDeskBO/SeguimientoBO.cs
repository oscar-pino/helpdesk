using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDeskDTO;
using HelpDeskDAO;

namespace HelpDeskBO
{
    public class SeguimientoBO
    {
        private SeguimientoDAO seguimientoDAO = new SeguimientoDAO();
        public SeguimientoDTO create(SeguimientoDTO seguimiento)
        {
            return seguimientoDAO.create(seguimiento);
        }
        public List<SeguimientoDTO> readAlls()
        {
            return seguimientoDAO.readAlls();
        }
        public SeguimientoDTO readById(int id)
        {
            return seguimientoDAO.readById(id);
        }
        public SeguimientoDTO update(SeguimientoDTO seguimiento)
        {
            return seguimientoDAO.update(seguimiento);
        }
        public int delete(int id)
        {
            return seguimientoDAO.delete(id);
        }
        public void executeQuery(String sql)
        {
            seguimientoDAO.executeQuery(sql);
        }
    }
}
