using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class SearchQueryManager
    {
        public static string makeSearchQuery(string table, string search, string keyword)
        {
            if (keyword == "")
            {
                return "select * from bookmanagement." + table + "; ";
            }
            else
            {
                if (search.Contains("MemberId") || search.Contains("BookRegisterNumber"))
                {
                    return "select * from bookmanagement." + table + " where " + search + "=" + keyword + ";";
                }
                else
                {
                    return "select * from bookmanagement." + table + " where " + search + " like '%" + keyword + "%';";
                }

            }
        }
    }
}
