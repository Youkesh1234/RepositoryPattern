using Sample.Models;

namespace Sample.Services
{
    public interface IEmployeeService
    {
        Task<Employee> FindByIdAsync(int id);

        Task<List<Employee>> GetAllAsync();

        Task<bool> CreateAsync(Employee employee);

        Task<bool> EditAsync(Employee employee);

        Task<Employee> DetailsAsync(int? id);

        Task<bool> DeleteAsync(int id);
    }
}
