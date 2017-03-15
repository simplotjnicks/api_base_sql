using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SampleApplication.Interfaces;
using SampleApplication.Models;
using SampleApplication.QueryEngine;

namespace SampleApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        private const string INVALID_CREDENTIALS = "Invalid Username/Password";
        private readonly IDatabaseShim _databaseShim;

        public AuthenticationController(IDatabaseShim databaseShim = null)
        {
            _databaseShim = databaseShim ?? new DatabaseShim() ;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Scott", "Josh" };
        }

        [HttpPost("{username}")]
        public string Post([FromBody]User user)
        {
            return Login(user);
        }

        public string Login(User user)
        {
            return _databaseShim.Login(user) ? $"Welcome {user.UserName}" : INVALID_CREDENTIALS;;
        }
    }
}