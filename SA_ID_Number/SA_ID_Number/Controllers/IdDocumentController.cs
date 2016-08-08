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
        // GET: api/IdDocument/5
        public HttpResponseMessage Get(string id)
        { 
            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            bool isValidId = southAfricaIdNumberServices.ValidateIdNumber(id);
            var result = new Dictionary<String, bool>();
            result.Add("isValidId", isValidId);

            return Request.CreateResponse(HttpStatusCode.Created, result); 
        }

        // POST: api/IdDocument
        [ResponseType(typeof(PersonVM))]
        public HttpResponseMessage Post([FromBody]PersonVM person)
        {
            SouthAfricaIdDocument southAfricaIdNumberServices = new SouthAfricaIdDocument();
            person.IdNumber = southAfricaIdNumberServices.GenerateIdNumber(person.DateOfBirth, person.Gender);   

            return Request.CreateResponse(HttpStatusCode.Created, person);  
        }  
    }
}
