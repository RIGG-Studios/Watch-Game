// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Bilal/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""PCMap"",
            ""id"": ""e5dd09b7-959c-457c-9b67-615525dc3a98"",
            ""actions"": [
                {
                    ""name"": ""LeftClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7d1b9916-f19e-4a48-9adc-ba6c10f10fd5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""47aa336c-9e4b-4f5d-9654-d1db91d41f12"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da9c2d8f-4d37-48c1-8a14-6ea5721787ba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Escape"",
                    ""type"": ""Button"",
                    ""id"": ""d31746c2-ce61-4969-91d4-5067e12076df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""5b72d62b-fca3-4ba0-90ee-7bbb039fb5a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""1"",
                    ""type"": ""Button"",
                    ""id"": ""bf2c7c5d-3877-4af1-94c5-43676b619336"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""2"",
                    ""type"": ""Button"",
                    ""id"": ""5adde528-3b77-4be9-b2de-2edbd4b6a70a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""3"",
                    ""type"": ""Button"",
                    ""id"": ""e0471d56-0b36-43b7-ba9d-3de61e6eddd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""4"",
                    ""type"": ""Button"",
                    ""id"": ""797e4eea-ee82-4584-be7f-e04ea0b068eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""5"",
                    ""type"": ""Button"",
                    ""id"": ""89cc15cd-cce0-4922-a5cc-d89454afd004"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""6"",
                    ""type"": ""Button"",
                    ""id"": ""3b3ad1c7-ac7c-4c8c-bf0e-1f8f340d188c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e8bd5c4f-55ce-421d-97ef-f621116b120b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""LeftClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be8d1144-689e-4afd-a1e6-52af6a1ef5e8"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4aa37bb2-34e0-48bb-a993-f5abc1e9ab7a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a6ce46e-da36-4c69-afb9-ec19c9120e7d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Escape"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""741f52ce-577b-42f7-b76f-db4ae0915106"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb1f6c68-4c48-453f-aa70-74f728b4854c"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""892f3294-2e9e-4e1f-93ac-e0d6a640393b"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""905bd8d7-c830-4302-aa01-95c15a2076e9"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1d5fe48-6c99-4924-a84f-1e2ce8977557"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""158d0cd2-7928-4a5d-811e-cae550f2e0b8"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce0c6edc-8fd1-4529-a8ee-802a4622bd49"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
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
        }
    ]
}");
        // PCMap
        m_PCMap = asset.FindActionMap("PCMap", throwIfNotFound: true);
        m_PCMap_LeftClick = m_PCMap.FindAction("LeftClick", throwIfNotFound: true);
        m_PCMap_MousePosition = m_PCMap.FindAction("MousePosition", throwIfNotFound: true);
        m_PCMap_RightClick = m_PCMap.FindAction("RightClick", throwIfNotFound: true);
        m_PCMap_Escape = m_PCMap.FindAction("Escape", throwIfNotFound: true);
        m_PCMap_Space = m_PCMap.FindAction("Space", throwIfNotFound: true);
        m_PCMap__1 = m_PCMap.FindAction("1", throwIfNotFound: true);
        m_PCMap__2 = m_PCMap.FindAction("2", throwIfNotFound: true);
        m_PCMap__3 = m_PCMap.FindAction("3", throwIfNotFound: true);
        m_PCMap__4 = m_PCMap.FindAction("4", throwIfNotFound: true);
        m_PCMap__5 = m_PCMap.FindAction("5", throwIfNotFound: true);
        m_PCMap__6 = m_PCMap.FindAction("6", throwIfNotFound: true);
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

    // PCMap
    private readonly InputActionMap m_PCMap;
    private IPCMapActions m_PCMapActionsCallbackInterface;
    private readonly InputAction m_PCMap_LeftClick;
    private readonly InputAction m_PCMap_MousePosition;
    private readonly InputAction m_PCMap_RightClick;
    private readonly InputAction m_PCMap_Escape;
    private readonly InputAction m_PCMap_Space;
    private readonly InputAction m_PCMap__1;
    private readonly InputAction m_PCMap__2;
    private readonly InputAction m_PCMap__3;
    private readonly InputAction m_PCMap__4;
    private readonly InputAction m_PCMap__5;
    private readonly InputAction m_PCMap__6;
    public struct PCMapActions
    {
        private @InputActions m_Wrapper;
        public PCMapActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_PCMap_LeftClick;
        public InputAction @MousePosition => m_Wrapper.m_PCMap_MousePosition;
        public InputAction @RightClick => m_Wrapper.m_PCMap_RightClick;
        public InputAction @Escape => m_Wrapper.m_PCMap_Escape;
        public InputAction @Space => m_Wrapper.m_PCMap_Space;
        public InputAction @_1 => m_Wrapper.m_PCMap__1;
        public InputAction @_2 => m_Wrapper.m_PCMap__2;
        public InputAction @_3 => m_Wrapper.m_PCMap__3;
        public InputAction @_4 => m_Wrapper.m_PCMap__4;
        public InputAction @_5 => m_Wrapper.m_PCMap__5;
        public InputAction @_6 => m_Wrapper.m_PCMap__6;
        public InputActionMap Get() { return m_Wrapper.m_PCMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PCMapActions set) { return set.Get(); }
        public void SetCallbacks(IPCMapActions instance)
        {
            if (m_Wrapper.m_PCMapActionsCallbackInterface != null)
            {
                @LeftClick.started -= m_Wrapper.m_PCMapActionsCallbackInterface.OnLeftClick;
                @LeftClick.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.OnLeftClick;
                @LeftClick.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.OnLeftClick;
                @MousePosition.started -= m_Wrapper.m_PCMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.OnMousePosition;
                @MousePosition.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.OnMousePosition;
                @RightClick.started -= m_Wrapper.m_PCMapActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.OnRightClick;
                @Escape.started -= m_Wrapper.m_PCMapActionsCallbackInterface.OnEscape;
                @Escape.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.OnEscape;
                @Escape.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.OnEscape;
                @Space.started -= m_Wrapper.m_PCMapActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.OnSpace;
                @_1.started -= m_Wrapper.m_PCMapActionsCallbackInterface.On_1;
                @_1.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.On_1;
                @_1.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.On_1;
                @_2.started -= m_Wrapper.m_PCMapActionsCallbackInterface.On_2;
                @_2.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.On_2;
                @_2.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.On_2;
                @_3.started -= m_Wrapper.m_PCMapActionsCallbackInterface.On_3;
                @_3.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.On_3;
                @_3.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.On_3;
                @_4.started -= m_Wrapper.m_PCMapActionsCallbackInterface.On_4;
                @_4.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.On_4;
                @_4.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.On_4;
                @_5.started -= m_Wrapper.m_PCMapActionsCallbackInterface.On_5;
                @_5.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.On_5;
                @_5.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.On_5;
                @_6.started -= m_Wrapper.m_PCMapActionsCallbackInterface.On_6;
                @_6.performed -= m_Wrapper.m_PCMapActionsCallbackInterface.On_6;
                @_6.canceled -= m_Wrapper.m_PCMapActionsCallbackInterface.On_6;
            }
            m_Wrapper.m_PCMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftClick.started += instance.OnLeftClick;
                @LeftClick.performed += instance.OnLeftClick;
                @LeftClick.canceled += instance.OnLeftClick;
                @MousePosition.started += instance.OnMousePosition;
                @MousePosition.performed += instance.OnMousePosition;
                @MousePosition.canceled += instance.OnMousePosition;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @Escape.started += instance.OnEscape;
                @Escape.performed += instance.OnEscape;
                @Escape.canceled += instance.OnEscape;
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @_1.started += instance.On_1;
                @_1.performed += instance.On_1;
                @_1.canceled += instance.On_1;
                @_2.started += instance.On_2;
                @_2.performed += instance.On_2;
                @_2.canceled += instance.On_2;
                @_3.started += instance.On_3;
                @_3.performed += instance.On_3;
                @_3.canceled += instance.On_3;
                @_4.started += instance.On_4;
                @_4.performed += instance.On_4;
                @_4.canceled += instance.On_4;
                @_5.started += instance.On_5;
                @_5.performed += instance.On_5;
                @_5.canceled += instance.On_5;
                @_6.started += instance.On_6;
                @_6.performed += instance.On_6;
                @_6.canceled += instance.On_6;
            }
        }
    }
    public PCMapActions @PCMap => new PCMapActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IPCMapActions
    {
        void OnLeftClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnEscape(InputAction.CallbackContext context);
        void OnSpace(InputAction.CallbackContext context);
        void On_1(InputAction.CallbackContext context);
        void On_2(InputAction.CallbackContext context);
        void On_3(InputAction.CallbackContext context);
        void On_4(InputAction.CallbackContext context);
        void On_5(InputAction.CallbackContext context);
        void On_6(InputAction.CallbackContext context);
    }
}
