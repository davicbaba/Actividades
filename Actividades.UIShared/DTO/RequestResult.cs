using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Actividades.UIShared.DTO
{
    /// <summary>
    /// Representa un resultado de una consulta a un api
    /// </summary>
    public class RequestResult
    {
        /// <summary>
        /// Respuesta en json que se recibio del api
        /// </summary>
        public string JsonResponse { get; set; }

        /// <summary>
        /// Status code del api 
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Indica si es un status code exitoso
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }
    }
}
