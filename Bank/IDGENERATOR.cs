using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class IDGENERATOR
    {
        //acct id generator variables
        static int id = 01;
        string storeId;
        DateTime date = DateTime.Now;
       

        //This method uses the inputed date of birth to generate an account id
        public string generate()
        {
            string gid = DateTime.Now.ToString("yyyyMM");
            storeId = gid + ++id;
            //Console.Write(gid+ ++id);
            return storeId;
            
        }
        
    }
}
