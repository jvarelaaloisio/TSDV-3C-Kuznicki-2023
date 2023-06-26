//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Inputs/PlayerInputs.inputactions
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

namespace Inputs
{
    public partial class @PlayerInputs: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputs()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""World"",
            ""id"": ""a8bebb75-8115-4614-b4da-fd4b09f197c0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""bd3f1893-5811-44ab-b6b4-c30cd759dceb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6b083803-2410-4117-aa85-52d31b927e57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""eaccc77c-046a-4f7e-93e3-d318e95f1425"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""428c6700-bbd5-4214-b560-95a2badadeac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db893c25-414c-4505-990d-f97980a9653c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""406af9f7-908b-4272-8216-458808d1750d"",
                    ""path"": ""<DualShockGamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""dbe56936-cc91-4d07-9942-d5e3749da6db"",
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
                    ""id"": ""5569aee4-ddbf-4841-8af1-69eac1b78fcc"",
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
                    ""id"": ""3f4f574f-fffe-4dd4-8dfd-8423ec60cc4e"",
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
                    ""id"": ""155fa40e-5c87-42b0-9eb7-39b7c7a09596"",
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
                    ""id"": ""7201135e-5856-4709-bc94-473733d658b0"",
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
                    ""id"": ""bf165a57-a399-4a5e-902e-b642fd4bee5e"",
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
                    ""id"": ""b692af65-8fdb-4a8e-8755-2a085487d625"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6af9fda2-aa7c-491a-b4d9-70d6f17fbece"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""466f0205-0595-4765-b070-37be2617e659"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d34d284b-1a0b-4170-8c4b-a23e69c283c8"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bba88c9-f318-4145-94f3-be1bc8fc9a35"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""df3c7c0d-6ff3-43b1-90ca-3c70085a46e4"",
            ""actions"": [
                {
                    ""name"": ""Selection"",
                    ""type"": ""Value"",
                    ""id"": ""c6f21b5b-159c-4779-85a0-b559b4a4f3bc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""a991b952-364e-4df1-8a81-451b29c2cfbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""83fabd0e-38d5-420c-9156-b65e4b99d6f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""bcbfdf38-57f1-4bcf-ac54-cd99b532d0be"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5e936043-c0e0-439d-b143-b1b217b7636c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""bdd3fe23-2a6d-46f7-84b4-1ad37579bfe4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WS"",
                    ""id"": ""71bb926d-c70f-4e60-9e3d-bc83a3c6dcd1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""4fe83200-3e5e-4e1c-8a55-7e9e0ec1ad59"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""af8f6c1a-094f-4bf5-bd71-fefc24863c21"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""107c6849-4ced-46c5-9b74-fc389dd2b1f6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""f4de8c6c-6431-468e-9262-90667cb4546e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b30e9592-278c-4a3d-a397-76f939a28d3e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b38fe57-c419-46b0-8917-eee1e48b63ec"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb5f8d29-44e9-4347-ba69-92dc49ac36bb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // World
            m_World = asset.FindActionMap("World", throwIfNotFound: true);
            m_World_Move = m_World.FindAction("Move", throwIfNotFound: true);
            m_World_Jump = m_World.FindAction("Jump", throwIfNotFound: true);
            m_World_Attack = m_World.FindAction("Attack", throwIfNotFound: true);
            m_World_Pause = m_World.FindAction("Pause", throwIfNotFound: true);
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Selection = m_Menu.FindAction("Selection", throwIfNotFound: true);
            m_Menu_Enter = m_Menu.FindAction("Enter", throwIfNotFound: true);
            m_Menu_Exit = m_Menu.FindAction("Exit", throwIfNotFound: true);
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

        // World
        private readonly InputActionMap m_World;
        private List<IWorldActions> m_WorldActionsCallbackInterfaces = new List<IWorldActions>();
        private readonly InputAction m_World_Move;
        private readonly InputAction m_World_Jump;
        private readonly InputAction m_World_Attack;
        private readonly InputAction m_World_Pause;
        public struct WorldActions
        {
            private @PlayerInputs m_Wrapper;
            public WorldActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_World_Move;
            public InputAction @Jump => m_Wrapper.m_World_Jump;
            public InputAction @Attack => m_Wrapper.m_World_Attack;
            public InputAction @Pause => m_Wrapper.m_World_Pause;
            public InputActionMap Get() { return m_Wrapper.m_World; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(WorldActions set) { return set.Get(); }
            public void AddCallbacks(IWorldActions instance)
            {
                if (instance == null || m_Wrapper.m_WorldActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_WorldActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }

            private void UnregisterCallbacks(IWorldActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
                @Attack.started -= instance.OnAttack;
                @Attack.performed -= instance.OnAttack;
                @Attack.canceled -= instance.OnAttack;
                @Pause.started -= instance.OnPause;
                @Pause.performed -= instance.OnPause;
                @Pause.canceled -= instance.OnPause;
            }

            public void RemoveCallbacks(IWorldActions instance)
            {
                if (m_Wrapper.m_WorldActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IWorldActions instance)
            {
                foreach (var item in m_Wrapper.m_WorldActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_WorldActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public WorldActions @World => new WorldActions(this);

        // Menu
        private readonly InputActionMap m_Menu;
        private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
        private readonly InputAction m_Menu_Selection;
        private readonly InputAction m_Menu_Enter;
        private readonly InputAction m_Menu_Exit;
        public struct MenuActions
        {
            private @PlayerInputs m_Wrapper;
            public MenuActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
            public InputAction @Selection => m_Wrapper.m_Menu_Selection;
            public InputAction @Enter => m_Wrapper.m_Menu_Enter;
            public InputAction @Exit => m_Wrapper.m_Menu_Exit;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void AddCallbacks(IMenuActions instance)
            {
                if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }

            private void UnregisterCallbacks(IMenuActions instance)
            {
                @Selection.started -= instance.OnSelection;
                @Selection.performed -= instance.OnSelection;
                @Selection.canceled -= instance.OnSelection;
                @Enter.started -= instance.OnEnter;
                @Enter.performed -= instance.OnEnter;
                @Enter.canceled -= instance.OnEnter;
                @Exit.started -= instance.OnExit;
                @Exit.performed -= instance.OnExit;
                @Exit.canceled -= instance.OnExit;
            }

            public void RemoveCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IMenuActions instance)
            {
                foreach (var item in m_Wrapper.m_MenuActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        public interface IWorldActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnAttack(InputAction.CallbackContext context);
            void OnPause(InputAction.CallbackContext context);
        }
        public interface IMenuActions
        {
            void OnSelection(InputAction.CallbackContext context);
            void OnEnter(InputAction.CallbackContext context);
            void OnExit(InputAction.CallbackContext context);
        }
    }
}
