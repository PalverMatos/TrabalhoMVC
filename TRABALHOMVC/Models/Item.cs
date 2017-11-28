using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRABALHOMVC.Models
{
    [Table("Item")]
    public class Item
    {
        public Item()
        {
            this.Vendas = new HashSet<Venda>();
        }

        public virtual ICollection<Venda> Vendas { get; set; }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nome do Item")]
        /* Define a quantidade máxima de caracteres permitida */
        [StringLength(35, ErrorMessage = "Tamanho maximo de 35 caracteres")]
        /* Define que este campo será obrigatório */
        [Required(ErrorMessage = "Campo Item Obrigatório")]
        public string descricao { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor Obrigatorio")]
        public float valor { get; set; }


        [Display(Name = "Quantidade Disponivel")]
        [Required(ErrorMessage = "Informe a quantidade")]
        public int qtd { get; set; }
    }
}