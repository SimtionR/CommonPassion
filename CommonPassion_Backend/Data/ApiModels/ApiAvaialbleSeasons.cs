using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.ApiModels
{
    public class ApiAvaialbleSeasons
    {
           public Paging paging { get; set; }
            public int[] response { get; set; }

        public class Parameters
        {
            public string team { get; set; }
        }
      }
    }

