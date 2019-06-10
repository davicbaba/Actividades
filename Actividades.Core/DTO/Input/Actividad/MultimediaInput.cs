using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.DTO.Input.Actividad
{
    /// <summary>
    /// Datos necesarios para poder generar una multimedia
    /// </summary>
    public class MultimediaInput
    {
        /// <summary>
        /// Nombre del archivo incluyendo su extension
        /// </summary>
        public string NombreArchivo { get; set; }

        /// <summary>
        /// Archivo codificado a base64
        /// </summary>
        public string Base64 { get; set; }
    }
}
