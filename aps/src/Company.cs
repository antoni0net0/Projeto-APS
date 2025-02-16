namespace aps_project;

public class Company : Entity
{
    public string Role { get; set; }
    public string Cnpj { get; set; }

    public Company (string name, string email, string phone, string address, string role, string cnpj)
            : base(name, email, phone, address)
    {
        Role = role;
        Cnpj = cnpj;
    }

}