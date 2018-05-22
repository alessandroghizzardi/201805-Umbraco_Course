using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace EmptyMvc.Controllers.api
{
    public class ExternalCheckController : ApiController
    {
        [System.Web.Http.HttpGet]
        public void TestVoid()
        {
            //Do some logic here
            System.Threading.Thread.Sleep(500);
        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage TestHttpResponseMessage()
        {
            //Do some logic here
            System.Threading.Thread.Sleep(500);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.Add("X-Demo", "True");
            
            return response;
        }

        [System.Web.Http.HttpGet]
        public ApiResponse TestComplexType()
        {
            //Do some logic here
            System.Threading.Thread.Sleep(500);

            ApiResponse response = new ApiResponse();
            response.Date = DateTime.Now;
            response.Name = "Alessandro";
            response.Surname = "Ghizzardi";
            response.SomeOtherProperty = "Loving WebApi";
            response.IsCorrect = true;

            return response;
        }
    }
}
