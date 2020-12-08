using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Rent
    {
        public int MemberId { get; set; }//회원번호
        public int BookRegisterNumber { get; set; }
        public string Rent_Date { get; set; }
        public string Rent_Date_Last { get; set; }
    }
}
