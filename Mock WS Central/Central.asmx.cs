using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace Mock_WS_Central
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://microsoft.com/webservices/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //Requerido para el ruteo de SOAP Action
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WsMockCentral : IWsMoneyGramTISoapBinding
    {
        [return: SoapElement("getAgentInformationReturn")]
        public AgentInfoResponse getAgentInformation(AgentInfoRequest informacionIN)
        {
            return new AgentInfoResponse() {};
        }

        [return: SoapElement("getInputFieldNamesReturn")]
        public string[] getInputFieldNames(string UID, string transaction)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("getTransactionNamesReturn")]
        public string[] getTransactionNames(string UID)
        {
            throw new NotImplementedException();
        }

        [return: SoapElement("sendRequestReturn")]
        public ResponseData sendRequest(RequestData request)
        {
            throw new NotImplementedException();
        }
    }
}
