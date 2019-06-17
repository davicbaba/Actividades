using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Actividades.Core.Model;
using NUnit.Framework;
using Actividades.Core.Exceptions;

namespace Actividades.Test.Model
{
    public class ActividadTest
    {
        private List<Actividad> ActividadesGeneradas = new List<Actividad>();

        [Test]
        public void IsValid_FechasSinRelacion_NoEsValido()
        {
            //Preparar
            Actividad actividad = GetActividad();

            actividad.FechaInicio = DateTime.Now.AddHours(1);
            actividad.FechaFin = DateTime.Now;

            //Probar
            Assert.Throws<EntityException>(() => actividad.IsValid());
        }

        [Test]
        public void GetDuracionActividad_TiempoDe1Hora_Regresa1HoraDeTiempo()
        {
            //Preparar
            Actividad actividad = GetActividad();

            DateTime hoy = new DateTime(2019,1,10);

            DateTime fechaInicio = hoy.AddHours(5);

            DateTime fechaFin = fechaInicio.AddHours(1);

            actividad.FechaInicio = fechaInicio;
            actividad.FechaFin = fechaFin;

            double horas = actividad.GetDuracionActividad().TotalMinutes;

            double tiempoEstimado = 60;

            Assert.AreEqual(tiempoEstimado, horas);
        }

        private Actividad GetActividad()
        {
            int max = 1;

            if(ActividadesGeneradas.Any())
            {
                max = ActividadesGeneradas.Max(x => x.Id);
                max++;
            }

            Actividad act =  new Actividad()
            {
                Id = max,
                Descripcion = "Realizar actividad de dibujo tecnico",
                Titulo = "Actividad dibujo tecnico",
                Finalizada = false,
                FechaCambioEstado = DateTime.Now
            };

            ActividadesGeneradas.Add(act);

            return act;
        }

    }
}
