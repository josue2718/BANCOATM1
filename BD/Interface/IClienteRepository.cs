using BANCOATM1.Models;

namespace BANCOATM1.BD.Interface
{
    public interface IClienteRepositoryRepository
    {
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<int> UpdateAsync(Cliente cliente);
        Task<int> DeleteAsync(int id);
        Task<Cliente> CreateAsync(Cliente cliente);

    }
}
