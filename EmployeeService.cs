using System;

namespace DemoOOP;

public class EmployeeService
{
    private List<Employee> employees;

    public EmployeeService()
    {
        employees = new List<Employee>();
    }
    public void create(Employee employee)
    {
        if (employee == null)
        {
            throw new ArgumentNullException("Employee cannot be null");
        }
        employees.Add(employee);
    }

    public IEnumerable<Employee> getAll()
    {
        return employees;
    }

    //Demo Predicate delegate
    public Employee? getById(int id)
    {
        Predicate<Employee> fillter = e => e.id == id;
        return employees.Find(fillter);
    }

    //Demo Func Delegate
    public List<Employee> GetEmployeeTaxList()
    {
        return employees.Select(e => new Employee { name = e.name,id = e.id, Salary = e.Salary * 0.1M }).ToList();
    }

    //Demo Active Delegate
    public void SendNotification(Employee emp)
    {
        Action<Employee> notify = e =>
            Console.WriteLine($"[NOTIFY] Gửi email đến {e.name} về thông tin cập nhật.");
        notify(emp);
    }

    public void update(int id, Employee employee)
    {
        Employee entity = getById(id);
        if (entity == null)
        {
            throw new ArgumentNullException("Employee is not found");
        }
        entity.id = employee.id;
        entity.name = employee.name;
    }
    public void delete(int id)
    {
        var employee = getById(id);
        if (employee != null)
        {
            employees.Remove(employee);
        }
    }
}
