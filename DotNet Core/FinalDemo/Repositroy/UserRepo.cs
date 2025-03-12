using FinalDemo.Models;

namespace FinalDemo.Repository
{
    public class UserRepo : IUserRepo
    {
        public readonly List<User> users;

        /// <summary>
        /// Initializes the UserRepo with sample data.
        /// </summary>
        public UserRepo()
        {
            users = new List<User>()
            {
                new User
                {
                    Name = "Navneet",
                    Id = 1,
                    Password = "password"
                },
                new User
                {
                    Name = "Meet Joshi",
                    Id = 2,
                    Password = "password2"
                },
                new User
                {
                    Name = "RB",
                    Id = 3,
                    Password = "password23"
                }
            };
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of all users.</returns>
        public List<User> GetAllUsers()
        {
            return users;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        public User GetUserById(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        /// <summary>
        /// Adds a new user to the repository.
        /// </summary>
        /// <param name="newUser">The new user to add.</param>
        public void AddUser(User newUser)
        {
            users.Add(newUser);
        }

        /// <summary>
        /// Updates the details of an existing user.
        /// </summary>
        /// <param name="updatedUser">The user with updated details.</param>
        public void UpdateUser(User updatedUser)
        {
            var existingUser = GetUserById(updatedUser.Id);
            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Password = updatedUser.Password;
            }
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        public void DeleteUser(int id)
        {
            var userToDelete = GetUserById(id);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
            }
        }
    }
}
