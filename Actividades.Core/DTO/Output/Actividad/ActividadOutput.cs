using System;
using System.Collections.Generic;
using System.Text;
using Actividades.Core.DTO.Output.Multimedia;
using Actividades.Core.Model;

namespace Actividades.Core.DTO.Output.Actividad
{
    public class ActividadOutput
    {
        /// <summary>
        /// Identificador unico de la actividad
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titulo de la actividad
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion de la actividad
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha en que se completo la actividad
        /// </summary>
        public DateTime? FechaCambioEstado { get; set; }

        /// <summary>
        /// Fecha en que la actividad se elimino
        /// </summary>
        public DateTime? FechaBorrado { get; set; }

        /// <summary>
        /// Indica si la actividad a sido finalizada
        /// </summary>
        public bool Finalizada { get; set; }

        /// <summary>
        /// Identificador unico del estado
        /// </summary>
        public string IdEstado { get; private set; }

        /// <summary>
        /// Multimedias anexa a la actividad
        /// </summary>
        public List<MultimediaOutput> Multimedias { get; set; }

        /// <summary>
        /// Fecha de inicio de la actividad
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en la que finalizara la actividad
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Identificador del usuario al que pertenece la actividad
        /// </summary>
        public string IdUsuario { get; set; }


    }
}
