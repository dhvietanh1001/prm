using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// Thêm namespace cho mô hình và repository

using api.Model;
using api.Repository;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly UserRepository _repository;

        public HomeController()
        {
            // Sử dụng repository để giả lập cơ sở dữ liệu
            _repository = new UserRepository();
        }

        // GET: api/Home
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _repository.GetAll();
            return Ok(users);
        }

        // GET: api/Home/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/Home
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _repository.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest();
            }
            var existingUser = _repository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _repository.Update(user);
            return NoContent();
        }

        // DELETE: api/Home/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existingUser = _repository.GetById(id);
            if (existingUser == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            return NoContent();
        }
    }
}
