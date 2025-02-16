namespace aps_project;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Date { get;  set; }
    public string Type { get;  set; }
    public double Value { get;  set; }
    public string Status { get; set; }
    public int CompanyId { get; set; }
    
    public Transaction(string desc, string date, string type, double value, string status, int companyId, int? id)
    {
        if (id == null)
        {
            Id = -1;
        }
        else
        {
            Id = (int)id;
        }
        Description = desc;
        Date = date;
        Type = type;
        Value = value;
        Status = status;
        CompanyId = companyId;
    }

    public void CalculateExpenses()
    {
        Console.WriteLine("Calculating Expenses...");
    }
}