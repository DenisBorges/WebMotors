using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMotors.AppService.ViewModel
{
    public class AnuncioWebMotorsViewModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(45)]
        public string Marca { get; set; }

        [Required]
        [MaxLength(45)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(45)]
        public string Versao { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Quilometragem { get; set; }

        [Required]
        [MaxLength(45)]
        public string Observacao { get; set; }
    }
}
