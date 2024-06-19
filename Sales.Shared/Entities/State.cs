using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class State
    {
        public int Id { get; set; }


        [Display(Name = "Estado/Departamento")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe teren un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        public int CountryId { get; set; }

        public Country? Country { get; set; } //Esta propiedad permite la relación de muchos a uno con Country
        

        public ICollection<City>? Cities { get; set; } ////Esta propiedad permite la relación de uno a muchos con City

        //si el objeto Cities es exactamente igual a null entonces diremos que tiene cero Cities, 
        //de lo contrario con Cities.Count tendremos la cantidad de ciudades
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;



    }
}
