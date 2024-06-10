using System.Reflection;

namespace DigitalLibrary.Modules.Patrons.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
