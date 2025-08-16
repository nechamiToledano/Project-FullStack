using MyProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public bool VerifyPassword(string password, IPasswordHasher passwordHasher)
        {
            return passwordHasher.VerifyHash(password, PasswordHash);
        }
    }
}
