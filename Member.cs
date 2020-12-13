using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Member
    {

        public int MemberId { get; set; }//회원번호
        public string MemberName { get; set; }//이름
        public string MemberPhoneNumber { get; set; }//전화번호
        public string MemberState { get; set; } //상태 [정상|연체중|대출중지]
        public string MemberAdress { get; set; } // 주소
        public string MemberMail { get; set; } //이메일
        public string MemberJoined { get; set; } //등록일

        
    }
}
