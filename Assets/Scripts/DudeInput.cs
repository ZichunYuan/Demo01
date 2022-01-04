// GENERATED AUTOMATICALLY FROM 'Assets/Animation/DudeInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DudeInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DudeInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DudeInput"",
    ""maps"": [
        {
            ""name"": ""Dude"",
            ""id"": ""8bf75d9c-2f3a-4205-bc6c-76dba1aeb9db"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""686b52f9-d067-4ea2-935e-256c976fb757"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""1e5a4bb9-457e-4a4c-a6e3-68e028369eb2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""71b77154-083f-4d33-96c5-2231308f08d7"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6febab88-aa82-4589-a617-800e67e714c9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7a71515b-c4ab-499b-87db-d352edc79f1d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1b47d52c-de61-4c61-9c03-e538b18e5821"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Dude
        m_Dude = asset.FindActionMap("Dude", throwIfNotFound: true);
        m_Dude_Movement = m_Dude.FindAction("Movement", throwIfNotFound: true);
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

    // Dude
    private readonly InputActionMap m_Dude;
    private IDudeActions m_DudeActionsCallbackInterface;
    private readonly InputAction m_Dude_Movement;
    public struct DudeActions
    {
        private @DudeInput m_Wrapper;
        public DudeActions(@DudeInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Dude_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Dude; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DudeActions set) { return set.Get(); }
        public void SetCallbacks(IDudeActions instance)
        {
            if (m_Wrapper.m_DudeActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_DudeActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_DudeActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_DudeActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_DudeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
            }
        }
    }
    public DudeActions @Dude => new DudeActions(this);
    public interface IDudeActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
