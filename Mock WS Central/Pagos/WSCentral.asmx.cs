using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

namespace Mock_WS_Central.Pagos
{
    /// <summary>
    /// Descripción breve de MockWSVigoORL
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class MockWSVigoORL : System.Web.Services.WebService
    {

        [WebMethod]
        public void WSVigoOrl()
        {
            HttpContext.Current.Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"> <soapenv:Body> <busquedaTransacResponse soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"> <busquedaTransacReturn href=\"#id0\" /> </busquedaTransacResponse> <multiRef id=\"id0\" soapenc:root=\"0\" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xsi:type=\"ns1:ReceiveMoneyResponse\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:ns1=\"urn:RR\"> <canal xsi:type=\"xsd:string\">1</canal> <consume xsi:type=\"xsd:int\">0</consume> <data xsi:type=\"soapenc:Array\" soapenc:arrayType=\"ns1:ReceiveMoneyData[1]\" xmlns:ns2=\"http://www.w3.org/2002/12/soap-encoding\"> <item href=\"#id1\" /> </data> <idFlujo xsi:type=\"xsd:string\">UID211112008588</idFlujo> <msj xsi:type=\"xsd:string\">Ok</msj> <msjEnvio xsi:type=\"xsd:string\"></msjEnvio> <neg xsi:type=\"xsd:string\">VIGO</neg> <numMatches xsi:type=\"xsd:int\">1</numMatches> <oper xsi:type=\"xsd:string\">81040</oper> <pais xsi:type=\"xsd:string\">1</pais> <res xsi:type=\"xsd:int\">1</res> <suc xsi:type=\"xsd:string\">2111</suc> <uid xsi:type=\"xsd:string\">UID211112008590</uid> </multiRef> <multiRef id=\"id1\" soapenc:root=\"0\" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xsi:type=\"ns3:ReceiveMoneyData\" xmlns:ns3=\"urn:RR\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\"> <apMatBen xsi:type=\"xsd:string\">DE LOS SANTOS</apMatBen> <apMatRem xsi:type=\"xsd:string\">RINCONCILLO</apMatRem> <apPatBen xsi:type=\"xsd:string\">RINCONCILLO</apPatBen> <apPatRem xsi:type=\"xsd:string\">GALVAN</apPatRem> <cargos xsi:type=\"xsd:double\">10.0</cargos> <cdadBen xsi:type=\"xsd:string\">COMONFORT</cdadBen> <cdadRem xsi:type=\"xsd:string\">RICHARSOND</cdadRem> <cpBen xsi:type=\"xsd:string\"></cpBen> <cpRem xsi:type=\"xsd:string\">75080</cpRem> <cta xsi:type=\"xsd:string\"></cta> <dirBen xsi:type=\"xsd:string\"></dirBen> <dirRem xsi:type=\"xsd:string\">923 SAN PAUL DR</dirRem> <edoBen xsi:type=\"xsd:string\">GUANAJUATO</edoBen> <edoRem xsi:type=\"xsd:string\">TX</edoRem> <fecEnvio xsi:type=\"xsd:string\">06-08-19</fecEnvio> <horaEnv xsi:type=\"xsd:string\">0659P EDT</horaEnv> <monKeyTransf xsi:type=\"xsd:string\">3624003110</monKeyTransf> <montoBruto xsi:type=\"xsd:double\">1010.0</montoBruto> <montoPay xsi:type=\"xsd:double\">19808.0</montoPay> <montoPrinc xsi:type=\"xsd:double\">1000.0</montoPrinc> <mtcn xsi:type=\"xsd:string\">9725698160</mtcn> <newMtcn xsi:type=\"xsd:string\">1915989725698160</newMtcn> <nomBen xsi:type=\"xsd:string\">EULALIA</nomBen> <nomRem xsi:type=\"xsd:string\">JOSE JUVENTINO</nomRem> <paisCodeBen xsi:type=\"xsd:string\">MX</paisCodeBen> <paisCodeRem xsi:type=\"xsd:string\">US</paisCodeRem> <paisMonBen xsi:type=\"xsd:string\">MXN</paisMonBen> <paisMonRem xsi:type=\"xsd:string\">USD</paisMonRem> <status xsi:type=\"xsd:string\">LISTO PARA PAGAR</status> <telBen xsi:type=\"xsd:string\"></telBen> <telRem xsi:type=\"xsd:string\">2142294067</telRem> </multiRef> </soapenv:Body></soapenv:Envelope>");

        }
        [WebMethod]
        public void validaRestriccionesCte()
        {
            HttpContext.Current.Response.Write("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:validaRestriccionesCteResponse xmlns:ns2=\"http://Controller.Ws.Elektra.Com/\"><response><bloqReq></bloqReq><accionesReq></accionesReq><clienteUnico><idPais>0</idPais><idCanal>0</idCanal><idSucursal>0</idSucursal><idFolio>0</idFolio></clienteUnico><resultado><codResp>C00000</codResp><msgResp>El cliente no tiene acciones ni bloqueos pendientes.</msgResp></resultado><uid>UID462405394120</uid></response></ns2:validaRestriccionesCteResponse></soap:Body></soap:Envelope>");
        }

        [WebMethod]
        public void bsqListaOFAC()
        {
            HttpContext.Current.Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><ns1:BsqListaOFACResponse xmlns=\"http://dineroexpress.elektra.com/BusquedaDex/ws/schemas\" xmlns:ns1=\"http://dineroexpress.elektra.com/BusquedaDex/ws/schemas\"><ns1:uid>UID211112020578</ns1:uid><ns1:bloqueoOFAC>0</ns1:bloqueoOFAC><ns1:mensajeLista>El cliente puede operar</ns1:mensajeLista><ns1:codigoMensaje>E</ns1:codigoMensaje><ns1:mensaje>OPERACION EXITOSA</ns1:mensaje></ns1:BsqListaOFACResponse></soapenv:Body></soapenv:Envelope>");
        }
        [WebMethod]
        public void bsqTransxFolio()
        {
            HttpContext.Current.Response.Write("{\"agenteId\":1,\"paisId\":1,\"subsidiariaId\":1,\"sucursalId\":451,\"uid\":\"UID213814093519\",\"tipoOperacion\":2,\"transferenciaId\":\"72144490854\",\"usuarioId\":\"T332671\"}");
        }

        [WebMethod]
        public void solicitarTokenRequest()
        {
            HttpContext.Current.Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><solicitaTokenResponseDTO><uid>UID213814093521</uid><codigoSalida>E</codigoSalida><mensajeSalida>OPERACION EXITOSA</mensajeSalida><token>A247F2E9EC21F4B2AC776EA5B41881776577F863</token></solicitaTokenResponseDTO>");
        }
        [WebMethod]
        public void ConsultaMTCNOrlandi()
        {
            HttpContext.Current.Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><soapenv:Body><busquedaTransacResponse soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><busquedaTransacReturn href=\"#id0\" /></busquedaTransacResponse><multiRef id=\"id0\" soapenc:root=\"0\" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xsi:type=\"ns1:ReceiveMoneyResponse\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:ns1=\"urn:RR\"><canal xsi:type=\"xsd:string\">1</canal><consume xsi:type=\"xsd:int\">0</consume><data xsi:type=\"soapenc:Array\" soapenc:arrayType=\"ns1:ReceiveMoneyData[1]\" xmlns:ns2=\"http://www.w3.org/2002/12/soap-encoding\"><item href=\"#id1\" /></data><idFlujo xsi:type=\"xsd:string\">UID113513826275</idFlujo><msj xsi:type=\"xsd:string\">Ok</msj><msjEnvio xsi:type=\"xsd:string\"></msjEnvio><neg xsi:type=\"xsd:string\">ORL</neg><numMatches xsi:type=\"xsd:int\">1</numMatches><oper xsi:type=\"xsd:string\">730200</oper><pais xsi:type=\"xsd:string\">1</pais><res xsi:type=\"xsd:int\">1</res><suc xsi:type=\"xsd:string\">1135</suc><uid xsi:type=\"xsd:string\">UID113513826276</uid></multiRef><multiRef id=\"id1\" soapenc:root=\"0\" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xsi:type=\"ns3:ReceiveMoneyData\" xmlns:ns3=\"urn:RR\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\"><apMatBen xsi:type=\"xsd:string\">RAMOS</apMatBen><apMatRem xsi:type=\"xsd:string\">RAMOS</apMatRem><apPatBen xsi:type=\"xsd:string\">SANCHEZ</apPatBen><apPatRem xsi:type=\"xsd:string\">SANCHEZ</apPatRem><cargos xsi:type=\"xsd:double\">10.0</cargos><cdadBen xsi:type=\"xsd:string\">ACAPULCO</cdadBen><cdadRem xsi:type=\"xsd:string\">GLEN ELLYN</cdadRem><cpBen xsi:type=\"xsd:string\"></cpBen><cpRem xsi:type=\"xsd:string\">60137</cpRem><cta xsi:type=\"xsd:string\"></cta><dirBen xsi:type=\"xsd:string\"></dirBen><dirRem xsi:type=\"xsd:string\">145 SURREY DR APT S</dirRem><edoBen xsi:type=\"xsd:string\">GUERRERO</edoBen><edoRem xsi:type=\"xsd:string\">IL</edoRem><fecEnvio xsi:type=\"xsd:string\">06-09-19</fecEnvio><horaEnv xsi:type=\"xsd:string\">0917A EDT</horaEnv><monKeyTransf xsi:type=\"xsd:string\">3623936810</monKeyTransf><montoBruto xsi:type=\"xsd:double\">210.0</montoBruto><montoPay xsi:type=\"xsd:double\">3936.0</montoPay><montoPrinc xsi:type=\"xsd:double\">200.0</montoPrinc><mtcn xsi:type=\"xsd:string\">7084260137</mtcn><newMtcn xsi:type=\"xsd:string\">1916087084260137</newMtcn><nomBen xsi:type=\"xsd:string\">MAYRA</nomBen><nomRem xsi:type=\"xsd:string\">LAURA</nomRem><paisCodeBen xsi:type=\"xsd:string\">MX</paisCodeBen><paisCodeRem xsi:type=\"xsd:string\">US</paisCodeRem><paisMonBen xsi:type=\"xsd:string\">MXN</paisMonBen><paisMonRem xsi:type=\"xsd:string\">USD</paisMonRem><status xsi:type=\"xsd:string\">LISTO PARA PAGAR</status><telBen xsi:type=\"xsd:string\"></telBen><telRem xsi:type=\"xsd:string\">6309949363</telRem></multiRef></soapenv:Body></soapenv:Envelope>");
        }

        [WebMethod]
        public void ConsultarAgenteMG()
        {
            HttpContext.Current.Response.Write("<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><ns2:consultarAgenteResponse xmlns:ns2=\"http://ws.elektra.com/\"><response><respuesta><codigo>C00000</codigo><mensaje>Datos encontrados.</mensaje></respuesta><credencial><agentID>VQG1fhySEp08a8p1HBfCTA</agentID><agentSequence>61HNiUWEjFXSivoytmSKWQ</agentSequence><token>eYRmfSc7BfQy-UkluGbpDQ</token></credencial></response></ns2:consultarAgenteResponse></soap:Body></soap:Envelope>");
        }

        [WebMethod]
        public void PagosMG()
        {
            HttpContext.Current.Response.Write("<?xml version=\"1.0\" encoding=\"utf-16\"?><soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"> <soap:Body> <a1:consultarMtcn xmlns:a1=\"http://ws.elektra.com/\"> <request> <uid>UID113513829673</uid> <sucursal> <idPais>1</idPais> <idCanal>1</idCanal> <idSucursal>1135</idSucursal> <idOperador>273562</idOperador> <noEstacion>WS_CAJA04</noEstacion> <ipOrigen /> <tokenSucursal /> </sucursal> <datosRemesa> <mtcn>W7Q5uK4OWdGn_bAgy6xOUg</mtcn> </datosRemesa> <datosSocio> <idNegocio>MG</idNegocio> <credencial> <agente>VQG1fhySEp08a8p1HBfCTA</agente> <secuencia>61HNiUWEjFXSivoytmSKWQ</secuencia> <token>eYRmfSc7BfQy-UkluGbpDQ</token> </credencial> </datosSocio> </request> </a1:consultarMtcn> </soap:Body></soap:Envelope>");
        }
    }
}
