using System.Collections;
using System.Collections.Generic;
using SaveSystem1.DataClasses;
using TMPro;
using UnityEngine;

public class RegisterController : MonoBehaviour
{
    [Header("UiScreens")]
    public UiSystem system;
    public UiScreen LoginScreen;
    [Header("InputFields")] public TMP_Text textMessage;
    public TMP_InputField FirstName;
    public TMP_InputField LastName;
    public TMP_InputField Username;
    public TMP_InputField Password;
    public TMP_InputField Email;
    public TMP_InputField ConfirmPassword;
    
    [Header("Controllers")]
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
            SaveController.Instance.SaveNewUser(user);
            if (SaveController.Instance._response.StatusCode != 0)
            {
                textMessage.text = SaveController.Instance._response.Error;
            }
            if (GameController.Instance.globalSettignsMenu.AutoLoginOnRegister)
            {
                loginController.Login(user);    
            }
                
        }
    }

    public void goToLogin()
    {
        system.CallSwitchScreen(LoginScreen);
    }
    public void ShowMessage()
    {
        
    }

    public bool validateForm()
    {
        return true;
    }
}
