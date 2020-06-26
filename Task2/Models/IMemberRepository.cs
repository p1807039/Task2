using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Models
{
    interface IMemberRepository
    {
        IEnumerable<Member> GetAll();
        Member Get(int id);
        Member Add(Member item);
        void Remove(int id);
        bool Update(Member item);
    }
}
