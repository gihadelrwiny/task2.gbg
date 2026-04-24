using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public Member(int memberid,string name)
        {
            MemberId = memberid;
            Name = name;
            BorrowedBooks = new List<Book>();
        }
    }
}
