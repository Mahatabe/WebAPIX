using WebAPIX.Model;

namespace WebAPIX.IRepository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetEmployee();

        public Task<string> CreateEmployee(Employee employee);

        public Task<string> UpdateEmployee(Employee employee, int Id);

        public Task<string> DeleteEmployee(int Id);
    }
}
