using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MockWebApi.Controllers
{
    /// <summary>
    /// Controlador de servicios mock
    /// </summary>
    public class CentralController : ApiController
    {
        /// <summary>
        /// Metodo de obtencion de respuestas mock
        /// </summary>
        /// <param name="service">Servicio a realizar mock</param>
        public IHttpActionResult Get(string service)
        {
            MockWs(service);
            return Ok();
        }

        /// <summary>
        /// Realiza el proceso mock para cada peticion
        /// </summary>
        /// <param name="service">Servicio a hacer mock</param>
        private void MockWs(string service)
        {
            var data = HttpContext.Current.Request.Params.AllKeys.Where(k => HttpContext.Current.Request.Params[k] == "2");
            if (!File.Exists(ConfigFile))
            {
                throw new FileNotFoundException("El archivo de configuracion global no existe");
            }
            var config = Deserialize<ConfigRoutes>(XDocument.Load(ConfigFile).ToString())
                .DinamycMock.Where(m => string.CompareOrdinal(service, m.PartialPath) == 0).FirstOrDefault();

            if (config != null)
            {
                string fileResp = AppDomain.CurrentDomain.BaseDirectory + @"Response\" + config.Response.File;
                if (!File.Exists(fileResp))
                {
                    throw new FileNotFoundException("El archivo de respuesta no existe:" + fileResp);
                }
                SetResponse(FilterMockResponse(fileResp));
                UpdateContentType(config.Response.ContentType.Trim());
            }
            else
                throw new InvalidOperationException("No existe configuracion para el servicio solicitado");

        }

        /// <summary>
        /// Filtra las respuestas del archivo Mock
        /// </summary>
        /// <param name="file">Archivo</param>
        /// <returns>Respuesta filtrada</returns>
        private string FilterMockResponse(string file)
        {
            var contentMock = File.ReadAllLines(file);
            var response = FilterByParams(contentMock);
            return response ?? GetDefaultResponse(contentMock) ?? GetFirstMockResponse(contentMock);
        }

        /// <summary>
        /// Filtra la lista de respuesta obteniendo la respuesta con los parametros especificados
        /// </summary>
        /// <param name="responses">Lista de respuestas</param>
        /// <returns>Respuesta filtrada por parametros</returns>
        private string FilterByParams(IEnumerable<string> responses)
        {
            return responses
                .Where(l =>
                    HttpContext.Current.Request.Params.AllKeys
                        .Any(k =>
                            HttpContext.Current.Request.Params[k].Contains(l.Substring(0, l.IndexOf('|')))
                            )).Select(p => SplitResponse(p)).FirstOrDefault();
        }

        /// <summary>
        /// Filtra las respuestas devolviendo la respuesta por defecto(Respuesta sin parametros)
        /// </summary>
        /// <param name="responses">Lista de respuestas</param>
        /// <returns>Respuesta por defecto</returns>
        private string GetDefaultResponse(IEnumerable<string> responses)
        {
            return responses?.FirstOrDefault(p => p.StartsWith("|"))?.Substring(1);
        }

        /// <summary>
        /// Filtra las respuestas devolviento la primera del archivo de respuestas
        /// </summary>
        /// <param name="responses">Respuestas</param>
        /// <returns>Primer respuesta</returns>
        private string GetFirstMockResponse(IEnumerable<string> responses)
        {
            return responses?.Select(p => SplitResponse(p)).FirstOrDefault();
        }

        /// <summary>
        /// Separa la respuesta para devolver el resultado esperado
        /// </summary>
        /// <param name="response">Respuesta a separar</param>
        /// <returns>Contenido Mock</returns>
        private string SplitResponse(string response)
        {
            return response.Substring(response.IndexOf('|') + 1);
        }

        /// <summary>
        /// Asigna la respuesta a la peticion
        /// </summary>
        /// <param name="content">Contenido</param>
        private void SetResponse(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException(nameof(content));
            }
            HttpContext.Current.Response.Write(content);
        }

        /// <summary>
        /// Actualiza el content type para cada peticion
        /// </summary>
        /// <param name="contentType">Content type</param>
        private void UpdateContentType(string contentType)
        {
            HttpContext.Current.Response.ContentType = string.IsNullOrEmpty(contentType) ?
                                                                    HttpContext.Current.Request.ContentType :
                                                                    contentType;
        }

        /// <summary>
        /// Deserealizador de XML
        /// </summary>
        /// <typeparam name="T">Tipo esperado</typeparam>
        /// <param name="data">Contenido XML</param>
        /// <returns>Objeto Deserializado</returns>
        private static T Deserialize<T>(string data) where T : class
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(ms);
            }
        }

        /// <summary>
        /// Archivo de configuracion
        /// </summary>
        private readonly string ConfigFile = AppDomain.CurrentDomain.BaseDirectory + @"Configuration\Config.xml";
    }
}