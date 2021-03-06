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
     
        public int ID { get; set; }

      
        [MaxLength(45)]
        public string Marca { get; set; }

    
        [MaxLength(45)]
        public string Modelo { get; set; }

  
        [MaxLength(45)]
        public string Versao { get; set; }

 
        public int Ano { get; set; }


        public int Quilometragem { get; set; }


        [MaxLength(45)]
        public string Observacao { get; set; }
    }
}
