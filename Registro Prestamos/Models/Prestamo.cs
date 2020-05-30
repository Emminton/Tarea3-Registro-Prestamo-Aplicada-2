using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Prestamos.Models
{
    public class Prestamo
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 100, ErrorMessage = "El campo ID no puede ser cero o (mayor a 100).")]
        public int PretamoId { get; set; }
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "El campo concepto no puede estar vacía.")]
        [MinLength(5, ErrorMessage = "El concepto es muy corta.")]
        [MaxLength(40, ErrorMessage = "El concepto debe contener menos de 60 caracteres.")]
        public string  Concepto { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Favor llenar el campo FECHA no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo monto no puede estar vacio.")]
        [Range(1, 100000000, ErrorMessage = "El rango es de 1 a 1000000.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo balance no puede estar vacio.")]
        public decimal Balance { get; set; }

        public Prestamo()
        {
            PretamoId = 0;
            PersonaId = 0;
            Concepto = string.Empty;
            Fecha = DateTime.Now;
            Monto = 0;
            Balance = 0;
        }
    }
}
