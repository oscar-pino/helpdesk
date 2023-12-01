using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDeskDTO;
using HelpDeskDAO;
using System.Data;

namespace HelpDeskBO
{
    public class SdsBO
    {
        private SdsDAO sdsDAO = new SdsDAO();
        public SdsDTO create(SdsDTO sds)
        {
            return sdsDAO.create(sds);
        }

        public SdsDTO create_simple(SdsDTO sds)
        {
            return sdsDAO.create_simple(sds);
        }

        public List<SdsDTO> readAlls()
        {
            return sdsDAO.readAlls();
        }

        public List<SdsDTO> readAllsByCreatorUserAndState(String creador, int idEstado)
        {
            return sdsDAO.readAllsByCreatorUserAndState(creador, idEstado);
        }

        public SdsDTO readById(int id)
        {
            return sdsDAO.readById(id);
        }

        public SdsDTO update(SdsDTO sds)
        {
            return sdsDAO.update(sds);
        }

        public SdsDTO update_commitment_date(SdsDTO sds)
        {
            return sdsDAO.update_commitment_date(sds);
        }

        public int delete(int id)
        {
            return sdsDAO.delete(id);
        }

        public void executeQuery(String sql)
        {
            sdsDAO.executeQuery(sql);
        }
    }
}
