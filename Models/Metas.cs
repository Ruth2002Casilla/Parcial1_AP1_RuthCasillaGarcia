using System.ComponentModel.DataAnnotations;

namespace Parcial1_AP1_RuthCasillaGarcia.Models
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }

        [Required(ErrorMessage ="Este campo es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [RegularExpression(@"^[A-ZÁÉÍÓÚÑ][a-zA-ZÁÉÍÓÚÑ ]*$", ErrorMessage = "La Descripción debe comenzar con una letra mayúscula y no debe contener números.")]
        public string? Descripcion { get; set; }



        [Required(ErrorMessage = "Este campo es Obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Monto no puede ser un número negativo o Cero.")]
        public float Monto { get; set; }

        public Metas()
        {
            Fecha = DateTime.Now;
        }
    }
}
