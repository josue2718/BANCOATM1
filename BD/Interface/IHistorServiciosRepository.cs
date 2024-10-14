using BANCOATM1.Models;



namespace BANCOATM1.BD.Interface
{
    public interface IHistorialServicioRepository
    {
        Task<List<HistorialServicio>> GetAllAsync();
        Task<HistorialServicio> GetByIdAsync(int id);
        Task<int> UpdateAsync(HistorialServicio servicios);
        Task<int> DeleteAsync(int id);
        Task<HistorialServicio> CreateAsync(HistorialServicio servicios);
        
    }
}