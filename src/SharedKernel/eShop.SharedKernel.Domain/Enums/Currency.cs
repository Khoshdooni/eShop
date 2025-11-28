using eShop.SharedKernel.Domain.Primitives;

namespace eShop.SharedKernel.Domain.Enums;

public sealed class Currency:Enumeration<Currency>
{
    public string Symbol { get; }
    public Currency(int id,string code,string name,string symbol):base(id,name,code)
    {
        Symbol=symbol;
    }

    public static void LoadFromList(IEnumerable<(int Id,string Code,string Name,string Symbol)> items)
    {
        foreach (var item in items) 
        { 
            Register(new Currency(item.Id,item.Code,item.Name,item.Symbol));
        
        }
    }



}
