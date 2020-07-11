using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro_Prestamos.BLL;
using Registro_Prestamos.DAL;
using Registro_Prestamos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_Prestamos.BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool guardar = false;

            Persona persona = new Persona(0,"jose manuel urena","05612345639", "8062364512", "Calle trinitaria #45",DateTime.Now,0) ;
            //persona.PersonaId = 0;
            //persona.Nombre = "jose manuel urena";
            //persona.Cedula = "05612345639";
            //persona.Telefono = "8562364512";
            //persona.Direccion = "Calle trinitaria #45";
            //persona.FechaNacimiento = DateTime.Now;
            //persona.Balance = 0;
                
             guardar = PersonaBLL.Guardar(persona);
            Assert.Equals(guardar,true);           
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonaBLL.Eliminar(1);
            Assert.IsNotNull(paso);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Persona personas;
            personas = PersonaBLL.Buscar(1);
            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Persona>();
            lista = PersonaBLL.GetList(p => true);
            Assert.AreEqual(lista, lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            var paso = PersonaBLL.Existe(1);
            Assert.IsNotNull(paso);
        }
    }
}