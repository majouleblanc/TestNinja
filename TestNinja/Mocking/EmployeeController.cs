using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _employeeStorage;

        //private EmployeeContext _db;

        public EmployeeController(IEmployeeStorage employeeStorage = null)
        {
            _employeeStorage = employeeStorage ?? new EmployeeStorage();
            //_db = new EmployeeContext();
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employeeStorage.DeleteEmployee(id);
            //var employee = _db.Employees.Find(id);
            //_db.Employees.Remove(employee);
            //_db.SaveChanges();
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}