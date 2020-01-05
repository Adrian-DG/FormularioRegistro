using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FormularioRegistro.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Nombre { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Apellido { get; set; }
        [Required]
        [DisplayName("Genero")]
        public Sex Genre { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Fecha de nacimiento")]
        public DateTime FechaNac { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Correo Electronico")]
        public string Correo { get; set; }

       
    }

    public enum Sex { Masculino, Femenino }
}