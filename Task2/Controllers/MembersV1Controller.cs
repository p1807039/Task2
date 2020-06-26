using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task2.Models;

namespace Task2.Controllers
{
    public class MembersV1Controller : ApiController
    {
        public class ProductsController : ApiController
        {
            Member[] members = new Member[]
            {
            new Member { Id = 1, Name = "Dennis" },
            new Member { Id = 2, Name = "Jin Wah" }
            };

            [HttpGet]
            [Route("api/v1/members")]
            public IHttpActionResult GetAllMembers()
            {
                List<Member> oneMember = new List<Member>();
                List<object> memberList = new List<object>();

                oneMember = members.ToList();

                if (oneMember == null)
                {
                    return NotFound();
                }
                else
                {
                    foreach (var member in oneMember)
                    {
                        memberList.Add(new
                        {
                            memberId = member.Id,
                            memberName = member.Name
                        });
                    }
                    return Ok(memberList);
                }
            }

            [HttpGet]
            [Route("api/v1/members/{id}")]
            //http://localhost:9000/api/v1/members/1
            public IHttpActionResult GetMember(int id)
            {
                var member = members.FirstOrDefault((p) => p.Id == id);
                if (member == null)
                {
                    return NotFound();
                }
                return Ok(member);
            }
        }
    }
}
