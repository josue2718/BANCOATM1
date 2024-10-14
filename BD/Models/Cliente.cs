using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BANCOATM1.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_cliente { get; set; }

        public string Nombre { get; set; }

        public long NumTarjeta { get; set; }

        public int Nip { get; set; }

        public string Correo { get; set; }

        public long SaldoTarjeta { get; set; }

        public string TipoTarjeta { get; set; }

        public int LimTrans { get; set; }

        public long AdeuTarjeta { get; set; }

        public long LimiteTarjeta { get; set; }

        public long AdeuHipoteca { get; set; }

        public long AdeuCarro { get; set; }

        public int MesesAdeudo { get; set; }

        public long InteresAnual { get; set; }

        public string CE { get; set; }
        public int ACE { get; set; }
        
        public int TIC { get; set; }
        public int AP { get; set; }
    }
}
