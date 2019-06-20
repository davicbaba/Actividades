using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.DTO.Output.Multimedia
{
    /// <summary>
    /// Datos necesarios para representar una multimedia
    /// </summary>
    public class MultimediaOutput
    {

        /// <summary>
        /// Identifiador unico de la multimedia
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador unico del archivo
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Mimetype del archivo
        /// </summary>
        public string MimeType { get; set; }

    }
}
