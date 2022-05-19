using etaxproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etaxproject.Interface
{
    
    public interface Interface1
    {
        object Login(string UserName,string Password);
       
    }
    public class login : Interface1
    {
        projecttEntities3 DB = new projecttEntities3();
        public object Login(string UserName,string Password)
        {
            var log= DB.tbl_UserMaster.Where(x => x.UserName.Equals(UserName) && x.Password.Equals(Password)).FirstOrDefault();
            return log;
        }
    }
}
