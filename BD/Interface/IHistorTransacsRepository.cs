using BANCOATM1.Models;

namespace BANCOATM1.BD.Interface
{
    public interface IHistorTransacsRepository
    {
        Task<List<HistorialTransac>> GetAllAsync();
        Task<HistorialTransac> GetByIdAsync(int id);
        Task<int> UpdateAsync(HistorialTransac transacs);
        Task<int> DeleteAsync(int id);
        Task<HistorialTransac> CreateAsync(HistorialTransac transacs);
    }
}
