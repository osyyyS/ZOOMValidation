using ZOOMValidation.Pair;
using ZOOMValidation.Pair.Rules;
using ZOOMValidation.Rules.Password;

namespace ZOOMValidation.Tests.Pair
{
    public class PairTests
    {
        private const string TO_SHORT = "to short";
        private const string ONE_NUMBER = "atleast one number";
        private const string ONE_LOWERCASE = "atleast one lowercase";
        private const string ONE_UPPERCASE = "atleast one uppercase";
        private const string ONE_SPECIAL = "atleast one special character";
        private const string EQUAL = "passswords need to be equal";
        [Fact]
        private async Task EqualStrongPasswordTest()
        {
            var password1 = new ValidatableObject<string>();
            var password2 = new ValidatableObject<string>();

            password1.ValidationRules.Add(new PasswordLengthRule(TO_SHORT, 8));
            password1.ValidationRules.Add(new PasswordNumberRule(ONE_NUMBER));
            password1.ValidationRules.Add(new PasswordLowercaseRule(ONE_LOWERCASE));
            password1.ValidationRules.Add(new PasswordUppercaseRule(ONE_UPPERCASE));
            password1.ValidationRules.Add(new PasswordSpecialCharacterRule(ONE_SPECIAL));

            password2.ValidationRules.Add(new PasswordLengthRule(TO_SHORT, 8));
            password2.ValidationRules.Add(new PasswordNumberRule(ONE_NUMBER));
            password2.ValidationRules.Add(new PasswordLowercaseRule(ONE_LOWERCASE));
            password2.ValidationRules.Add(new PasswordUppercaseRule(ONE_UPPERCASE));
            password2.ValidationRules.Add(new PasswordSpecialCharacterRule(ONE_SPECIAL));

            var pair = new ValidatablePair<string>(password1, password2);
            pair.PairValidationRules.Add(new EqualStringRule(EQUAL));

            pair.Item1.Value = "Asd0!asdasdasd";
            pair.Item2.Value = "Asd0!asdasdasd";

            Assert.True(await pair.Validate());

            pair.Item1.Value = "esdrg";
            pair.Item2.Value = "sdfgh";

            Assert.False(await pair.Validate());
            Assert.Equal(EQUAL, pair.Error);

            pair.Item1.Value = "asdasd";
            pair.Item2.Value = "asdasd";

            Assert.False(await pair.Validate());
            Assert.Equal(TO_SHORT, pair.Error);
        }
    }
}
