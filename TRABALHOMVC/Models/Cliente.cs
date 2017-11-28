using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRABALHOMVC.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        public Cliente()
        {
            this.Vendas = new HashSet<Venda>();
        }

        public virtual ICollection<Venda> Vendas { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Nome do Cliente")]
        /* Define a quantidade máxima de caracteres permitida */
        [StringLength(35, ErrorMessage = "Tamanho maximo de 35 caracteres")]
        /* Define que este campo será obrigatório */
        [Required(ErrorMessage = "Campo Nome do Cliente Obrigatório")]
        public string nome { get; set; }

        [Display(Name = "Endereço")]
        /* Define a quantidade máxima de caracteres permitida */
        [StringLength(35, ErrorMessage = "Tamanho maximo de 35 caracteres")]
        /* Define que este campo será obrigatório */
        [Required(ErrorMessage = "Endereço Obrigatório")]
        public string endereco { get; set; }
    }
}