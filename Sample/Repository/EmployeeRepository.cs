using Sample.Models;

namespace Sample.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TaskContext context) : base(context)
        {
        }
    }
}
