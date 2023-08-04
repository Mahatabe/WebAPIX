using Dapper;
using System.Data;
using WebAPIX.Data;
using WebAPIX.IRepository;
using WebAPIX.Model;

namespace WebAPIX.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;
        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<string> CreateEmployee(Employee employee)
        {
            string create = string.Empty;
            var query = "INSERT INTO Employee (name, email, phone, designation) VALUES (@name, @email, @phone, @designation)";
            var parameters = new DynamicParameters();
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                create = "Created";
            }
            return create;
        }

        public async Task<string> DeleteEmployee(int Id)
        {
            string del = string.Empty;
            var query = "delete * FROM Employee where id = @id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id });
                del = "Deleted";
            }
            return del;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employ = await connection.QueryAsync<Employee>(query);
                return employ.ToList();
            }
        }

        public async Task<string> UpdateEmployee(Employee employee, int Id)
        {
            string update = string.Empty;
            var query = "update Employee set name=@name, email=@email, phone=@phone, designation=@designation where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("id", employee.id, DbType.Int32);
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                update = "Updated";
            }
            return update;
        }
    }
}
