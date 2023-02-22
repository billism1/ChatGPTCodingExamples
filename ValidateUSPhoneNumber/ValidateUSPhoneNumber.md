> Write a C# method to validate a US phone number.

---

Here is an example C# method to validate a US phone number using regular expressions:

csharp

```csharp
public static bool ValidatePhoneNumber(string phoneNumber)
{
    // Regular expression to match US phone number pattern
    string pattern = @"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$";
    // Use Regex.IsMatch method to check if the phone number matches the pattern
    return Regex.IsMatch(phoneNumber, pattern);
}
```

This method takes a `string` parameter `phoneNumber` representing the phone number to validate, and returns a `bool` value indicating whether the phone number is valid or not.

The regular expression pattern used in this method matches the US phone number format, which can have optional parentheses, dots, or dashes separating the three groups of digits. The first group of digits represents the area code, the second group represents the central office code, and the third group represents the line number.

You can call this method like this:

csharp

```csharp
string phoneNumber = "123-456-7890";
bool isValid = ValidatePhoneNumber(phoneNumber);
Console.WriteLine($"The phone number {phoneNumber} is {(isValid ? "valid" : "invalid")}");
```

This will output "The phone number 123-456-7890 is valid" if the phone number is valid according to the regular expression pattern, and "The phone number 123-456-7890 is invalid" otherwise.

---

> Can you rewrite it to not use regex?

---

Yes, here is an example C# method that validates a US phone number without using regular expressions:

csharp

```csharp
public static bool ValidatePhoneNumber(string phoneNumber)
{
    // Remove any non-digit characters from the phone number
    string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());
    
    // Check if the resulting string has 10 digits
    if (digitsOnly.Length != 10)
    {
        return false;
    }

    // Check if the first digit is not 0 or 1
    if (digitsOnly[0] == '0' || digitsOnly[0] == '1')
    {
        return false;
    }

    // Check if the fourth and seventh digits are not a dash or a space
    if (digitsOnly[3] != '-' && digitsOnly[3] != ' ' && digitsOnly[6] != '-' && digitsOnly[6] != ' ')
    {
        return false;
    }

    // Phone number is valid
    return true;
}
```

This method also takes a `string` parameter `phoneNumber` representing the phone number to validate, and returns a `bool` value indicating whether the phone number is valid or not.

Instead of using regular expressions, this method first removes any non-digit characters from the input string using LINQ `Where` method and `char.IsDigit` predicate. It then checks if the resulting string has exactly 10 digits, if the first digit is not 0 or 1, and if the fourth and seventh digits are either a dash or a space. If any of these conditions are not met, the method returns `false`. Otherwise, it returns `true`.

You can call this method in the same way as before:

csharp

```csharp
string phoneNumber = "123-456-7890";
bool isValid = ValidatePhoneNumber(phoneNumber);
Console.WriteLine($"The phone number {phoneNumber} is {(isValid ? "valid" : "invalid")}");
```

This will output the same result as before, but without using regular expressions.

---