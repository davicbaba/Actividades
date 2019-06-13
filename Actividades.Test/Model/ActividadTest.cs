using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Actividades.Core.Model;
using NUnit.Framework;

namespace Actividades.Test.Model
{
    public class ActividadTest
    {
        [Test]
        public void IsValid_FechasSinRelacion_NoEsValido()
        {
            //Preparar
            Actividad actividad = GetActividad();

            actividad.FechaInicio = DateTime.Now.AddHours(1);
            actividad.FechaFin = DateTime.Now;

            //Ejecutar
            bool isValid = actividad.IsValid();


            //Probar
            Assert.AreEqual(isValid, false); 
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
            return new Actividad()
            {
                Id = 1,
                Descripcion = "Realizar actividad de dibujo tecnico",
                Titulo = "Actividad dibujo tecnico",
                Orden = 1,
                Finalizada = false,
                FechaCambioEstado = DateTime.Now
            };
        }

    }
}
