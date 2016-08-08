using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SA_ID_Number.Models;
using SA_ID_Number_Services.BusinessLogic;

namespace SA_ID_Number.Controllers
{
    public class IdDocumentController : ApiController
    {
        // GET: api/IdDocument
        public void Get()
        {    
        }

        // GET: api/IdDocument/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/IdDocument
        [ResponseType(typeof(PersonVM))]
        public HttpResponseMessage Post([FromBody]PersonVM person)
        {
            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            person.IdNumber = southAfricaIdNumberServices.GenerateIdNumber(person.DateOfBirth, person.Gender);   

            return Request.CreateResponse(HttpStatusCode.Created, person);  
        }

        // PUT: api/IdDocument/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/IdDocument/5
        public void Delete(int id)
        {
        }
    }
}
