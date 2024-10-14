using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BANCOATM1.BD.Models
{
    [Table("HistorialCreditoPagos")]
    public class HistorialCreditoPagos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_PagosCredito { get; set; }

        public int ID_cliente { get; set; }

        [ForeignKey("ID_cliente")]

        public long Monto { get; set; }

        public string Tipo { get; set; }

        public string Pago { get; set; }

        public long SaldoRestante { get; set; }

        public string Folio { get; set; }

        public DateTime Fecha { get; set; }

    }
}
