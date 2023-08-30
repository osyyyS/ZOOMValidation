using ZOOMValidation.Rules.Password;

namespace ZOOMValidation.Tests.Password
{
    public class PasswordTests
    {
        [Fact]
        public async Task PasswordLengthTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new PasswordLengthRule<string>("Invalid password length.", 12, 24));

            password.Value = "asd";
            Assert.False(await password.Validate());

            password.Value = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd";
            Assert.False(await password.Validate());

            password.Value = "asdasdasdasd";
            Assert.True(await password.Validate());
        }

        [Fact]
        public async Task PasswordNumberTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new PasswordNumberRule<string>("Invalid password number amount.", maximumNumbers: 3));

            password.Value = "asd";
            Assert.False(await password.Validate());

            password.Value = "1a2d3g4";
            Assert.False(await password.Validate());

            password.Value = "asd1";
            Assert.True(await password.Validate());
        }

        [Fact]
        public async Task PasswordUppercaseTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new PasswordUppercaseRule<string>("Invalid password uppercase amount.", maximumNumbers: 3));

            password.Value = "asd";
            Assert.False(await password.Validate());

            password.Value = "ASDF";
            Assert.False(await password.Validate());

            password.Value = "Asd";
            Assert.True(await password.Validate());
        }

        [Fact]
        public async Task PasswordLowercaseTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new PasswordLowercaseRule<string>("Invalid password lowercase amount.", maximumNumbers: 3));

            password.Value = "ASD";
            Assert.False(await password.Validate());

            password.Value = "asdf";
            Assert.False(await password.Validate());

            password.Value = "aSD";
            Assert.True(await password.Validate());
        }

        [Fact]
        public async Task PasswordSpecialCharactersTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new PasswordSpecialCharacterRule<string>("Invalid password special characters amount.", maximumNumbers: 3));

            password.Value = "asd";
            Assert.False(await password.Validate());

            password.Value = "asd!=?-";
            Assert.False(await password.Validate());

            password.Value = "asd!";
            Assert.True(await password.Validate());
        }
    }
}