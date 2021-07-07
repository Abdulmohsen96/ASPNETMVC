using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UMS.Utility {
    public class ConnectionString {
        private static string connection = "Server=.;Database=UMM;Trusted_Connection=True;MultipleActiveResultSets=true";
        public static string getConnection { get => connection; }
    }
}
