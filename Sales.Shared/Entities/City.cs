﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Shared.Entities
{
    public class City
    {

        public int Id { get; set; }


        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe teren un máximo de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Name { get; set; } = null!;

        public int StateId { get; set; }

        public State? State { get; set; } //Esta propiedad permite la relación de muchos a uno con State


    }
}
