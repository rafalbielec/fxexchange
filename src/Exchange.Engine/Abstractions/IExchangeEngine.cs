namespace Exchange.Engine.Abstractions;

public interface IExchangeEngine
{
    public decimal ConvertAmount(string pairName, decimal sourceAmount);
}