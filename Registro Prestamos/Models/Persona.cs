using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_Prestamos.Models
{
    public class Persona
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío.")]
        [Range(0, 100, ErrorMessage = "El campo ID no puede ser cero o (mayor a 100).")]
        public int PersonaId { get; set; }

        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener por lo menos (3 caracteres).")]
        [MaxLength(50, ErrorMessage = "El nombre es muy largo.")]
        [RegularExpression(@"\S(.*)\S", ErrorMessage = "Debe ser un texto.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Cedula no puede estar vacío.")]
        [RegularExpression("^\\d{3}\\D?\\d{7}\\D?\\d$", ErrorMessage = "Por favor ingrese un No. de Cedula válido.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "El campo Telefono no puede estar vacío.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor ingrese un No. de Teléfono válido.")]
        [MaxLength(10, ErrorMessage = "El campo Telefono no tiene más de diez dígitos.")]
        public string Telefono { get; set; }


        [Required(ErrorMessage = "El campo dirección no puede estar vacío.")]
        [MinLength(10, ErrorMessage = "La dirección bebe tener minimo (10 caractere).")]
        [MaxLength(100, ErrorMessage = "La dirección debe tener Maximo (100 caracteres).")]
        public string Direccion { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Favor llenar el campo FECHA no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime FechaNacimiento { get; set; }

        public decimal Balance { get; set; }

        public Persona()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
            Balance = 0;
        }
    }
}
