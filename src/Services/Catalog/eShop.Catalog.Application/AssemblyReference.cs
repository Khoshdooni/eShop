using System.Reflection;

namespace eShop.Catalog.Application;

public static class AssemblyReference
{
    public static Assembly Reference => typeof(AssemblyReference).Assembly;
}
