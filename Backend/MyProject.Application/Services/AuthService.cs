using MyProject.Domain.Entities;
using MyProject.Domain.Repositories;
using MyProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application.Services;
public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly JwtService _jwtService;

    public AuthService(IUserRepository userRepository, IPasswordHasher passwordHasher, JwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<string> RegisterAsync(string email, string password)
    {
        var existing = await _userRepository.GetByEmailAsync(email);
        if (existing != null) throw new Exception("User already exists");

        var user = new User(email, _passwordHasher.Hash(password));
        await _userRepository.AddAsync(user);

        return _jwtService.GenerateToken(user.Id.ToString(), user.Email);
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null || !user.VerifyPassword(password, _passwordHasher))
            throw new Exception("Invalid credentials");

        return _jwtService.GenerateToken(user.Id.ToString(), user.Email);
    }
}


