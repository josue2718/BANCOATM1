using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANCOATM1.Models
{
    [Table("HistorialCreditoEducativo")]
    public class HistorialCreditoEducativo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CreditoEducativo { get; set; }

        public int ID_cliente { get; set; }

        [ForeignKey("ID_cliente")]

        public long Monto { get; set; }

        public long SaldoRestante { get; set; }

        public string Folio { get; set; }

        public DateTime Fecha { get; set; }
    }
}
