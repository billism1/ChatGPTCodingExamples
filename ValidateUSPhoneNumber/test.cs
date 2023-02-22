using System;
using System.Linq;
using System.Text.RegularExpressions;

// This was basically a complete failure.
// See results in .NET Fiddle: https://dotnetfiddle.net/iBTrDs
// See output at bottom of this file.

public class Program
{
	public static void Main()
	{
		RunTest("123-456-7890");
		RunTest("333-456-7890");
		RunTest("208-456-7890");
		RunTest("1-208-456-7890");
		RunTest("000-456-7890");
		RunTest("0001237890");
		RunTest("8324396578");
		RunTest("-456-7890");
		RunTest("456-7890");
		RunTest("Hello");
		RunTest("4");
	}
	
	private static void RunTest(string phoneNumber)
	{
		bool isValid = ValidatePhoneNumberRegEx(phoneNumber);
		Console.WriteLine($"[RegEx     ] The phone number '{phoneNumber}' is {(isValid ? "valid" : "invalid")}");
		
		isValid = ValidatePhoneNumberNoRegEx(phoneNumber);
		Console.WriteLine($"[Non-RegEx1] The phone number '{phoneNumber}' is {(isValid ? "valid" : "invalid")}");
		
		isValid = ValidatePhoneNumberNoRegEx_2(phoneNumber);
		Console.WriteLine($"[Non-RegEx2] The phone number '{phoneNumber}' is {(isValid ? "valid" : "invalid")}");
		
		isValid = ValidatePhoneNumberNoRegEx_3(phoneNumber);
		Console.WriteLine($"[Non-RegEx3] The phone number '{phoneNumber}' is {(isValid ? "valid" : "invalid")}");
		
		Console.WriteLine("----------------");
	}
	
	public static bool ValidatePhoneNumberRegEx(string phoneNumber)
	{
    	// Regular expression to match US phone number pattern
    	string pattern = @"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$";
	    // Use Regex.IsMatch method to check if the phone number matches the pattern
    	return Regex.IsMatch(phoneNumber, pattern);
	}
	
	public static bool ValidatePhoneNumberNoRegEx(string phoneNumber)
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
	
	public static bool ValidatePhoneNumberNoRegEx_2(string phoneNumber)
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

		// Check if the fourth and seventh digits are a dash or a space
		if (digitsOnly[3] != '-' && digitsOnly[3] != ' ' || digitsOnly[6] != '-' && digitsOnly[6] != ' ')
		{
			return false;
		}

		// Phone number is valid
		return true;
	}
	
	public static bool ValidatePhoneNumberNoRegEx_3(string phoneNumber)
	{
		// Remove any non-digit characters from the phone number
		string digitsOnly = new string(phoneNumber.Where(char.IsDigit).ToArray());

		// Check if the resulting string has 10 or 11 digits
		if (digitsOnly.Length != 10 && digitsOnly.Length != 11)
		{
			return false;
		}

		// Check if the first digit is 1 (if there are 11 digits)
		if (digitsOnly.Length == 11 && digitsOnly[0] != '1')
		{
			return false;
		}

		// Count the number of digits in the second and third groups
		int secondGroupLength = digitsOnly.Length == 11 ? 4 : 3;
		int thirdGroupLength = digitsOnly.Length - 7 - secondGroupLength;

		// Check that there are two groups of 3 digits and one group of 4 digits, or vice versa
		if ((secondGroupLength == 3 && thirdGroupLength == 4) || (secondGroupLength == 4 && thirdGroupLength == 3))
		{
			return true;
		}

		// Phone number is invalid
		return false;
	}
}

// OUTPUT:
//
// [RegEx     ] The phone number '123-456-7890' is valid
// [Non-RegEx1] The phone number '123-456-7890' is invalid
// [Non-RegEx2] The phone number '123-456-7890' is invalid
// [Non-RegEx3] The phone number '123-456-7890' is invalid
// ----------------
// [RegEx     ] The phone number '333-456-7890' is valid
// [Non-RegEx1] The phone number '333-456-7890' is invalid
// [Non-RegEx2] The phone number '333-456-7890' is invalid
// [Non-RegEx3] The phone number '333-456-7890' is invalid
// ----------------
// [RegEx     ] The phone number '208-456-7890' is valid
// [Non-RegEx1] The phone number '208-456-7890' is invalid
// [Non-RegEx2] The phone number '208-456-7890' is invalid
// [Non-RegEx3] The phone number '208-456-7890' is invalid
// ----------------
// [RegEx     ] The phone number '1-208-456-7890' is invalid
// [Non-RegEx1] The phone number '1-208-456-7890' is invalid
// [Non-RegEx2] The phone number '1-208-456-7890' is invalid
// [Non-RegEx3] The phone number '1-208-456-7890' is invalid
// ----------------
// [RegEx     ] The phone number '000-456-7890' is valid
// [Non-RegEx1] The phone number '000-456-7890' is invalid
// [Non-RegEx2] The phone number '000-456-7890' is invalid
// [Non-RegEx3] The phone number '000-456-7890' is invalid
// ----------------
// [RegEx     ] The phone number '0001237890' is valid
// [Non-RegEx1] The phone number '0001237890' is invalid
// [Non-RegEx2] The phone number '0001237890' is invalid
// [Non-RegEx3] The phone number '0001237890' is invalid
// ----------------
// [RegEx     ] The phone number '8324396578' is valid
// [Non-RegEx1] The phone number '8324396578' is invalid
// [Non-RegEx2] The phone number '8324396578' is invalid
// [Non-RegEx3] The phone number '8324396578' is invalid
// ----------------
// [RegEx     ] The phone number '-456-7890' is invalid
// [Non-RegEx1] The phone number '-456-7890' is invalid
// [Non-RegEx2] The phone number '-456-7890' is invalid
// [Non-RegEx3] The phone number '-456-7890' is invalid
// ----------------
// [RegEx     ] The phone number '456-7890' is invalid
// [Non-RegEx1] The phone number '456-7890' is invalid
// [Non-RegEx2] The phone number '456-7890' is invalid
// [Non-RegEx3] The phone number '456-7890' is invalid
// ----------------
// [RegEx     ] The phone number 'Hello' is invalid
// [Non-RegEx1] The phone number 'Hello' is invalid
// [Non-RegEx2] The phone number 'Hello' is invalid
// [Non-RegEx3] The phone number 'Hello' is invalid
// ----------------
// [RegEx     ] The phone number '4' is invalid
// [Non-RegEx1] The phone number '4' is invalid
// [Non-RegEx2] The phone number '4' is invalid
// [Non-RegEx3] The phone number '4' is invalid