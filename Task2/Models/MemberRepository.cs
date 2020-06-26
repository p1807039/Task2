using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task2.Models
{
    public class MemberRepository : IMemberRepository
    {
        private List<Member> members = new List<Member>();
        private int _nextId = 1;

        public MemberRepository()
        {
            Add(new Member { Name = "Dennis", Hobby = "Movies" });
            Add(new Member { Name = "Jin Wah", Hobby = "Games"});
        }

        public IEnumerable<Member> GetAll()
        {
            return members;
        }

        public Member Get(int id)
        {
            return members.Find(m => m.Id == id);
        }

        public Member Add(Member item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            members.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            members.RemoveAll(p => p.Id == id);
        }

        public bool Update(Member item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = members.FindIndex(m => m.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            members.RemoveAt(index);
            members.Add(item);
            return true;
        }
    }
}
        