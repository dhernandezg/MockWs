using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MockWebApi.Controllers
{
    public class ReactivacionIntermexController : ApiController
    {
        private string ReactivacionMex = "<soap:Envelope xmlns:soap = \"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:activarMtcnResponse xmlns:ns2 = \"http://ws.elektra.com/\"><response><resultado><codigo>C00000</codigo><mensaje>OPERACI?N EXITOSA</mensaje></resultado><uid>UID319104789420</uid></response></ns2:activarMtcnResponse></soap:Body></soap:Envelope>";
        public HttpResponseMessage Post() 
        {
            var stream = new StreamReader(HttpContext.Current.Request.InputStream);
            var request = stream.ReadToEnd();
            if (request.Contains("<activarMtcn")) 
            {
               return SetResponse(ReactivacionMex);
            }
            return SetResponse("Bad Request!");

        }
        private HttpResponseMessage SetResponse(string content)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(content, System.Text.Encoding.UTF8, "text/plain");
            return response;
        }
    }
}