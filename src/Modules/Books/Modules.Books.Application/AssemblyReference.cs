using System.Reflection;

namespace DigitalLibrary.Modules.Books.Application;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
