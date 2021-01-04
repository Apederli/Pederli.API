using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pederli.API.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen {0} alanını doldurunuz.")]
        public string Name { get; set; }
        [Range(1,Int32.MaxValue,ErrorMessage = "{0} alanı 1 den büyük olmalı")]
        public int Stock { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "{0} alanı 1 den büyük olmalı")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
