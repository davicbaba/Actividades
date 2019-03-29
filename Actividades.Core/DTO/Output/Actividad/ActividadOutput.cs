using System;
using System.Collections.Generic;
using System.Text;
using Actividades.Core.Model;

namespace Actividades.Core.DTO.Output.Actividad
{
    public class ActividadOutput
    {
        /// <summary>
        /// Identificador unico de la actividad
        /// </summary>
        public int Codigo { get; set; }

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
        /// Fecha en que se completo la actividad
        /// </summary>
        public DateTime? FechaCambioEstado { get; set; }

        /// <summary>
        /// Orden de presentacion de la actividad
        /// </summary>
        public int Orden { get; set; }

        /// <summary>
        /// Estado en que se encuentra la actividad
        /// </summary>
        public Estado Estado { get; set; }

        /// <summary>
        /// Prioridad de la actividad
        /// </summary>
        public Prioridad Prioridad { get; set; }
    }
}
