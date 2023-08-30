using ZOOMValidation.Rules;

namespace ZOOMValidation.Tests.Email
{
    public class EmailTests
    {
        [Fact]
        public async Task ValidEmailTest()
        {
            var email = new ValidatableObject<string>();
            email.ValidationRules.Add(new ValidEmailRule<string>("Invalid password length."));

            email.Value = "asd";
            Assert.False(await email.Validate());

            email.Value = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd";
            Assert.False(await email.Validate());

            email.Value = "asd.asd.asd@";
            Assert.False(await email.Validate());

            email.Value = "asd@asd.com";
            Assert.True(await email.Validate());

            email.Value = " asd@ asd .com ";
            Assert.True(await email.Validate());
        }
    }
}
