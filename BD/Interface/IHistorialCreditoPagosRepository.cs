using BANCOATM1.BD.Models;

namespace BANCOATM1.BD.Interface
{
    public interface IHistorialCreditoPagosRepository
    {
        Task<List<HistorialCreditoPagos>> GetAllAsync();
        Task<HistorialCreditoPagos> GetByIdAsync(int id);
        Task<int> UpdateAsync(HistorialCreditoPagos creditopagos);
        Task<int> DeleteAsync(int id);
        Task<HistorialCreditoPagos> CreateAsync(HistorialCreditoPagos creditoPagos);
    }
}
