using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VeterinariaVanesaMorales.Models
{
    public class Contacto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EL nombre es obligatorio")]
        [MinLength(10, ErrorMessage = "EL nombre de usuario debe tener al menos 10 caracteres")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }


        [Required(ErrorMessage = "Es obligatorio el Email")]
        [EmailAddress(ErrorMessage = "Debe ingresar un Email valido")]

        public string Email { get; set; }

        [RegularExpression("[0123456789]", ErrorMessage = "Solo puede ingresar números")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatoria la Ciudad")]
        public string Ciudad { get; set; }

        public string Mensaje { get; set; }




    }
}