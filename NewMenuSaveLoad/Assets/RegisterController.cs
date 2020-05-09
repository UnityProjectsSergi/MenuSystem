using System.Collections;
using System.Collections.Generic;
using SaveSystem1.DataClasses;
using TMPro;
using UnityEngine;

public class RegisterController : MonoBehaviour
{
    public UiSystem system;
    public TMP_Text textMessage;
    public UiScreen login;
    public TMP_InputField FirstName;
    public TMP_InputField LastName;
    public TMP_InputField Username;
    public TMP_InputField Password;
    public TMP_InputField Email;
    public TMP_InputField ConfirmPassword;

    public LoginController loginController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Register()
    {
        if (validateForm())
        {
            UserData user = new UserData(FirstName.text, LastName.text, Username.text, Password.text, Email.text);
            SaveData.usersList.listUsers.Add(user);
            GameController.Save();
            if (GameController.Instance.globalSettignsMenu.AutoLoginOnRegister)
            {
                loginController.Login(user);    
            }
                
        }
    }

    
    public void ShowMessage()
    {
        
    }

    public bool validateForm()
    {
        return true;
    }
}
