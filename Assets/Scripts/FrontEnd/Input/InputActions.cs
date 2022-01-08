// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/FrontEnd/Input/InputActions.inputactions'

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
    public struct PCMapActions
    {
        private @InputActions m_Wrapper;
        public PCMapActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftClick => m_Wrapper.m_PCMap_LeftClick;
        public InputAction @MousePosition => m_Wrapper.m_PCMap_MousePosition;
        public InputAction @RightClick => m_Wrapper.m_PCMap_RightClick;
        public InputAction @Escape => m_Wrapper.m_PCMap_Escape;
        public InputAction @Space => m_Wrapper.m_PCMap_Space;
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
    }
}
