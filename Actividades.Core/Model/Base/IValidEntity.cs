using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Model.Base
{
    /// <summary>
    /// Representa una entidad que tiene reglas de negocio que deben ser cumplidas antes de ser almacenada en la base de datos.
    /// </summary>
    public interface IValidEntity
    {
        /// <summary>
        /// Se debe realizar todas las validaciones de negocio de la entidadad
        /// </summary>
        /// <returns></returns>
        bool IsValid();
    }
}
