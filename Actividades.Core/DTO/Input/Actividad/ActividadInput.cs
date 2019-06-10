using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.DTO.Input.Actividad
{
    /// <summary>
    /// Datos necesarios para poder generar una <see cref="Model.Actividad"/>
    /// </summary>
    public class ActividadInput
    {
        /// <summary>
        /// Titulo de la actividad
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion de la actividad
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha en que se vence la actividad
        /// </summary>
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Orden de presentacion de la actividad
        /// </summary>
        public int Orden { get; set; }

        /// <summary>
        /// Identificador del estado en que se encuentra la actividad
        /// </summary>
        public string IdEstado { get; set; }

        /// <summary>
        /// Multimedias anexa a la actividad
        /// </summary>
        public List<MultimediaInput> Multimedia { get; set; }
    }
}
