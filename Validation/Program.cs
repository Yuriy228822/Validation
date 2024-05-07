using System;
using System.Collections.Generic;
using Validation;

class Program
{
    static void Main(string[] args)
    {
        // Создание экземпляров валидаторов
        var loginValidator = new LoginValidator();
        var passwordValidator = new PasswordValidator();

        // Тестирование с помощью атрибута DataRow
        TestWithDataRow(loginValidator, passwordValidator);

        // Тестирование с помощью атрибута DynamicData
        TestWithDynamicData(loginValidator, passwordValidator);

        // Тестирование собственного атрибута
        TestWithCustomAttribute(loginValidator, passwordValidator);

        Console.ReadLine();
    }

    static void TestWithDataRow(LoginValidator loginValidator, PasswordValidator passwordValidator)
    {
        Console.WriteLine("Testing with DataRow attribute:");

        // Тестирование логина
        Console.WriteLine("Testing login validation:");
        foreach (var data in GetLoginTestData())
        {
            Console.WriteLine($"Login: {data}, Valid: {loginValidator.Validate(data)}");
        }

        // Тестирование пароля
        Console.WriteLine("Testing password validation:");
        foreach (var data in GetPasswordTestData())
        {
            Console.WriteLine($"Password: {data}, Valid: {passwordValidator.Validate(data)}");
        }

        Console.WriteLine();
    }

    static void TestWithDynamicData(LoginValidator loginValidator, PasswordValidator passwordValidator)
    {
        Console.WriteLine("Testing with DynamicData attribute:");

        // Тестирование логина
        Console.WriteLine("Testing login validation:");
        Console.WriteLine($"Login: \"test\", Valid: {loginValidator.Validate("test")}");
        Console.WriteLine($"Login: \"123\", Valid: {loginValidator.Validate("123")}");

        // Тестирование пароля
        Console.WriteLine("Testing password validation:");
        Console.WriteLine($"Password: \"password123!\", Valid: {passwordValidator.Validate("password123!")}");
        Console.WriteLine($"Password: \"short\", Valid: {passwordValidator.Validate("short")}");

        Console.WriteLine();
    }

    static void TestWithCustomAttribute(LoginValidator loginValidator, PasswordValidator passwordValidator)
    {
        Console.WriteLine("Testing with custom attribute:");

        // Тестирование логина
        Console.WriteLine($"Login: \"myusername\", Valid: {loginValidator.Validate("myusername")}");

        // Тестирование пароля
        Console.WriteLine($"Password: \"mysecretpassword123!\", Valid: {passwordValidator.Validate("mysecretpassword123!")}");

        Console.WriteLine();
    }

    static IEnumerable<string> GetLoginTestData()
    {
        yield return "username";
        yield return "user123";
        yield return "userwithaverylongusername";
        yield return "user!";
        yield return "user@";
    }

    static IEnumerable<string> GetPasswordTestData()
    {
        yield return "password";
        yield return "12345678";
        yield return "password123";
        yield return "Password123!";
        yield return "passwordwithaverylonglength123456";
        yield return "passwordwithoutspecialchar123";
        yield return "PASSWORDWITHOUTLOWERCASE123!";
    }
}
