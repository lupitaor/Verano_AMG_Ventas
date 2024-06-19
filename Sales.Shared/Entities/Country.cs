using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class Country
    {
        public int Id { get; set; }

        
        [Display (Name="Pais")]
        [MaxLength(100, ErrorMessage ="El campo {0} debe teren un máximo de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es requerido") ]
        public string Name { get; set; } = null!;

        public ICollection<State>? States { get; set; } ////Esta propiedad permite la relación de uno a muchos con State

        //si el objeto States es exactamente igual a null entonces diremos que tiene cero estados, 
        //de lo contrario con States.Count tendremos la cantidad de estados
        public int StatesNumber => States == null ? 0 : States.Count;
    
    
    }
}
