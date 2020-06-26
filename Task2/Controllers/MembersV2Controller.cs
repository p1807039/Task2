using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Task2.Models;

namespace Task2.Controllers
{
    public class MembersV2Controller : ApiController
    {
        static readonly IMemberRepository repository = new MemberRepository();

        [HttpGet]
        [Route("api/v2/members")]
        public IEnumerable<Member> GetAllMembers()
        {
            return repository.GetAll();
        }

        [HttpGet]
        [Route("api/v2/members/{id:int:min(1)}", Name = "getMemberByIdv2")]
        public Member retrieveProductfromRepository(int id)
        {
            Member item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        [HttpPost]
        [Route("api/v2/members")]
        public HttpResponseMessage PostMember(Member item)
        {
            if (ModelState.IsValid)
            {
                item = repository.Add(item);
                var response = Request.CreateResponse<Member>(HttpStatusCode.Created, item);

                //Generate a link to the new product and set the Location header in the response.
                string url = Url.Link("getMemberByIdv2", new { id = item.Id });
                response.Headers.Location = new Uri(url);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [Route("api/v2/members/{id:int}")]
        public IHttpActionResult PutMember(int id, Member member)
        {
            member.Id = id;
            if (!repository.Update(member))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(new { message = "Updated member record" });
        }

        [HttpDelete]
        [Route("api/v2/members/delete/{id:int}")]
        public IHttpActionResult DeleteMember(int id)
        {
            Member item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);

            return Ok(new { message = "Deleted member record" });
        }
    }
}
