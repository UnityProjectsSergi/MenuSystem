// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""MainMenu"",
            ""id"": ""db003df5-94e8-4c9c-9666-76d8b9503d8b"",
            ""actions"": [
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""d51a9614-8acf-4959-b5c2-00f31e3731dc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""d73bb7ae-11a3-43ad-866c-9d78f4b8137d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""e5e5c338-b427-496c-9c47-e049da6d4ee2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""62b9bd97-ce58-422f-977b-d27b78ffe162"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""c8ec0dbd-fcce-4e73-956e-b9c55aac834c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle"",
                    ""type"": ""Button"",
                    ""id"": ""5188385b-33a3-4213-8437-94df34dbe574"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""9757b3d5-8955-4deb-a9f9-c5e3f3a8b88a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""Button"",
                    ""id"": ""6d7c9301-66b7-4b0f-a57d-43aaa63f62ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a946000a-6aea-4e5e-98b6-474c4de0de58"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c061de3d-12a3-433e-bb8d-8b3c87c37828"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77460fd0-113f-44f1-9985-5b8f259230fe"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitPause"",
                    ""type"": ""Button"",
                    ""id"": ""f942558b-7b34-418e-b3d9-3bd2f507732d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8da27187-3d17-48e7-b025-82dadc15ae9d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse;Mouse"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2124ade7-58ea-4331-92df-4c819a09343c"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PS4"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c8c8356-7e72-44c1-bd1d-07ace9d4ccd2"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";KayBoard&Mopuse"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""274c7870-ab44-4cf6-8ca6-5ebd219ceffb"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PS4"",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""3f866e2c-f73a-495f-8a3b-efaf4a98cd79"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c339a8fc-e08e-47a2-a91d-ae0b22e0bbd0"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bf5d2a31-475a-454d-ae6e-65ffb92e7dce"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b99f7bd1-8e49-4185-b2ee-f1026b5cfd9e"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a79301bf-5264-42cd-990a-6d011e98ed7e"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b5eeec68-63e2-485d-afec-593160080a22"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Stick"",
                    ""id"": ""31e0d637-a0e8-47d4-a4c8-de4ba968ece7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""34303703-74de-4d0e-a024-369f85a32e1c"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f754952e-3630-4297-b24d-61863a77c721"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eeddfdf1-8712-440a-9c6b-b78df162a0e3"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2f850b4f-978d-41f0-bb74-f4636e54c4eb"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""keyboard"",
                    ""id"": ""31d6d89d-2b40-452d-9cbe-31a4f8aaa57b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3445ff52-fa76-4432-bd01-0b01da990597"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c5432fea-fb04-4988-ae6c-0eb2a913a32f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""98aa59e9-9a9b-40f7-b0f0-2e084263a948"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""047eaa2b-26bb-4b0f-9f63-ea9481fdd081"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""169481d2-308a-4ce9-855d-aaa2afc29c4f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f2853897-37d0-473c-abd9-3cf14b3e3cab"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4154b460-dcf7-4a48-981e-2750d6c2ed6f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6385cc7f-172e-4a5d-83c1-c65dbc6aec0c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""010a5735-2fde-4d18-bceb-1fcc2ac9004a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": "";KayBoard&Mopuse"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e6742bc-ab3c-4144-bce8-d9f3e7eb8003"",
                    ""path"": ""<DualShockGamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";PS4"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4a08e2b-af00-4442-94e3-925f42bf4ca3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Mouse;KayBoard&Mopuse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f88501d-e673-49d1-aa40-a88492d928c6"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse;Mouse;KayBoard&Mopuse"",
                    ""action"": ""Middle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99f5adb1-753d-4dac-a0a0-e7581f380164"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse;KayBoard&Mopuse"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff6a8980-a225-4911-94cc-201888618823"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d6602d4-74c9-428e-b0e9-660999266ddf"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""458c1992-9e48-49b3-bd74-fe48deba28dc"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c9b84f1-d6c5-4061-b2d3-203467fc8266"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bb9f4b8-6c5b-4caf-b58a-bbd6e53e1fdb"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""ExitPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GamePlay"",
            ""id"": ""04d8a07f-18d8-4594-9d2e-a223f6733308"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""583b9d13-29b7-47f9-917e-69695542e9c0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d89e84af-f1e0-4070-9e8d-faec6d8b0eaf"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KayBoard&Mopuse"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31ce05f1-f65c-4a7e-b46b-324a1775d23d"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KayBoard&Mopuse"",
            ""bindingGroup"": ""KayBoard&Mopuse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PS4"",
            ""bindingGroup"": ""PS4"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Back = m_MainMenu.FindAction("Back", throwIfNotFound: true);
        m_MainMenu_Cancel = m_MainMenu.FindAction("Cancel", throwIfNotFound: true);
        m_MainMenu_Confirm = m_MainMenu.FindAction("Confirm", throwIfNotFound: true);
        m_MainMenu_Navigate = m_MainMenu.FindAction("Navigate", throwIfNotFound: true);
        m_MainMenu_Click = m_MainMenu.FindAction("Click", throwIfNotFound: true);
        m_MainMenu_Middle = m_MainMenu.FindAction("Middle", throwIfNotFound: true);
        m_MainMenu_Right = m_MainMenu.FindAction("Right", throwIfNotFound: true);
        m_MainMenu_Point = m_MainMenu.FindAction("Point", throwIfNotFound: true);
        m_MainMenu_ScrollWheel = m_MainMenu.FindAction("ScrollWheel", throwIfNotFound: true);
        m_MainMenu_TrackedDeviceOrientation = m_MainMenu.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_MainMenu_TrackedDevicePosition = m_MainMenu.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_MainMenu_ExitPause = m_MainMenu.FindAction("ExitPause", throwIfNotFound: true);
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Pause = m_GamePlay.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
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

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Back;
    private readonly InputAction m_MainMenu_Cancel;
    private readonly InputAction m_MainMenu_Confirm;
    private readonly InputAction m_MainMenu_Navigate;
    private readonly InputAction m_MainMenu_Click;
    private readonly InputAction m_MainMenu_Middle;
    private readonly InputAction m_MainMenu_Right;
    private readonly InputAction m_MainMenu_Point;
    private readonly InputAction m_MainMenu_ScrollWheel;
    private readonly InputAction m_MainMenu_TrackedDeviceOrientation;
    private readonly InputAction m_MainMenu_TrackedDevicePosition;
    private readonly InputAction m_MainMenu_ExitPause;
    public struct MainMenuActions
    {
        private @Controls m_Wrapper;
        public MainMenuActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Back => m_Wrapper.m_MainMenu_Back;
        public InputAction @Cancel => m_Wrapper.m_MainMenu_Cancel;
        public InputAction @Confirm => m_Wrapper.m_MainMenu_Confirm;
        public InputAction @Navigate => m_Wrapper.m_MainMenu_Navigate;
        public InputAction @Click => m_Wrapper.m_MainMenu_Click;
        public InputAction @Middle => m_Wrapper.m_MainMenu_Middle;
        public InputAction @Right => m_Wrapper.m_MainMenu_Right;
        public InputAction @Point => m_Wrapper.m_MainMenu_Point;
        public InputAction @ScrollWheel => m_Wrapper.m_MainMenu_ScrollWheel;
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_MainMenu_TrackedDeviceOrientation;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_MainMenu_TrackedDevicePosition;
        public InputAction @ExitPause => m_Wrapper.m_MainMenu_ExitPause;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Back.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnBack;
                @Cancel.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Confirm.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnConfirm;
                @Navigate.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnNavigate;
                @Click.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnClick;
                @Middle.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMiddle;
                @Middle.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMiddle;
                @Middle.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMiddle;
                @Right.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnRight;
                @Point.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnPoint;
                @ScrollWheel.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnScrollWheel;
                @TrackedDeviceOrientation.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDevicePosition.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnTrackedDevicePosition;
                @ExitPause.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnExitPause;
                @ExitPause.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnExitPause;
                @ExitPause.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnExitPause;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Middle.started += instance.OnMiddle;
                @Middle.performed += instance.OnMiddle;
                @Middle.canceled += instance.OnMiddle;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @ExitPause.started += instance.OnExitPause;
                @ExitPause.performed += instance.OnExitPause;
                @ExitPause.canceled += instance.OnExitPause;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Pause;
    public struct GamePlayActions
    {
        private @Controls m_Wrapper;
        public GamePlayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GamePlay_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    private int m_KayBoardMopuseSchemeIndex = -1;
    public InputControlScheme KayBoardMopuseScheme
    {
        get
        {
            if (m_KayBoardMopuseSchemeIndex == -1) m_KayBoardMopuseSchemeIndex = asset.FindControlSchemeIndex("KayBoard&Mopuse");
            return asset.controlSchemes[m_KayBoardMopuseSchemeIndex];
        }
    }
    private int m_PS4SchemeIndex = -1;
    public InputControlScheme PS4Scheme
    {
        get
        {
            if (m_PS4SchemeIndex == -1) m_PS4SchemeIndex = asset.FindControlSchemeIndex("PS4");
            return asset.controlSchemes[m_PS4SchemeIndex];
        }
    }
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IMainMenuActions
    {
        void OnBack(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnMiddle(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnExitPause(InputAction.CallbackContext context);
    }
    public interface IGamePlayActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
