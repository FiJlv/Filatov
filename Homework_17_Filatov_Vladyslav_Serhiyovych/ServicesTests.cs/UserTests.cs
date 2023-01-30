using Homework_17_Filatov_Vladyslav_Serhiyovych.Controllers;
using Homework_17_Filatov_Vladyslav_Serhiyovych.Models.DTO;
using Homework_17_Filatov_Vladyslav_Serhiyovych.Stubs;
using Homework_17_Filatov_Vladyslav_Serhiyovych.Validators;
using Moq;

namespace ServicesTests.cs
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateUser_CorrectValidation_Success()
        {
            // Arrange
            var name = "Alex";
            var password = "password";
            var email = "alex@gmail.com";
            var expected = true;
            var expectedMessage = "Success";

            var passwordMock = new Mock<IPasswordValidator>();                                                                                   
            passwordMock.Setup(x => x.IsPasswordValid(password)).Returns(true);
            var emailValidator = new EmailValidator();
            var userController = new UserController(passwordMock.Object, emailValidator);
            var user = new CreateUserDTO()
            {
                Name = name,
                Password = password,
                Email = email
            };

            // Act
            var result = userController.ValidateUserDto(user, out string message);

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ValidateUser_WrongName_CorrectMessage()
        {
            // Arrange
            var name = "Al";
            var password = "password";
            var email = "alex@gmail.com";
            var expected = false;
            var expectedMessage = "Wrong name";

            var passwordMock = new Mock<IPasswordValidator>();
            passwordMock.Setup(x => x.IsPasswordValid(password)).Returns(true);
            var emailValidator = new EmailValidator();
            var userController = new UserController(passwordMock.Object, emailValidator);
            var user = new CreateUserDTO()
            {
                Name = name,
                Password = password,
                Email = email
            };

            // Act
            var result = userController.ValidateUserDto(user, out string message);

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ValidateUser_WrongPassword_CorrectMessage()
        {
            // Arrange
            var name = "Alex";
            var password = "";
            var email = "alex@gmail.com";
            var expected = false;
            var expectedMessage = "Wrong password";

            var passwordMock = new Mock<IPasswordValidator>();
            passwordMock.Setup(x => x.IsPasswordValid(password)).Returns(false);
            var emailValidator = new EmailValidator();
            var userController = new UserController(passwordMock.Object, emailValidator);
            var user = new CreateUserDTO()
            {
                Name = name,
                Password = password,
                Email = email
            };

            // Act
            var result = userController.ValidateUserDto(user, out string message);

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void ValidateUser_WrongName_PasswordValidatorWasNeverCalled()
        {
            // Arrange
            var name = "";
            var password = "password";
            var email = "alex@gmail.com";
            var user = new CreateUserDTO
            {
                Name = name,
                Password = password,
                Email = email
            };
            var mock = new Mock<IPasswordValidator>();
            var emailValidator = new EmailValidator();
            var userController = new UserController(mock.Object, emailValidator);

            // Act
            var result = userController.ValidateUserDto(user, out string message);

            // Assert
            mock.Verify(x => x.IsPasswordValid(password), Times.Never);
        }

        [Test]
        [TestCase("Alex", "password", "alexgmail.com", false, "Wrong email")]
        [TestCase("Alex", "password", "al@gmailcom", false, "Wrong email")]
        [TestCase("Alex", "password", "gmail.com", false, "Wrong email")]
        [TestCase("Alex", "password", "@.c", false, "Wrong email")]
        public void ValidateUser_WrongEmail_CorrectMessage(string name, string password, 
            string email, bool expected, string expectedMessage)
        {
            // Arrange
            var passwordMock = new Mock<IPasswordValidator>();
            passwordMock.Setup(x => x.IsPasswordValid(password)).Returns(true);
            var emailValidator = new EmailValidator();
            var userController = new UserController(passwordMock.Object, emailValidator);
            var user = new CreateUserDTO()
            {
                Name = name,
                Password = password,
                Email = email
            };

            // Act
            var result = userController.ValidateUserDto(user, out string message);

            // Assert
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expectedMessage, message);
        }
    }
}