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
        /// Identificador unico de la actividad
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Titulo de la actividad
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion de la actividad
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Identificador unico del estado
        /// </summary>
        public string IdEstado { get; set; }

        /// <summary>
        /// Multimedias anexa a la actividad
        /// </summary>
        public List<MultimediaInput> Multimedias { get; set; }

        /// <summary>
        /// Fecha de inicio de la actividad
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en la que finalizara la actividad
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Si la actividad se debe agregar en el lapso de tiempo especificado aunque ya este ocupado ese horario.
        /// </summary>
        public bool Forzar { get; set; }
    }
}
