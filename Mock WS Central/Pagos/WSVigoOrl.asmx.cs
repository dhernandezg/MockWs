using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace Mock_WS_Central.Pagos
{
    /// <summary>
    /// Descripción breve de WSVigoOrl
    /// </summary>
    [WebService(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSVigoOrl : IWSVigoOrlSoapBinding
    {
        [return: SoapElement("busqTransacMultReturn")]
        public ReceiveMoneyResponse busqTransacMult(RcvMnyCurrencyRequest peticion)
        {
            peticion.counterID = "I0211101VG";
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

        [return: SoapElement("busquedaTransacReturn")]
        public ReceiveMoneyResponse busquedaTransac(ReceiveMoneyRequest peticion)
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
