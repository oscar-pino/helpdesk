using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelpDeskDAO;

namespace HelpDeskDAO
{
    public interface IDAO<T> where T : class
    {
        T create(T t);
        List<T> readAlls();
        T readById(int id);
        T update(T t);
        int delete(int id);
        void executeQuery(String sql);
    }
}
