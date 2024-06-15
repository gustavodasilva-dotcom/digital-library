using DigitalLibrary.Common.Domain.Shared;

namespace DigitalLibrary.Modules.Books.Application.Exceptions;

internal sealed class NotAllowedOperationException(Error error)
    : BaseApplicationException($"{error.Code}: {error.Message}");
