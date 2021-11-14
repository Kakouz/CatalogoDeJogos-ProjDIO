using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoDeJogos_ProjDIO.InputModels
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public String Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public String Produtora { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "O preço deve ser no mínimo 1 real e no maximo 1000 reais")]
        public double preco { get; set; }
        public double Preco { get; internal set; }
    }
}
