namespace aps_project;

public class Transaction
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Date { get;  set; }
    public string Type { get;  set; }
    public double Value { get;  set; }
    public string Status { get; set; }
    
    public Transaction(int id, string desc, string date, string type, double value, string status)
    {
        Id = id;
        Description = desc;
        Date = date;
        Type = type;
        Value = value;
        Status = status;
    }

    public void CalculateExpenses()
    {
        Console.WriteLine("Calculating Expenses...");
    }
}