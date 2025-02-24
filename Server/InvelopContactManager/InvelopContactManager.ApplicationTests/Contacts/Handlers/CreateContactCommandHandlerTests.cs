using FluentValidation;
using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Application.Contacts.Handlers;
using InvelopContactManager.Domain.Models;
using InvelopContactManager.Infrastructure;
using Moq;
using System.Net.Http.Json;
using Xunit;

namespace InvelopContactManager.Tests.Application
{
    public class CreateContactCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ShouldCreateContact()
        {
            // Arrange
            var mockContext = new Mock<InvelopDbContext>();
            var mockDbSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<Contact>>();
            var mockValidator = new Mock<IValidator<CreateContactCommand>>();

            mockContext.Setup(m => m.Contacts).Returns(mockDbSet.Object);
            mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var handler = new CreateContactCommandHandler(mockContext.Object, mockValidator.Object);
            var command = new CreateContactCommand
            {
                FirstName = "John",
                Surname = "Doe",
                Dob = new DateTime(1990, 1, 1),
                Address = "123 Main St",
                PhoneNumber = "+1234567890",
                Iban = "BG80BNBG96611020345678"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsOk);
        }
    }
}