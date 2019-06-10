using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model
{
    /// <summary>
    /// Representa un estado de una actividad
    /// </summary>
    public class Estado
    {
        /// <summary>
        /// Identificador unico del estado
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Descripcion amigable del estado
        /// </summary>
        public string DescripcionEstado { get; set; }

    }
}
