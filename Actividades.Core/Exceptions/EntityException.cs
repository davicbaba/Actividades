using System;
using System.Collections.Generic;
using System.Text;

namespace Actividades.Core.Exceptions
{
    /// <summary>
    /// Excepcion base para validacion de entidades
    /// </summary>
    public class EntityException : Exception
    {
        public EntityException(string message): base(message)
        {

        }
    }
}
