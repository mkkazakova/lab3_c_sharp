using System;

// Доступен элементу из соответствующего класса и производных классов.
class Currency
{
    protected double value;
}

class CurrencyRUB : Currency
{
    public CurrencyRUB(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyUSD(CurrencyRUB val)
    {
        return new CurrencyUSD(val.value / CurrencyUSD.ExChange);
    }
    public static implicit operator CurrencyEUR(CurrencyRUB val)
    {
        return new CurrencyEUR(val.value / CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyUSD : Currency
{
    public static double ExChange { get; set; }
    public CurrencyUSD(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyEUR(CurrencyUSD val)
    {
        return new CurrencyEUR(val.value * CurrencyUSD.ExChange / CurrencyEUR.ExChange);
    }
    public static implicit operator CurrencyRUB(CurrencyUSD val)
    {
        return new CurrencyRUB(val.value * CurrencyUSD.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyEUR : Currency
{
    public static double ExChange { get; set; }

    public CurrencyEUR(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyRUB(CurrencyEUR val)
    {
        return new CurrencyRUB(val.value * CurrencyEUR.ExChange);
    }
    public static implicit operator CurrencyUSD(CurrencyEUR val)
    {
        return new CurrencyUSD(val.value * CurrencyEUR.ExChange / CurrencyUSD.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        CurrencyEUR.ExChange = 103.935;
        CurrencyUSD.ExChange = 98.7575;

        Console.Write("Выберите целевую валюту (USD, EUR, RUB): ");
        string inputCurrency = Console.ReadLine().ToUpper();

        Console.Write("Введите сумму в исходной валюте: ");
        double inputValue = double.Parse(Console.ReadLine());

        Console.Write("Выберите целевую валюту (USD, EUR, RUB): ");
        string toCurrency = Console.ReadLine().ToUpper();



        // Смотрим в какую перевести
        switch ((inputCurrency, toCurrency))
        {
            case ("RUB", "USD"):
                CurrencyRUB a1 = new CurrencyRUB(inputValue);
                CurrencyUSD b1 = a1;
                Console.WriteLine($"It's {b1.Value.ToString("F2")} USD");
                break;
            case ("EUR", "USD"):
                CurrencyEUR a2 = new CurrencyEUR(inputValue);
                CurrencyUSD b2 = a2;
                Console.WriteLine($"It's {b2.Value.ToString("F2")} USD");
                break;
            case ("RUB", "EUR"):
                CurrencyRUB a3 = new CurrencyRUB(inputValue);
                CurrencyEUR b3 = a3;
                Console.WriteLine($"It's {b3.Value.ToString("F2")} EUR");
                break;
            case ("USD", "EUR"):
                CurrencyUSD a4 = new CurrencyUSD(inputValue);
                CurrencyEUR b4 = a4;
                Console.WriteLine($"It's {b4.Value.ToString("F2")} EUR");
                break;
            case ("EUR", "RUB"):
                CurrencyEUR a5 = new CurrencyEUR(inputValue);
                CurrencyRUB b5 = a5;
                Console.WriteLine($"It's {b5.Value.ToString("F2")} RUB");
                break;
            case ("USD", "RUB"):
                CurrencyUSD a6 = new CurrencyUSD(inputValue);
                CurrencyRUB b6 = a6;
                Console.WriteLine($"It's {b6.Value.ToString("F2")} RUB");
                break;
            default:
                Console.WriteLine("Неверно выбрана целевая валюта.");
                break;
        }

    }
}