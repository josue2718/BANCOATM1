using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANCOATM1.Models
{
    [Table("HistorialServicio")] // Corregido el nombre de la tabla
    public class HistorialServicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Servicio { get; set; }

        public int ID_cliente { get; set; }

        [ForeignKey("ID_cliente")]

        public string Referencia { get; set; }
        public long Monto { get; set; }
        public long SaldoRestante { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
