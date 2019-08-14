using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Mock_WS_Central.Pagos
{
    /// <summary>
    /// Descripción breve de WSVigoOrl
    /// </summary>
    //[WebService(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.SoapAction)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSVigoOrl : IWSVigoOrlSoapBinding
    {
        [return: SoapElement("busqTransacMultReturn")]
        public ReceiveMoneyResponse busqTransacMult(RcvMnyCurrencyRequest peticion)
        {
            return new ReceiveMoneyResponse()
            {
                canal = peticion.canal,
                pais = peticion.pais,
                suc = peticion.suc,
                consume = 0,
                idFlujo = peticion.idFlujo,
                msj = "Ok",
                neg = peticion.neg,
                numMatches = 1,
                oper = peticion.oper,
                res = 1,
                uid = peticion.uid,
                data = new ReceiveMoneyData[]
                {
                    new ReceiveMoneyData()
                    {
                        apMatBen = "PEREZ",
                        apMatRem = "GARCIA",
                        apPatBen = "LOPEZ",
                        apPatRem = "HERNANDEZ",
                        cargos = 10.0,
                        cdadBen = "COMONFORT",
                        cdadRem = "RICHARSOND",
                        cpBen = "",
                        cpRem = "75080",
                        cta = "",
                        dirBen = "",
                        dirRem = "923 SAN PAUL DR",
                        edoBen = "CDMX",
                        edoRem = "TX",
                        fecEnvio = "06-08-19",
                        horaEnv = "0659P EDT",
                        monKeyTransf = "3624003110",
                        montoBruto = 1010.0,
                        montoPay = 19808.0,
                        montoPrinc = 1000.0,
                        mtcn = peticion.mtcn,
                        newMtcn = "191598"+peticion.mtcn,
                        nomBen = "JUAN",
                        nomRem = "DANIEL",
                        paisCodeBen = "MX",
                        paisCodeRem = "US",
                        paisMonBen = "MXN",
                        paisMonRem = "USD",
                        status = "LISTO PARA PAGAR",
                        telBen = "",
                        telRem = "2211584297",
                    }
                }
            };
        }

        //[return: SoapElement("busquedaTransacReturn")]
        public void busquedaTransac(ReceiveMoneyRequest peticion)
        {
            HttpContext.Current.Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"> <soapenv:Body> <busquedaTransacResponse soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"> <busquedaTransacReturn href=\"#id0\" /> </busquedaTransacResponse> <multiRef id=\"id0\" soapenc:root=\"0\" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xsi:type=\"ns1:ReceiveMoneyResponse\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:ns1=\"urn:RR\"> <canal xsi:type=\"xsd:string\">1</canal> <consume xsi:type=\"xsd:int\">0</consume> <data xsi:type=\"soapenc:Array\" soapenc:arrayType=\"ns1:ReceiveMoneyData[1]\" xmlns:ns2=\"http://www.w3.org/2002/12/soap-encoding\"> <item href=\"#id1\" /> </data> <idFlujo xsi:type=\"xsd:string\">UID211112008588</idFlujo> <msj xsi:type=\"xsd:string\">Ok</msj> <msjEnvio xsi:type=\"xsd:string\"></msjEnvio> <neg xsi:type=\"xsd:string\">VIGO</neg> <numMatches xsi:type=\"xsd:int\">1</numMatches> <oper xsi:type=\"xsd:string\">81040</oper> <pais xsi:type=\"xsd:string\">1</pais> <res xsi:type=\"xsd:int\">1</res> <suc xsi:type=\"xsd:string\">2111</suc> <uid xsi:type=\"xsd:string\">UID211112008590</uid> </multiRef> <multiRef id=\"id1\" soapenc:root=\"0\" soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xsi:type=\"ns3:ReceiveMoneyData\" xmlns:ns3=\"urn:RR\" xmlns:soapenc=\"http://schemas.xmlsoap.org/soap/encoding/\"> <apMatBen xsi:type=\"xsd:string\">DE LOS SANTOS</apMatBen> <apMatRem xsi:type=\"xsd:string\">RINCONCILLO</apMatRem> <apPatBen xsi:type=\"xsd:string\">RINCONCILLO</apPatBen> <apPatRem xsi:type=\"xsd:string\">GALVAN</apPatRem> <cargos xsi:type=\"xsd:double\">10.0</cargos> <cdadBen xsi:type=\"xsd:string\">COMONFORT</cdadBen> <cdadRem xsi:type=\"xsd:string\">RICHARSOND</cdadRem> <cpBen xsi:type=\"xsd:string\"></cpBen> <cpRem xsi:type=\"xsd:string\">75080</cpRem> <cta xsi:type=\"xsd:string\"></cta> <dirBen xsi:type=\"xsd:string\"></dirBen> <dirRem xsi:type=\"xsd:string\">923 SAN PAUL DR</dirRem> <edoBen xsi:type=\"xsd:string\">GUANAJUATO</edoBen> <edoRem xsi:type=\"xsd:string\">TX</edoRem> <fecEnvio xsi:type=\"xsd:string\">06-08-19</fecEnvio> <horaEnv xsi:type=\"xsd:string\">0659P EDT</horaEnv> <monKeyTransf xsi:type=\"xsd:string\">3624003110</monKeyTransf> <montoBruto xsi:type=\"xsd:double\">1010.0</montoBruto> <montoPay xsi:type=\"xsd:double\">19808.0</montoPay> <montoPrinc xsi:type=\"xsd:double\">1000.0</montoPrinc> <mtcn xsi:type=\"xsd:string\">9725698160</mtcn> <newMtcn xsi:type=\"xsd:string\">1915989725698160</newMtcn> <nomBen xsi:type=\"xsd:string\">EULALIA</nomBen> <nomRem xsi:type=\"xsd:string\">JOSE JUVENTINO</nomRem> <paisCodeBen xsi:type=\"xsd:string\">MX</paisCodeBen> <paisCodeRem xsi:type=\"xsd:string\">US</paisCodeRem> <paisMonBen xsi:type=\"xsd:string\">MXN</paisMonBen> <paisMonRem xsi:type=\"xsd:string\">USD</paisMonRem> <status xsi:type=\"xsd:string\">LISTO PARA PAGAR</status> <telBen xsi:type=\"xsd:string\"></telBen> <telRem xsi:type=\"xsd:string\">2142294067</telRem> </multiRef> </soapenv:Body></soapenv:Envelope>");
        }

        [return: SoapElement("pagaTransacReturn")]
        public ReceiverPayResponse pagaTransac(ReceiverPayRequest peticion)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("pagaTransacLAMReturn")]
        public ReceiverPayResponse pagaTransacLAM(RcvrPayLAMRequest peticion)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("pagaTransacMEXReturn")]
        public ReceiverPayResponse pagaTransacMEX(RcvrPayMEXRequest peticion)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("pagaTransacPANReturn")]
        public ReceiverPayResponse pagaTransacPAN(RcvrPayPANRequest peticion)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("pagaTransacPERReturn")]
        public ReceiverPayResponse pagaTransacPER(RcvrPayPERRequest peticion)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("pagoStatusReturn")]
        public PayStatusResponse pagoStatus(string uid, string pais, string canal, string suc, string oper, string neg, string mtcn, string counterId, string idioma)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("selectTransacReturn")]
        public ReceiveSelectResponse selectTransac(string neg, string monKeyTransf, string pais, string canal, string suc, string oper, string uid, string counterID, string idFlujo, string idioma)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("selectTransacMultReturn")]
        public ReceiveSelectResponse selectTransacMult(string neg, string monKeyTransf, string mon, string pais, string canal, string suc, string oper, string uid, string counterID, string idFlujo, string idioma)
        {
            throw new NotImplementedException();
        }
    }
}
