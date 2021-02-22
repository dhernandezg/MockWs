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
    public class PagosIntermexController : ApiController
    {
        private string ConsultaMex = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:busqTxnXMtcnResponse xmlns:ns2=\"http://ws.elektra.com/\"><response><resultado><codigo>C00000</codigo><mensaje>OPERACIÓN EXITOSA</mensaje></resultado><uid>UID113513824086</uid><remesa><beneficiario><apellidoMaterno>LEON</apellidoMaterno><apellidoPaterno>GARCIA</apellidoPaterno><nombre>GUILLERMINA</nombre><folioIdentificacion></folioIdentificacion><tipoIdentificacion></tipoIdentificacion></beneficiario><datosMtcn><mtcn>xulWIvRZYII074csI59Waw</mtcn><monedaOrigen>USD</monedaOrigen><paisOrigen>USA</paisOrigen><estadoOrigen>ALABAMA</estadoOrigen><ciudadOrigen>BESSEMER</ciudadOrigen><monedaDestino>MXN</monedaDestino><paisDestino>MEXICO</paisDestino><estadoDestino>GUERRERO</estadoDestino><ciudadDestino>ACAPULCO</ciudadDestino><fechaEnvio>6/9/2019 12:00:00 AM</fechaEnvio><montoEnviado>N6ENgoJug3TJA0uWPa-A-A</montoEnviado><montoPago>Z4a-Qj9EbUTglPqNIJZP0Q</montoPago></datosMtcn><remitente><apellidoMaterno>FLORES</apellidoMaterno><apellidoPaterno>TORRES</apellidoPaterno><nombre>FIDELIA</nombre><telefono>000</telefono></remitente></remesa></response></ns2:busqTxnXMtcnResponse></soap:Body></soap:Envelope>";
        private string ConsultaLAM = "<soap:Envelope xmlns:soap = \"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:busqTxnXMtcnResponse xmlns:ns2 = \"http://ws.elektra.com/\"><response><resultado><codigo>C00000</codigo><mensaje>OPERACIÓN EXITOSA</mensaje></resultado><uid>UID035114716655</uid><remesa><beneficiario><apellidoMaterno></apellidoMaterno><apellidoPaterno>DUBON</apellidoPaterno><nombre>ROSA DELIA</nombre><folioIdentificacion>F939328</folioIdentificacion><tipoIdentificacion>PASSPORT</tipoIdentificacion></beneficiario><datosMtcn><mtcn>XZXklXCFKXkvKa39xAnKCA</mtcn><monedaOrigen>USD</monedaOrigen><paisOrigen>USA</paisOrigen><estadoOrigen>NORTH CAROLINA</estadoOrigen><ciudadOrigen>CHARLOTTE</ciudadOrigen><monedaDestino>HNL</monedaDestino><paisDestino>HONDURAS</paisDestino><estadoDestino>CORTES</estadoDestino><ciudadDestino>SAN PEDRO SULA</ciudadDestino><fechaEnvio>12/15/2019 12:00:00 AM</fechaEnvio><montoEnviado>qlPXRHJHXxJFu1OsIwu57A</montoEnviado><montoPago>z4_y6FYh6rgfQ5D7ewB-Fw</montoPago></datosMtcn><remitente><apellidoMaterno></apellidoMaterno><apellidoPaterno>DUBON</apellidoPaterno><nombre>MARIA ERLINDA</nombre><telefono>5041</telefono></remitente></remesa></response></ns2:busqTxnXMtcnResponse></soap:Body></soap:Envelope>";

        private string PagoMex = "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:pagarMtcnResponse xmlns:ns2=\"http://ws.elektra.com/\"><response><resultado><codigo>C00000</codigo><mensaje>OPERACIÓN EXITOSA</mensaje></resultado><uid>UID113513824106</uid></response></ns2:pagarMtcnResponse></soap:Body></soap:Envelope>";

        private string PagoLAM = "<soap:Envelope xmlns:soap = \"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:pagarMtcnResponse xmlns:ns2 = \"http://ws.elektra.com/\"><response><resultado><codigo>C00000</codigo><mensaje>OPERACIÓN EXITOSA</mensaje></resultado><uid>UID035114716657</uid></response></ns2:pagarMtcnResponse></soap:Body></soap:Envelope>";
        // POST api/PagosIntermex

        public HttpResponseMessage Post()
        {
            var stream = new StreamReader(HttpContext.Current.Request.InputStream);

            var raw = stream.ReadToEnd();
            if (raw.Contains("<idPais>1</idPais>"))
            {
                if (raw.Contains("busqTxnXMtcn"))
                    return SetResponse(ConsultaMex);
                else if (raw.Contains("pagarMtcn"))
                    return SetResponse(PagoMex);
                else
                    return SetResponse("Bad Request");
            }
            else 
            {
                if (raw.Contains("busqTxnXMtcn"))
                    return SetResponse(ConsultaLAM);
                else if (raw.Contains("pagarMtcn"))
                    return SetResponse(PagoLAM);
                else
                    return SetResponse("Bad Request");
            }
        }
        private HttpResponseMessage SetResponse(string content)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(content, System.Text.Encoding.UTF8, "text/plain");
            return response;
        }
    }
}