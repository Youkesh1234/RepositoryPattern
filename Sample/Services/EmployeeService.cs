using Sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Repository;

namespace Sample.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _uow;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork uow)
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
        }

        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var resp = await _employeeRepository.GetAllAsync().ConfigureAwait(false);
            return resp.ToList();
            //return await _context.Employees.ToListAsync().ConfigureAwait(false);
        }

        public async Task<bool> CreateAsync(Employee employee)
        {
            await _employeeRepository.AddAsync(employee).ConfigureAwait(false);
            _uow.CommitChanges();
            //_context.Add(employee);
            //await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditAsync(Employee employee)
        {
            _employeeRepository.Update(employee);
            _uow.CommitChanges();
            //_context.Update(employee);
            //await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Employee> DetailsAsync(int? id)
        {
            return await _employeeRepository.GetByIdAsync(id.Value).ConfigureAwait(false);
            //var employee = await _context.Employees
            //.FirstOrDefaultAsync(m => m.Id == id);
            //return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await FindByIdAsync(id).ConfigureAwait(false);
            _employeeRepository.Remove(employee);
            _uow.CommitChanges();
            return true;
        }

    }

}