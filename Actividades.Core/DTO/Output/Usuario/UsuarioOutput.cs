using Actividades.Core.DTO.Output.Actividad;
using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.DTO.Output.Usuario
{
    public class UsuarioOutput
    {
        /// <summary>
        /// Usuario con que se autentica en el sistema
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombres { get; set; }

        /// <summary>
        /// Apellidos del usuario
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// Indica cada cuanto se deben recibir notificaciones de actividades cuando estas esten por vencer o esten vencidas.
        /// </summary>
        /// <remarks>
        /// Tiempo que corre a partir que la primera notificacion llega.
        /// </remarks>
        public int NotificacionActividadMinutos { get; set; }

        /// <summary>
        /// Actividades del usuario
        /// </summary>
        public List<ActividadOutput> Actividades { get; set; }
    }
}
