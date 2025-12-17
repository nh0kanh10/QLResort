using System;
using System.Linq;

namespace Tool_QLResort.Validation
{
    public static class SimpleValidator
    {
        public static ValidationResult ValidateEmail(string email, bool required = false)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return required 
                    ? ValidationResult.Fail("Email không được để trống")
                    : ValidationResult.Success;
            }

            
            if (!email.Contains("@"))
                return ValidationResult.Fail("Email phải chứa ký tự @");

            var parts = email.Split('@');
            if (parts.Length != 2)
                return ValidationResult.Fail("Email không hợp lệ");

            if (string.IsNullOrWhiteSpace(parts[0]))
                return ValidationResult.Fail("Email phải có phần trước @");

            if (!parts[1].Contains("."))
                return ValidationResult.Fail("Email phải có domain hợp lệ (ví dụ: @gmail.com)");

            if (email.Length > 100)
                return ValidationResult.Fail("Email không được vượt quá 100 ký tự");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidatePhoneNumber(string phone, bool required = false)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return required
                    ? ValidationResult.Fail("Số điện thoại không được để trống")
                    : ValidationResult.Success;
            }

            phone = phone.Replace(" ", "").Replace("-", "");

            if (phone.Length < 9 || phone.Length > 11)
                return ValidationResult.Fail("Số điện thoại phải có từ 9 đến 11 chữ số");

            if (phone.StartsWith("+84"))
                phone = "0" + phone.Substring(3);

            if (!phone.All(char.IsDigit))
                return ValidationResult.Fail("Số điện thoại chỉ được chứa chữ số");

            if (!phone.StartsWith("0"))
                return ValidationResult.Fail("Số điện thoại phải bắt đầu bằng 0");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidateCCCD(string cccd, bool required = true)
        {
            if (string.IsNullOrWhiteSpace(cccd))
            {
                return required
                    ? ValidationResult.Fail("CCCD/CMND không được để trống")
                    : ValidationResult.Success;
            }

            // CCCD mới có 12 chữ số, CMND cũ có 9 chữ số
            if (cccd.Length != 12 && cccd.Length != 9)
                return ValidationResult.Fail("CCCD/CMND phải có 9 hoặc 12 chữ số");

            if (!cccd.All(char.IsDigit))
                return ValidationResult.Fail("CCCD/CMND chỉ được chứa chữ số");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidatePassport(string passport, bool required = false)
        {
            if (string.IsNullOrWhiteSpace(passport))
            {
                return required
                    ? ValidationResult.Fail("Passport không được để trống")
                    : ValidationResult.Success;
            }

            // Passport: 1 chữ cái in hoa + 7-8 chữ số
            if (passport.Length < 8 || passport.Length > 9)
                return ValidationResult.Fail("Passport phải có 8-9 ký tự (1 chữ cái + 7-8 chữ số)");

            if (!char.IsLetter(passport[0]) || !char.IsUpper(passport[0]))
                return ValidationResult.Fail("Passport phải bắt đầu bằng chữ cái in hoa");

            if (!passport.Substring(1).All(char.IsDigit))
                return ValidationResult.Fail("Passport phải có 7-8 chữ số sau chữ cái đầu");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidateName(string name, bool required = true, int maxLength = 200)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return required
                    ? ValidationResult.Fail("Họ tên không được để trống")
                    : ValidationResult.Success;
            }

            if (name.Length > maxLength)
                return ValidationResult.Fail($"Họ tên không được vượt quá {maxLength} ký tự");

            if (name.Length < 2)
                return ValidationResult.Fail("Họ tên phải có ít nhất 2 ký tự");

            // Kiểm tra không chứa số
            if (name.Any(char.IsDigit))
                return ValidationResult.Fail("Họ tên không được chứa số");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidateDateOfBirth(DateTime? dateOfBirth, bool required = false)
        {
            if (!dateOfBirth.HasValue)
            {
                return required
                    ? ValidationResult.Fail("Ngày sinh không được để trống")
                    : ValidationResult.Success;
            }

            if (dateOfBirth.Value.Date > DateTime.Now.Date)
                return ValidationResult.Fail("Ngày sinh không được lớn hơn ngày hiện tại");

            var age = DateTime.Now.Year - dateOfBirth.Value.Year;
            if (age < 0 || age > 150)
                return ValidationResult.Fail("Ngày sinh không hợp lệ");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidateCode(string code, bool required = true, int minLength = 3, int maxLength = 20)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return required
                    ? ValidationResult.Fail("Mã không được để trống")
                    : ValidationResult.Success;
            }

            if (code.Length < minLength || code.Length > maxLength)
                return ValidationResult.Fail($"Mã phải có từ {minLength} đến {maxLength} ký tự");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidateAddress(string address, bool required = false, int maxLength = 300)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return required
                    ? ValidationResult.Fail("Địa chỉ không được để trống")
                    : ValidationResult.Success;
            }

            if (address.Length > maxLength)
                return ValidationResult.Fail($"Địa chỉ không được vượt quá {maxLength} ký tự");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidatePrice(decimal? price, bool required = false, decimal minValue = 0)
        {
            if (!price.HasValue)
            {
                return required
                    ? ValidationResult.Fail("Giá không được để trống")
                    : ValidationResult.Success;
            }

            if (price.Value < minValue)
                return ValidationResult.Fail($"Giá phải lớn hơn hoặc bằng {minValue:N0}");

            return ValidationResult.Success;
        }

        
        public static ValidationResult ValidateNumber(int? number, bool required = false, int minValue = 0, int maxValue = int.MaxValue)
        {
            if (!number.HasValue)
            {
                return required
                    ? ValidationResult.Fail("Số lượng không được để trống")
                    : ValidationResult.Success;
            }

            if (number.Value < minValue)
                return ValidationResult.Fail($"Số lượng phải lớn hơn hoặc bằng {minValue}");

            if (number.Value > maxValue)
                return ValidationResult.Fail($"Số lượng không được vượt quá {maxValue}");

            return ValidationResult.Success;
        }
    }

    public class ValidationResult
    {
        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        private ValidationResult(bool isValid, string errorMessage = null)
        {
            IsValid = isValid;
            ErrorMessage = errorMessage;
        }

        public static ValidationResult Success => new ValidationResult(true);
        public static ValidationResult Fail(string errorMessage) => new ValidationResult(false, errorMessage);
    }
}








