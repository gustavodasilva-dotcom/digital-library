namespace DigitalLibrary.Modules.Lendings.Endpoints.Routes;

internal static class LendingsRoutes
{
    public const string Tag = "lendings";

    public const string Register = "api/lendings";

    public const string Conclude = "api/lendings/conclude/{code}";

    public const string Cancel = "api/lendings/cancel/{code}";
}
