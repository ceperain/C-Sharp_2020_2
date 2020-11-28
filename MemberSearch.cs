using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class MemberSearch
    {
        public static void PopUp()
        {
            MemberSearchForm form2 = new MemberSearchForm();
            form2.ShowDialog();
        }
    }
}
