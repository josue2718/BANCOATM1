using System.Collections.Generic;
using System.Threading.Tasks;
using BANCOATM1.Models;

namespace BANCOATM1.BD.Interface
{
    public interface IHistorialCreditoEducativoRepository
    {
        Task<List<HistorialCreditoEducativo>> GetAllAsync();
        Task<HistorialCreditoEducativo> GetByIdAsync(int id);
        Task<int> UpdateAsync(HistorialCreditoEducativo creditoEducativo);
        Task<int> DeleteAsync(int id);
        Task<HistorialCreditoEducativo> CreateAsync(HistorialCreditoEducativo creditoEducativo);
    }
}
