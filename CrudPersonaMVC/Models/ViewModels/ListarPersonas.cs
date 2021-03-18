using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudPersonaMVC.Models.ViewModels
{
    public class ListarPersonas
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}