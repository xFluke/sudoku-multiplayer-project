// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""eb010cc1-e80c-4908-8c4e-5c8530b6c912"",
            ""actions"": [
                {
                    ""name"": ""EnableNotes"",
                    ""type"": ""Value"",
                    ""id"": ""c9184b03-fb8f-47e5-a447-d123c0ad770e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""InputNumber"",
                    ""type"": ""Value"",
                    ""id"": ""0fbdc2d9-7d44-47d5-9def-370d0cc500f7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b983b569-e07b-4b40-b909-e04a40977a5c"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnableNotes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aec1c0ff-4efc-405c-a872-a430a23d5582"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c06cf335-aec9-4c34-ba8e-ce6c5427864c"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60499551-71cb-4a6f-b88b-56abbf498747"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39c8fd47-d058-4b57-a125-60b244546fb3"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a2473b55-02f8-45e1-baca-81a6dfb6109f"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a84d950-215b-4d49-a19b-16732c82ac54"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c952ca3-3bee-4f77-9867-e3410b7455cb"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""157b787b-ece0-4edd-902f-a011c9e59458"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c12a625-46e8-4f27-89cd-752303b957ef"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InputNumber"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_EnableNotes = m_Gameplay.FindAction("EnableNotes", throwIfNotFound: true);
        m_Gameplay_InputNumber = m_Gameplay.FindAction("InputNumber", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_EnableNotes;
    private readonly InputAction m_Gameplay_InputNumber;
    public struct GameplayActions
    {
        private @PlayerInputAction m_Wrapper;
        public GameplayActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @EnableNotes => m_Wrapper.m_Gameplay_EnableNotes;
        public InputAction @InputNumber => m_Wrapper.m_Gameplay_InputNumber;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @EnableNotes.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnableNotes;
                @EnableNotes.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnableNotes;
                @EnableNotes.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnableNotes;
                @InputNumber.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInputNumber;
                @InputNumber.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInputNumber;
                @InputNumber.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInputNumber;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @EnableNotes.started += instance.OnEnableNotes;
                @EnableNotes.performed += instance.OnEnableNotes;
                @EnableNotes.canceled += instance.OnEnableNotes;
                @InputNumber.started += instance.OnInputNumber;
                @InputNumber.performed += instance.OnInputNumber;
                @InputNumber.canceled += instance.OnInputNumber;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnEnableNotes(InputAction.CallbackContext context);
        void OnInputNumber(InputAction.CallbackContext context);
    }
}
