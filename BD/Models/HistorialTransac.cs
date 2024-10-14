using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANCOATM1.Models
{
    [Table("HistorialTransaccion")]
    public class HistorialTransac
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Historial { get; set; }

        public int ID_cliente { get; set; }

        [ForeignKey("ID_cliente")]
    
        public string TipoTransaccion { get; set; }

        public long Monto { get; set; }

        public long SaldoRestante { get; set; }

        public string Folio { get; set; }

        public DateTime Fecha { get; set; }
    }
}
