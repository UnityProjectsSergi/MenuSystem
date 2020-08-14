using System.Collections.Generic;

namespace SaveSystem1.DataClasses
{
    [System.Serializable]
    public class UsersContinerData
    {
        public List<UserData> listUsers;
        public UserData prevLoadedUser;
    }
}