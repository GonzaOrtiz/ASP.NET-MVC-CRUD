using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudPersonaMVC.Models.ViewModels
{
    public class PersonaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Email { get; set; }
    }
}