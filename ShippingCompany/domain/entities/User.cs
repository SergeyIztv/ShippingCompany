using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using ShippingCompany.domain.entities;

namespace ShippingCompany.Domain.Entities
{
    [Table("User")]
    public class User
    {
        [Column("Id")]
        public long Id { get; private set; }
        [Column("Login")]
        public string Login { get; set; }
        
        // Поля для хранения хэшированного пароля и соли
        [Column("PasswordHash")]
        public string PasswordHash { get; internal set; }
        [Column("Salt")]
        public string Salt { get; private set; }
        
        // Навигационное свойство для доступа к связанным UserMenuItem
        public virtual ICollection<UserMenuItem> UserMenuItems { get; set; } = new List<UserMenuItem>();

        // Пустой конструктор
        public User() {}

        public User(string login, string password) // Передаем в констуктор пароль, который в этом же констукторе хешируется
        {
            this.Login = login;
            SetPassword(password);
        }

        // Метод для установки пароля
        public void SetPassword(string password)
        {
            // Генерация соли
            Salt = GenerateSalt();
            // Генерация хэша пароля
            PasswordHash = HashPassword(password, Salt);
        }

        // Метод для проверки пароля
        public bool VerifyPassword(string password)
        {
            // Проверка хэша введенного пароля с хэшем, хранящимся в User
            var hash = HashPassword(password, Salt);
            return hash == PasswordHash;
        }

        // Генерация соли
        private string GenerateSalt()
        {
            byte[] salt = new byte[16]; // 16 байт соли
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        // Хэширование пароля с использованием соли
        public static string HashPassword(string password, string salt)
        {
            // Объединение пароля и соли
            var saltBytes = Convert.FromBase64String(salt);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var saltedPassword = new byte[saltBytes.Length + passwordBytes.Length];

            Buffer.BlockCopy(saltBytes, 0, saltedPassword, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, saltedPassword, saltBytes.Length, passwordBytes.Length);

            // Хэширование с использованием SHA256
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(saltedPassword);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
