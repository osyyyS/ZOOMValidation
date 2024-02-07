using ZOOMValidation.Rules;

namespace ZOOMValidation.Tests;

public class NotNullOrEmptyTests
{
  private const string NOT_EMPTY_OR_NULL = "value can't be empty or null";

  [Fact]
  public async Task NotNullOrEmptyTest()
  {
    var validatable = new ValidatableObject<string?>();
    validatable.ValidationRules.Add(new NotNullOrEmptyRule<string?>(NOT_EMPTY_OR_NULL));

    validatable.Value = null;
    Assert.False(await validatable.Validate());
    Assert.Equal(NOT_EMPTY_OR_NULL, validatable.Error);

    validatable.Value = "";
    Assert.False(await validatable.Validate());
    Assert.Equal(NOT_EMPTY_OR_NULL, validatable.Error);

    validatable.Value = "asdasd";
    Assert.True(await validatable.Validate());
  }
}
