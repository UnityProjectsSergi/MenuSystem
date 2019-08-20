// GENERATED AUTOMATICALLY FROM 'Assets/InputsControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputsControls : IInputActionCollection
{
    private InputActionAsset asset;
    public InputsControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputsControls"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""a6e48195-3912-4370-8d90-fc06c605bebb"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""c6cdb700-2c19-4e52-81eb-1d61e7b60871"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""014cbd14-0638-401d-b751-954f0adfa9fa"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.GetActionMap("Menu");
        m_Menu_Back = m_Menu.GetAction("Back");
    }

    ~InputsControls()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Back;
    public struct MenuActions
    {
        private InputsControls m_Wrapper;
        public MenuActions(InputsControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_Menu_Back;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                Back.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                Back.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
                Back.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                Back.started += instance.OnBack;
                Back.performed += instance.OnBack;
                Back.canceled += instance.OnBack;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IMenuActions
    {
        void OnBack(InputAction.CallbackContext context);
    }
}
