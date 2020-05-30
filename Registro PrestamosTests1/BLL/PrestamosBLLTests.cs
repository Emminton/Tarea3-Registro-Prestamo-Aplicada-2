using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro_Prestamos.BLL;
using Registro_Prestamos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Prestamos.BLL.Tests
{
    [TestClass()]
    public class PrestamosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Prestamo prestamo = new Prestamo();
            prestamo.PretamoId= 0;
            prestamo.Fecha = DateTime.Now;
            prestamo.PersonaId = 1;
            prestamo.Concepto = "Prestamo";
            prestamo.Monto = 2000;
            prestamo.Balance = 0;
            bool paso = PrestamosBLL.Guardar(prestamo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Persona personas;
            personas = PersonaBLL.Buscar(1);
            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonaBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Persona>();
            lista = PersonaBLL.GetList(p => true);
            Assert.AreEqual(lista, lista);
        }
    }
}