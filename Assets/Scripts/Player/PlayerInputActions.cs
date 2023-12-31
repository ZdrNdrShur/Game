//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Scripts/Player/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Default"",
            ""id"": ""1e621b44-6928-419c-8dd3-e7641401635b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2a9a4d44-62e7-4ba9-8c93-a1e1bc7644a2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""14ee9655-4aaa-442f-bb9c-7cf7d182473c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""497d08ed-f461-4adf-8748-00d1dd8dd5ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Cycle Inventory"",
                    ""type"": ""Value"",
                    ""id"": ""14bcc014-47df-4c20-a24b-c6607055bbac"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""5a4215ad-004d-42d3-bc81-4a3f06a0f9f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Toggle Auto"",
                    ""type"": ""Button"",
                    ""id"": ""944df7c0-3cfe-44ae-80b9-77c917a381c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Drop Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""f2b5a7b8-e037-4131-ad46-27427cfba8dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""3abcc135-a64f-4987-8fe2-6b302e847f51"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""de3ea9ce-c91d-43ff-8f6a-a4a7399080e1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""88046faa-a49e-4ccc-85a6-be84217d0d17"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1a53cc27-27fb-46f6-9770-329c9979a702"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""63e8651c-c4ef-44e2-b387-f20a1e807c2f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a633ba5-234a-4c88-9cd9-83229a1bdc1d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14d449fa-1ccc-4d65-81d6-73beefa6cbf7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f8f98f0-c476-4f72-a3ea-03188cf75ab9"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cycle Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c0aabf9-a09c-4350-a05f-b2c6821dc9b5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65115dbb-f274-41df-82f7-304de3f6c875"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle Auto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d2aabd0-5267-4a20-9c1c-ac9ccf413d25"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Default
        m_PlayerDefault = asset.FindActionMap("Player Default", throwIfNotFound: true);
        m_PlayerDefault_Move = m_PlayerDefault.FindAction("Move", throwIfNotFound: true);
        m_PlayerDefault_Jump = m_PlayerDefault.FindAction("Jump", throwIfNotFound: true);
        m_PlayerDefault_Rotate = m_PlayerDefault.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerDefault_CycleInventory = m_PlayerDefault.FindAction("Cycle Inventory", throwIfNotFound: true);
        m_PlayerDefault_Shoot = m_PlayerDefault.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerDefault_ToggleAuto = m_PlayerDefault.FindAction("Toggle Auto", throwIfNotFound: true);
        m_PlayerDefault_DropWeapon = m_PlayerDefault.FindAction("Drop Weapon", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player Default
    private readonly InputActionMap m_PlayerDefault;
    private List<IPlayerDefaultActions> m_PlayerDefaultActionsCallbackInterfaces = new List<IPlayerDefaultActions>();
    private readonly InputAction m_PlayerDefault_Move;
    private readonly InputAction m_PlayerDefault_Jump;
    private readonly InputAction m_PlayerDefault_Rotate;
    private readonly InputAction m_PlayerDefault_CycleInventory;
    private readonly InputAction m_PlayerDefault_Shoot;
    private readonly InputAction m_PlayerDefault_ToggleAuto;
    private readonly InputAction m_PlayerDefault_DropWeapon;
    public struct PlayerDefaultActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerDefaultActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerDefault_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerDefault_Jump;
        public InputAction @Rotate => m_Wrapper.m_PlayerDefault_Rotate;
        public InputAction @CycleInventory => m_Wrapper.m_PlayerDefault_CycleInventory;
        public InputAction @Shoot => m_Wrapper.m_PlayerDefault_Shoot;
        public InputAction @ToggleAuto => m_Wrapper.m_PlayerDefault_ToggleAuto;
        public InputAction @DropWeapon => m_Wrapper.m_PlayerDefault_DropWeapon;
        public InputActionMap Get() { return m_Wrapper.m_PlayerDefault; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerDefaultActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerDefaultActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerDefaultActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerDefaultActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Rotate.started += instance.OnRotate;
            @Rotate.performed += instance.OnRotate;
            @Rotate.canceled += instance.OnRotate;
            @CycleInventory.started += instance.OnCycleInventory;
            @CycleInventory.performed += instance.OnCycleInventory;
            @CycleInventory.canceled += instance.OnCycleInventory;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @ToggleAuto.started += instance.OnToggleAuto;
            @ToggleAuto.performed += instance.OnToggleAuto;
            @ToggleAuto.canceled += instance.OnToggleAuto;
            @DropWeapon.started += instance.OnDropWeapon;
            @DropWeapon.performed += instance.OnDropWeapon;
            @DropWeapon.canceled += instance.OnDropWeapon;
        }

        private void UnregisterCallbacks(IPlayerDefaultActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Rotate.started -= instance.OnRotate;
            @Rotate.performed -= instance.OnRotate;
            @Rotate.canceled -= instance.OnRotate;
            @CycleInventory.started -= instance.OnCycleInventory;
            @CycleInventory.performed -= instance.OnCycleInventory;
            @CycleInventory.canceled -= instance.OnCycleInventory;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @ToggleAuto.started -= instance.OnToggleAuto;
            @ToggleAuto.performed -= instance.OnToggleAuto;
            @ToggleAuto.canceled -= instance.OnToggleAuto;
            @DropWeapon.started -= instance.OnDropWeapon;
            @DropWeapon.performed -= instance.OnDropWeapon;
            @DropWeapon.canceled -= instance.OnDropWeapon;
        }

        public void RemoveCallbacks(IPlayerDefaultActions instance)
        {
            if (m_Wrapper.m_PlayerDefaultActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerDefaultActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerDefaultActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerDefaultActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerDefaultActions @PlayerDefault => new PlayerDefaultActions(this);
    public interface IPlayerDefaultActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnCycleInventory(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnToggleAuto(InputAction.CallbackContext context);
        void OnDropWeapon(InputAction.CallbackContext context);
    }
}
