using Microsoft.EntityFrameworkCore;
using Registro_Prestamos.DAL;
using Registro_Prestamos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Registro_Prestamos.BLL
{
    public class PrestamosBLL
    {
       public static bool Guardar(Prestamo prestamo)
        {
            if (!Existe(prestamo.PretamoId))
             return Insertar(prestamo);
            else
                return Modificar(prestamo);

        }
       
        private static bool Insertar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
           
            decimal AuxMonto = prestamo.Monto;
            prestamo.Balance = AuxMonto;
            
            try
            {
                contexto.Prestamos.Add(prestamo);
                contexto.Personas.Find(prestamo.PersonaId).Balance += prestamo.Balance;
                paso = (contexto.SaveChanges() > 0);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Prestamo prestamo)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            decimal BalanceAnterior = Buscar(prestamo.PersonaId).Balance;
            int PersonaIdAnterior = Buscar(prestamo.PersonaId).PersonaId;

            try
            {
                if (PersonaIdAnterior != prestamo.PersonaId)
                {
                    contexto.Personas.Find(PersonaIdAnterior).Balance -= BalanceAnterior;
                    contexto.Personas.Find(prestamo.PersonaId).Balance += prestamo.Balance;
                }
                else
                {
                    contexto.Personas.Find(prestamo.PersonaId).Balance -= BalanceAnterior;
                    contexto.Personas.Find(prestamo.PersonaId).Balance += prestamo.Balance;
                }
                contexto.Entry(prestamo).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Prestamo Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Prestamo prestamo = new Prestamo();

            try
            {
                prestamo = contexto.Prestamos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return prestamo;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = PrestamosBLL.Buscar(id);
                if (eliminar != null)
                {
                    contexto.Personas.Find(eliminar.PersonaId).Balance -= eliminar.Balance; //le resto el balance a la persona
                    contexto.Prestamos.Remove(eliminar);//remueve la entidad
                    paso = contexto.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        public  static List<Prestamo> GetList(Expression<Func<Prestamo,bool>> prestamo)
        {
            List<Prestamo> lista = new List<Prestamo>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Prestamos.Where(prestamo).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();

            }
            return lista;
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Prestamos.Any(p => p.PretamoId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
    }
}
