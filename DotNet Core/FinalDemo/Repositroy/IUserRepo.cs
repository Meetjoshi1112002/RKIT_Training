using FinalDemo.Models;

namespace FinalDemo.Repository
{
    public interface IUserRepo
    {
        void AddUser(User newUser);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User GetUserById(int id);
        void UpdateUser(User updatedUser);
    }
}