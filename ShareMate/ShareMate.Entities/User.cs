using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareMate.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] HashPassword { get; set; }

        List<int> FileId { get; } //сюда список айдишников доступных файлов из логики AccessLogic
    }
}
