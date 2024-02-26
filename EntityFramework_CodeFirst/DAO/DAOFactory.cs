﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_CodeFirst.DAO
{
    public class DAOFactory
    {
        public static IDAOManager createDAOManager()
        {
            return new DAOManagerImpl();
        }
    }
}
