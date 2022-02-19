// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Action"",
            ""id"": ""6f114914-f631-42cd-a1b6-80dac590f02f"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""d6476129-71a6-477b-bd4d-a8108d81ec21"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AbilityAttack"",
                    ""type"": ""Button"",
                    ""id"": ""64715c6c-c480-4522-b9c0-43fa6685d50e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4cc1aa71-f361-47db-92a7-d74a89a79762"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""590e3ef0-8d4a-49af-ac2c-03a5cd192f3c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AbilityAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Action
        m_Action = asset.FindActionMap("Action", throwIfNotFound: true);
        m_Action_Attack = m_Action.FindAction("Attack", throwIfNotFound: true);
        m_Action_AbilityAttack = m_Action.FindAction("AbilityAttack", throwIfNotFound: true);
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

    // Action
    private readonly InputActionMap m_Action;
    private IActionActions m_ActionActionsCallbackInterface;
    private readonly InputAction m_Action_Attack;
    private readonly InputAction m_Action_AbilityAttack;
    public struct ActionActions
    {
        private @PlayerActions m_Wrapper;
        public ActionActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Action_Attack;
        public InputAction @AbilityAttack => m_Wrapper.m_Action_AbilityAttack;
        public InputActionMap Get() { return m_Wrapper.m_Action; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionActions set) { return set.Get(); }
        public void SetCallbacks(IActionActions instance)
        {
            if (m_Wrapper.m_ActionActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnAttack;
                @AbilityAttack.started -= m_Wrapper.m_ActionActionsCallbackInterface.OnAbilityAttack;
                @AbilityAttack.performed -= m_Wrapper.m_ActionActionsCallbackInterface.OnAbilityAttack;
                @AbilityAttack.canceled -= m_Wrapper.m_ActionActionsCallbackInterface.OnAbilityAttack;
            }
            m_Wrapper.m_ActionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @AbilityAttack.started += instance.OnAbilityAttack;
                @AbilityAttack.performed += instance.OnAbilityAttack;
                @AbilityAttack.canceled += instance.OnAbilityAttack;
            }
        }
    }
    public ActionActions @Action => new ActionActions(this);
    public interface IActionActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnAbilityAttack(InputAction.CallbackContext context);
    }
}
