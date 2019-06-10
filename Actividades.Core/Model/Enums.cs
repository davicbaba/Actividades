using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Indica los tipos de multimedias a manejar
    /// </summary>
    public enum TipoMultimedia
    {
        /// <summary>
        /// El archivo es una imagen
        /// </summary>
        Imagen = 1,

        /// <summary>
        /// El archivo es un video
        /// </summary>
        Video = 2,

        /// <summary>
        /// El archivo no se encuentra catalogado con un tipo especifico.
        /// </summary>
        Archivo = 3 
    }
}
