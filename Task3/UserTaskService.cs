using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public string AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                return "Invalid userId";

            var user = _userDao.GetUser(userId);
            if (user == null)
                return "User not found";

            var tasks = user.Tasks;
            foreach (var t in tasks)
            {
                if (string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase))
                    return "The task already exists";
            }

            tasks.Add(task);

            return null;
        }
    }
}