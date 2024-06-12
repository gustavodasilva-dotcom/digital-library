using AutoMapper;
using DigitalLibrary.Common.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Application.Authors.Commands.RegisterAuthor;
using DigitalLibrary.Modules.Books.Application.Contracts;
using DigitalLibrary.Modules.Books.Domain.Abstractions;
using DigitalLibrary.Modules.Books.Domain.Entities;
using FluentAssertions;
using Moq;

namespace DigitalLibrary.Modules.Books.UnitTests.Application.Commands;

public class RegisterAuthorCommandHandlerTests
{
    private readonly Mock<IAuthorRepository> _authorRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<IMapper> _mapper;

    public RegisterAuthorCommandHandlerTests()
    {
        _authorRepository = new Mock<IAuthorRepository>();
        _unitOfWork = new Mock<IUnitOfWork>();
        _mapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Should_RegisterAuthor_WhenDataIsCorrect()
    {
        // Arrange
        var response = new AuthorContracts.AuthorResponse()
        {
            Id = Guid.NewGuid(),
            Name = "Arthur Schopenhauer",
            About = "Arthur Schopenhauer was among the first 19th century philosophers to contend that at its core, the universe is not a rational place.",
            CreatedDate = DateTime.Now
        };

        _mapper.Setup(
            a => a.Map<AuthorContracts.AuthorResponse>(
                It.IsAny<Author>()))
            .Returns(response);

        var command = new RegisterAuthorCommand(
            Name: "Arthur Schopenhauer",
            About: "Arthur Schopenhauer was among the first 19th century philosophers to contend that at its core, the universe is not a rational place.");

        var handler = new RegisterAuthorCommandHandler(
            _authorRepository.Object,
            _unitOfWork.Object,
            _mapper.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        _authorRepository.Verify(
            a => a.GetByName(It.IsAny<string>()),
            Times.Once);

        _authorRepository.Verify(
            a => a.Add(It.IsAny<Author>()),
            Times.Once);

        _unitOfWork.Verify(
            u => u.SaveChangesAsync(default),
            Times.Once);

        _mapper.Verify(
            m => m.Map<AuthorContracts.AuthorResponse>(It.IsAny<Author>()),
            Times.Once);

        result.IsSuccess.Should().BeTrue();
        result.Value!.Id.Should().NotBe(Guid.Empty);
        result.Value.Name.Should().Be(command.Name);
        result.Value.About.Should().Be(command.About);
    }
}
