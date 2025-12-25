using System.Reflection;

namespace eShop.Catalog.Presentation;

public static class AssemblyReference
{
    public static Assembly Reference => typeof(AssemblyReference).Assembly;
}
