using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiPlayerLeague
    { 
        public string get { get; set; }
        public ParametersLeague parameters { get; set; }
        public object[] errors { get; set; }
        public int results { get; set; }
        public Paging paging { get; set; }
        public Response[] response { get; set; }
    }

    public class ParametersLeague
    {
        public string league { get; set; }
        public string season { get; set; }
    }

   

}
