using Microsoft.AspNetCore.Mvc;

namespace MyProject.Api.DTOs;
public class RegisterRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginRequestDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}


