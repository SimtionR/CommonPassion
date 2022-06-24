using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPassion_Backend.Data.Servicies.BlobService
{
    public class BlobInfo
    {

        public Stream Content { get; set; }
        public string ContentType { get; set; }

        public BlobInfo(Stream content, string contentType)
        {
            this.Content = content;
            this.ContentType = contentType;
        }

    }
}
