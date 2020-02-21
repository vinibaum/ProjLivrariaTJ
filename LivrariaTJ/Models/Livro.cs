using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LivrariaTJ.Models
{
    public class Livro
    {
        public int LivroID { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Required]
        [Display(Name = "Data de publicação")]
        public DateTime DataPublicacao { get; set; }

        [Required]
        [Display(Name = "Páginas")]
        public int NumeroPaginas { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Editora { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        public string Sinopse { get; set; }

        [Required]
        [Display(Name = "Capa")]
        public string ImagemCapa { get; set; }

        [Display(Name = "Compre online")]
        public string LinksParaCompra { get; set; }

    }
}