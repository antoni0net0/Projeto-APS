namespace aps_project;

public class Entity
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Address { get; private set; }

    public Entity( string name, string email, string phone, string address)
    {
        Id = -1;
        Name = name;
        Email = email;
        Phone = phone;
        Address = address;
    }
    
}
