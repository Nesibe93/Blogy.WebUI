using Microsoft.AspNetCore.Identity;

namespace Blogy.WebUI.Models
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        //override : Bir metodu veya özelliği ezme veya geçersiz kılma anlamına gelir. Bir sınıf içinde, bir üyenin (metod, özellik, indeksleyici vb.) temel sınıftan miras alınan sürümünü değiştirmek veya genişletmek için override kullanılır. 
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = "Lütfen en az 6 karakter şifre girişi yapınız" // Şifre işlemini kendi istediğimiz formata dönüştürmüş olduk
            };
        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "Lütfen en az 1 tane büyük harf girişi yapınız"
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "Lütfen en az 1 tane küçük harf girişi yapınız"
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Lütfen en az 1 tane sembol girişi yapınız"
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "Lütfen en az 1 tane rakam girişi yapınız"
            };
        }
    }
}
