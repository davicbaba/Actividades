using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Multimedia del sistema de actividades
    /// </summary>
    public class Multimedia
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

        /// <summary>
        /// Tipo de multimedia
        /// </summary>
        public TipoMultimedia TipoMultimedia { get => GetTipoMultimedia(); }

        /// <summary>
        /// Campo para leer mejor el tipo de multimedia.
        /// </summary>
        public string TipoMultimediaTexto { get => TipoMultimedia.ToString(); }

        /// <summary>
        /// Identificador unico de la actividad 
        /// </summary>
        public int IdActividad { get; set; }

        /// <summary>
        /// Determina el tipo de multimedia en base al mimetype.
        /// </summary>
        /// <returns></returns>
        private TipoMultimedia GetTipoMultimedia()
        {
            if (MimeType.Contains("image"))
                return TipoMultimedia.Imagen;

            if (MimeType.Contains("video"))
                return TipoMultimedia.Video;

            return TipoMultimedia.Archivo;
        }

    }
}
