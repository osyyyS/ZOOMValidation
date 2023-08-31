using ZOOMValidation.Rules.Password;

namespace ZOOMValidation.Tests.Password
{
    public class PasswordTests
    {
        private const string TO_COMMON = "password is to common";

        [Fact]
        public async Task UniquePasswordTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new UniquePasswordRule(TO_COMMON));

            password.Value = "asd";
            Assert.False(await password.Validate());
            Assert.Equal(TO_COMMON, password.Error);

            password.Value = "[${y9mL011`@";
            Assert.True(await password.Validate());
        }

        [Fact]
        public async Task PasswordLengthTest()
        {
            var password = new ValidatableObject<string>();
            password.ValidationRules.Add(new PasswordLengthRule("Invalid password length.", 12, 24));

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
            password.ValidationRules.Add(new PasswordNumberRule("Invalid password number amount.", maxNumbers: 3));

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
            password.ValidationRules.Add(new PasswordUppercaseRule("Invalid password uppercase amount.", maxUppercase: 3));

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
            password.ValidationRules.Add(new PasswordLowercaseRule("Invalid password lowercase amount.", maxLowercase: 3));

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
            password.ValidationRules.Add(new PasswordSpecialCharacterRule("Invalid password special characters amount.", maxSpecialCharacters: 3));

            password.Value = "asd";
            Assert.False(await password.Validate());

            password.Value = "asd!=?-";
            Assert.False(await password.Validate());

            password.Value = "asd!";
            Assert.True(await password.Validate());
        }
    }
}