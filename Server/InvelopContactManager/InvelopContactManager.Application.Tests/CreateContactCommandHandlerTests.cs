using InvelopContactManager.Application.Contacts.Commands;
using InvelopContactManager.Application.Contacts.Handlers;
using InvelopContactManager.Application.Contacts.Validators;
using InvelopContactManager.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace InvelopContactManager.Application.Tests
{
    public class CreateContactCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTrue_WhenDataIsValid()
        {
            // Can add Moq for more flexibility as well
            // Arrange
            var options = new DbContextOptionsBuilder<InvelopDbContext>()
                 .UseInMemoryDatabase(databaseName: "Invelop")
                 .Options;

            using var context = new InvelopDbContext(options);
            var validator = new CreateContactValidator();

            var handler = new CreateContactCommandHandler(context, validator);
            var command = new CreateContactCommand
            {
                FirstName = "Test1",
                Surname = "Test2",
                Dob = new DateTime(1990, 1, 1),
                Address = "Address4",
                PhoneNumber = "+359897485041",
                Iban = "BG80BNBG96611020345678"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsOk);
        }
    }
}