using System;

class Transaction
{
    public string Date { get; private set; }
    public string Type { get; private set; }
    public double Value { get; private set; }

    public Transaction() { }

    public Transaction(string date, string type, double value)
    {
        Date = date;
        Type = type;
        Value = value;
    }

    public void CalculateExpenses()
    {
        Console.WriteLine("Calculating Expenses...");
    }
}