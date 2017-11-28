using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRABALHOMVC.Models
{
    [Table("Venda")]
    public class Venda
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo Cliente Obrigatório")]
        public int clienteId { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual string clienteNome { get { return cliente.nome;  } }

        [Required(ErrorMessage = "Campo Item Obrigatório")]
        public int itemId { get; set; }
        public virtual Item item { get; set; }
        public virtual string itemDesc { get { return item.descricao; } }

        [Display(Name = "Data da Venda")]
        [Required(ErrorMessage = "Campo Data Obrigatório")]
        public DateTime data { get; set; }
    }
}