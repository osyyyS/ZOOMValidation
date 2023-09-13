# ZOOMValidation
 Observable implementation of validation pattern
 
 ## Install

- 📦 [NuGet](https://www.nuget.org/packages/ZOOMValidation): `dotnet add package ZOOMValidation`

## Usage

### ValidatableObject

#### Add **rules**

You can add rules that implement `IValidationRule` or `IAsyncValidationRule`:

```csharp
using ZOOMValidation;

var password = new ValidatableObject<string>();

password.ValidationRules.Add(new PasswordLengthRule("Password length must be between 12 and 24 characters", 12, 24));
password.AsyncValidationRules.Add(new PwnedPasswordRule("Password is pwned!"));
```

You can also add a rule without creating a class by using `ValidationRule` or `AsyncValidationRule`:
```csharp
using ZOOMValidation;

var name = new ValidatableObject<string>();

name.ValidationRules.Add(new ValidationRule<string>("Name can't be empty!", name => !string.IsNullOrEmpty(name)));
name.AsyncValidationRules.Add(new AsyncValidationRule<string>("error", async name => await ...));
```

#### Validate **rules**

To validate your rules simply await `.Validate()`:
```csharp
bool isValid = await password.Validate();
```

### ValidatablePair
