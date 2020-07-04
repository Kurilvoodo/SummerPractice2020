using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareMate.Entities
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }

    }
}
