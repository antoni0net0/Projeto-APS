namespace aps_project;

class Company : Entity
{
    public string Password { get; private set; }
    public string Cnpj { get; private set; }
    private List<Employee> EmployeeList;

    public Company(string password, string cnpj)
    {
        Password = password;
        Cnpj = cnpj;
        EmployeeList = new List<Employee>();
    }
        
    public void Login()
    {
    }

    public void Logout()
    {
    }

    public void CheckExpenses(List<Employee> list)
    {
    }
}