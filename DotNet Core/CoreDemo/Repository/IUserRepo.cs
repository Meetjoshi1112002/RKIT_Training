namespace CoreDemo.Repository
{
    public interface IUserRepo
    {
        void AddUser(User user);
        List<User> GetAll();
    }
}