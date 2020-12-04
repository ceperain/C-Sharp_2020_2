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

        public static string searchQuery(string keyword, string search)
        {
            if(keyword == "")
            {
                return "select * bookmanagement.members;";
            }
            else
            {
                return "select * bookmanagement.members" + search + "=" + keyword + ";";
            }
            
        }
    }
}
