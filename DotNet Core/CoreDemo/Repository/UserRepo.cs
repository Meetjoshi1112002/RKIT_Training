namespace CoreDemo.Repository
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
    public class UserRepo : IUserRepo
    {
        private readonly List<User> users;

        public UserRepo()
        {
            users = new List<User>();
        }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public List<User> GetAll()
        {
            return users;
        }
    }
}
