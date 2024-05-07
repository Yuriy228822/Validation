using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Validation
{
    

    public class LoginValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины логина
            if (validateObject.Length < 6 || validateObject.Length > 16)
                return false;

            // Проверка на использование только латинских символов
            if (!Regex.IsMatch(validateObject, @"^[a-zA-Z]+$"))
                return false;

            return true;
        }
    }

    public class PasswordValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrWhiteSpace(validateObject))
                return false;

            // Проверка длины пароля
            if (validateObject.Length < 8 || validateObject.Length > 20)
                return false;

            // Проверка на наличие хотя бы одной заглавной буквы, одной цифры и одного спец. символа
            if (!Regex.IsMatch(validateObject, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*-_]).+$"))
                return false;

            return true;
        }
    }

}
