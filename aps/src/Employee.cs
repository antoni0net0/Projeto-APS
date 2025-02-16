namespace aps_project;

public class Employee : Entity
{
    public double Wage { get; private set; }
    public string Role { get; private set; }
    public int CompanyId { get; private set; }
    public string Cpf { get; private set; }

    public Employee(double wage, string role, int companyId, string cpf, string name, string email, string phone, string address)
        : base(name, email, phone, address)
    {
        this.Wage = wage;
        this.Role = role;
        this.CompanyId = companyId;
        this.Cpf = cpf;
    }
}