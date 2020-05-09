using System.Collections;
using System.Collections.Generic;
using SaveSystem1.DataClasses;
using TMPro;
using UnityEngine;

public class LoginController : MonoBehaviour
{
    public TMP_InputField userName;

    public TMP_InputField password;

    public UiSystem system;

    public UiScreen Register;

    public UiScreen MainMenuScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.hasLoadedGameData)
        {
            if (SaveData.usersList.prevLoadedUser!=null)
            {
                Login(SaveData.usersList.prevLoadedUser);
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        if (ValidateForm())
        {
            CheckUserData userCheck = new CheckUserData(password.text, userName.text);
            
        }
    }

    public bool ValidateForm()
    {
        return true;
    }
    public void Login(UserData user)
    {
        system.CallSwitchScreen(MainMenuScreen);
    }

    public void goToRegister()
    {
        system.CallSwitchScreen(Register);
    }
}
