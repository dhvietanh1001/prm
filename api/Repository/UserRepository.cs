using api.Model;

namespace api.Repository
{
    public class UserRepository
    {
        private readonly List<User> users = new List<User>
        {
            new User { Id = 1, Username = "nguyenvana", Name = "Nguyen Van A", Email = "nguyenvana@example.com", Password = "password123", Balance = 1000000 },
            new User { Id = 2, Username = "tranthib", Name = "Tran Thi B", Email = "tranthib@example.com", Password = "password456", Balance = 1500000 },
            new User { Id = 3, Username = "lethingoc", Name = "Le Thi Ngoc", Email = "lethingoc@example.com", Password = "password789", Balance = 2000000 }
        };

        public List<User> GetAll() => users;

        public User GetById(int id) => users.FirstOrDefault(u => u.Id == id);

        public void Add(User user)
        {
            user.Id = users.Max(u => u.Id) + 1;
            users.Add(user);
        }

        public void Update(User user)
        {
            var existingUser = GetById(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.Balance = user.Balance;
            }
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
