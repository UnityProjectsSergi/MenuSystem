
    using SaveSystem1.DataClasses;

    public class CheckUserData
    {
        public string identifier;
        public string password;

        public CheckUserData(string _password, string _username)
        {
            password = _password;
            identifier = _username;
        }

        public UserData CheckIfUserIsRegister()
        {
            //Todo LOad List of register users search for id and passwod
            return new UserData();
        }
    }
