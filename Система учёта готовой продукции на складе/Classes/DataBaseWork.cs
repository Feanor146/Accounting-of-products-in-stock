using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Система_учёта_готовой_продукции_на_складе.Classes
{
    internal class DataBaseWork
    {
        public static DatabaseEntities Entities = new DatabaseEntities();   
        public static Users AutoUser = new Users();
    }
}
