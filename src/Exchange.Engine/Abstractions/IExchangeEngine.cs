namespace Exchange.Engine.Abstractions;

public interface IExchangeEngine
{
    /// <summary>
    ///     Takes a pair of currencies in a specific format and the source amount,
    ///     and converts the amount int the target currency.
    /// </summary>
    /// <param name="pairName">CUR/CUR</param>
    /// <param name="amount">122.99</param>
    /// <returns>Converted amount in the target currency</returns>
    public decimal ConvertAmount(string pairName, decimal amount);
}