using System.ComponentModel.DataAnnotations;

namespace ProyectoPrimerParcial.Models
{
    public class Aeronave
    {
        public int AeronaveId { get; set; }

        [Required(ErrorMessage ="Debe ingresar el tipo de aeronave")]
        [Display(Name = "Tipo de aeronave")]
        public string? TipoAeronave {get; set;}
    }
}
