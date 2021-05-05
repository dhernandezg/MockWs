using MockWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MockWebApi.Controllers
{
    /// <summary>
    /// Controlador de servicios mock
    /// </summary>
    public class CentralController : ApiController
    {
        public CentralController()
        {
            DataFromHttpStream = GetRequestFromStream();
        }

        /// <summary>
        /// Método de obtención de respuestas mock
        /// </summary>
        /// <param name="service">Servicio a realizar mock</param>
        public IHttpActionResult Get(string service)
        {
            MockWs(service);
            return Ok();
        }

        /// <summary>
        /// Método de obtención de respuestas mock
        /// </summary>
        /// <param name="service">Servicio a realizar mock</param>
        public IHttpActionResult Post(string service)
        {
            MockWs(service);
            return Ok();
        }

        private string DataFromHttpStream { get; set; }

        /// <summary>
        /// Realiza el proceso mock para cada petición
        /// </summary>
        /// <param name="service">Servicio a hacer mock</param>
        private void MockWs(string service)
        {
            if (!File.Exists(ConfigFile))
            {
                throw new FileNotFoundException("El archivo de configuración global no existe");
            }
            var config = Deserialize<ConfigRoutes>(XDocument.Load(ConfigFile).ToString())
                .DinamycMock.Where(m => string.CompareOrdinal(service, m.PartialPath) == 0 && IsBoolNulable(m.Request?.Filters.Any(f => DataFromHttpStream.Contains(f)))).FirstOrDefault();

            if (config != null)
            {
                string fileResp = AppDomain.CurrentDomain.BaseDirectory + @"Response\" + config.Response.File;
                if (!File.Exists(fileResp))
                {
                    throw new FileNotFoundException("El archivo de respuesta no existe:" + fileResp);
                }
                var stringResponse = FilterMockResponse(fileResp);

                if (config.Response.RegularString)
                {
                    SetResponse(stringResponse.Replace("\\n","\n").Replace("\\r","\r"));
                }
                else
                {
                    SetResponse(stringResponse);
                }

                UpdateContentType(config.Response.ContentType?.Trim());

            }
            else
            {
                throw new InvalidOperationException("No existe configuración para el servicio solicitado");
            }
        }

        private string GetRequestFromStream()
        {
            var content = new byte[HttpContext.Current.Request.InputStream.Length];
            HttpContext.Current.Request.InputStream.Read(content, 0, content.Length);
            return Encoding.UTF8.GetString(content);
        }

        private bool IsBoolNulable(bool? data)
        {
            return data == null || data != false;
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
        /// Filtra la lista de respuesta obteniendo la respuesta con los parámetros especificados
        /// </summary>
        /// <param name="responses">Lista de respuestas</param>
        /// <returns>Respuesta filtrada por parámetros</returns>
        private string FilterByParams(IEnumerable<string> responses)
        {
            return responses
                .Where(l => l.IndexOf('|') != 0 && FilterByHttpMethod(l.Substring(0, l.IndexOf('|'))))
                .Select(p => SplitResponse(p)).FirstOrDefault();
        }

        private bool FilterByHttpMethod(string filter)
        {
            var filters = filter.Split('@');
            if (HttpContext.Current.Request.Form.Count != 0)
            {
                return filters.All(f => HttpContext.Current.Request.Form.ToString().Contains(f));
            }
            else if (!string.IsNullOrEmpty(DataFromHttpStream))
            {
                return filters.All(f => DataFromHttpStream.Contains(f));
            }
            else
            {
                return filters.All(f => HttpContext.Current.Request.Params.AllKeys
                                        .Any(k => HttpContext.Current.Request.Params[k].Contains(f)));
            }
        }

        bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        /// <summary>
        /// Filtra las respuestas devolviendo la respuesta por defecto(Respuesta sin parámetros)
        /// </summary>
        /// <param name="responses">Lista de respuestas</param>
        /// <returns>Respuesta por defecto</returns>
        private string GetDefaultResponse(IEnumerable<string> responses)
        {
            return responses?.FirstOrDefault(p => p.StartsWith("|"))?.Substring(1);
        }

        /// <summary>
        /// Filtra las respuestas devolviendo la primera del archivo de respuestas
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
        /// Asigna la respuesta a la petición
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
        /// Asigna una respuesta para las cadenas regulares
        /// </summary>
        /// <param name="vs"></param>
        private void SetResponse(byte[] vs)
        {
            HttpContext.Current.Response.BinaryWrite(vs);
        }

        /// <summary>
        /// Actualiza el content type para cada petición
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
        /// Archivo de configuración
        /// </summary>
        private readonly string ConfigFile = AppDomain.CurrentDomain.BaseDirectory + @"Configuration\Config.xml";
    }
}