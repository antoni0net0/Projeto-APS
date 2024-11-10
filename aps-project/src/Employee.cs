namespace aps_project;

class Employee : Entity
{
    public double Salary { get; private set; }
    public string Role { get; private set; }
    public int CompanyId { get; private set; }

    public Employee(double Salary, string Role, int CompanyId)
    {
        this.Salary = Salary;
        this.Role = Role;
        this.CompanyId = CompanyId;
    }
}