using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareMate.Entities
{
    public class Request
    {
        public int OwnerId { get; set; }
        public int FileId { get; set; }
        public int RequestId { get; set; }
    }
}
