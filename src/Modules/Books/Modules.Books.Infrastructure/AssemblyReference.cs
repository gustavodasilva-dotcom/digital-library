using System.Reflection;

namespace DigitalLibrary.Modules.Books.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
