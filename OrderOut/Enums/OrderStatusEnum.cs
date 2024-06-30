using System.ComponentModel.DataAnnotations;

namespace OrderOut.Enums
{
    public enum OrderStatusEnum
    {
        [Display(Name = "Nuevo")]
        Nuevo = 1,

        [Display(Name = "Preparando")]
        Preparando = 2,

        [Display(Name = "Entregado")]
        Entregado = 3,

        [Display(Name = "Pagado")]
        Pagado = 4
    }
}
