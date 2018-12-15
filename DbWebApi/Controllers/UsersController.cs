using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomCursesLibrary.Helpers;
using CustomCursesLibrary.Models;
using DbWebApi.Helpers;
using DbWebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DbWebApi.Controllers
{
    [Route("db/Users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UsersContext _usersContext;

        public UsersController(UsersContext context)
        {
            _usersContext = context;

            PasswordHashHelpers.CreatePasswordHash("123", out byte[] hash, out var salt);
            if (_usersContext.Users.Any()) return;
            _usersContext.Users.Add(new User
            {
                Username = "N3vix" ,
                PasswordHash = hash,
                PasswordSalt = salt,
                FirstName = "Oleksandr",
                SecondName = "Vasylyk",
                Role = Roles.Admin,
                SubscribeCourses = "Introduction and learning HTML,CSS#Learn Python 3#Introduction and learning JavaScript"
            });
            _usersContext.SaveChanges();
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(_usersContext.Users.ToList());
        }

        [HttpGet("Id={id}", Name = "GetUser")]
        public ActionResult<User> GetById(long id)
        {
            var item = _usersContext.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("Name={name}", Name = "GetUserByName")]
        public ActionResult<User> GetByName(string name)
        {
            var item = _usersContext.Users.FirstOrDefault(x => string.Equals(
                x.Username
                , name,
                StringComparison.CurrentCultureIgnoreCase));
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new AppException("Password is required");

            if (_usersContext.Users.Any(x => x.Username == userDto.Username))
                throw new AppException($"Username \\{userDto.Username}\\ is already taken");

            PasswordHashHelpers.CreatePasswordHash(userDto.Password, out var passwordHash, out var passwordSalt);

            _usersContext.Users.Add(new User()
            {
                Username = userDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
            _usersContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            var user = _usersContext.Users.Find(userDto.Id);

            if (user == null)
                throw new AppException("User not found");

            if (userDto.Username != user.Username && _usersContext.Users.Any(x => x.Username == userDto.Username))
                throw new AppException($"Username {userDto.Username} is already taken");

            if (string.IsNullOrWhiteSpace(userDto.Password))
                throw new AppException($"Please enter the password");

            user.Username = userDto.Username;

            PasswordHashHelpers.CreatePasswordHash(userDto.Password, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _usersContext.Users.Update(user);
            _usersContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("Id={id}")]
        public IActionResult Delete(long id)
        {
            var user = _usersContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _usersContext.Users.Remove(user);
            _usersContext.SaveChanges();
            return Ok();
        }
    }
}