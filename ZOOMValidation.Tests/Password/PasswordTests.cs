using ZOOMValidation.Rules.Password;

namespace ZOOMValidation.Tests.Password
{
    public class PasswordTests
    {
        private const string TO_COMMON = "password is too common";
        private const string INVALID_LENGTH = "Invalid password length.";
        private const string INVALID_NUMBER_AMOUNT = "Invalid password number amount.";
        private const string INVALID_UPPERCASE_AMOUNT = "Invalid password uppercase amount.";
        private const string INVALID_LOWERCASE_AMOUNT = "Invalid password lowercase amount.";
        private const string INVALID_SPECIAL_CHARACTERS_AMOUNT = "Invalid password special characters amount.";

        [Fact]
        public async Task PwnedPasswordTest()
        {
            var password = new ValidatableObject<string>();
            password.AsyncValidationRules.Add(new PwnedPasswordRule(TO_COMMON));

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
            password.ValidationRules.Add(new PasswordLengthRule(INVALID_LENGTH, 12, 24));

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
            password.ValidationRules.Add(new PasswordNumberRule(INVALID_NUMBER_AMOUNT, maxNumbers: 3));

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
            password.ValidationRules.Add(new PasswordUppercaseRule(INVALID_UPPERCASE_AMOUNT, maxUppercase: 3));

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
            password.ValidationRules.Add(new PasswordLowercaseRule(INVALID_LOWERCASE_AMOUNT, maxLowercase: 3));

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
            password.ValidationRules.Add(new PasswordSpecialCharacterRule(INVALID_SPECIAL_CHARACTERS_AMOUNT, maxSpecialCharacters: 3));

            password.Value = "asd";
            Assert.False(await password.Validate());

            password.Value = "asd!=?-";
            Assert.False(await password.Validate());

            password.Value = "asd!";
            Assert.True(await password.Validate());
        }
    }
}