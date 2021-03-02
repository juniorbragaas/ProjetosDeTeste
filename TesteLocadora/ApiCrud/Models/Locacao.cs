using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCrud.Repository
{
    public partial class Locacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdCliente { get; set; }

        public int IdFilme { get; set; }
        public DateTime DataInicioLocacao { get; set; }
        public DateTime DataFimLocacao { get; set; }
    }
}
