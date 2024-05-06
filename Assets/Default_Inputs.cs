//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Default_Inputs.inputactions
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

public partial class @Default_Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Default_Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Default_Inputs"",
    ""maps"": [
        {
            ""name"": ""P1"",
            ""id"": ""250adda6-8449-4258-b5d2-170d3de3a536"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""93e41774-33b8-43bb-9f40-f548ae1d3f92"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""0d4df0f9-e41a-4a5d-ac42-fdd9746f2ff2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ad4459a-c643-44eb-adc7-b28dad39ff3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""b8b4247c-3e9f-4c6a-bba1-443d2a0c59a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heal potion"",
                    ""type"": ""Button"",
                    ""id"": ""ef84bfe3-f5e1-488e-8172-a5a064eb4a2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Fire potion"",
                    ""type"": ""Button"",
                    ""id"": ""acd1e695-e7d6-4c09-8db8-4a4e975d342d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Ice potion"",
                    ""type"": ""Button"",
                    ""id"": ""6736c600-08a7-48e0-b8d8-10644303126b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d8f6fc1a-3a07-428c-8e4e-652df47ca2fd"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": ""Hold"",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D [Gamepad]"",
                    ""id"": ""7a1d903e-eddc-43de-9ce5-985f6dea1a52"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e7673dff-7b3d-4cd1-8ff8-4f0c0ad9d38c"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""150f3cb7-fa87-4a74-a1f5-a82060795a28"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1392cafe-6b4a-4140-95ba-de9943326f66"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""46029069-bb96-4ad8-95d4-854472a4d5d5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D [Keyboard]"",
                    ""id"": ""9fd6441a-e5fa-41c0-a6c6-ec634cef34bb"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bf431df6-6d8b-4b18-aa55-5755444a7cda"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8ebf23b9-d19c-4ecf-96ea-b42cdfc33655"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""37000772-4d44-4708-a7ce-4afca3a93bf2"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3ba6729f-b4de-446c-89dd-50887cfed78a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1b4a6fdc-0019-4f44-8c7d-739dfe21c39d"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""959f7440-6011-48ce-b7a4-7da112d52c3f"",
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
                    ""id"": ""81c09917-3863-4161-9758-fa399078f05d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90632255-480a-4d7a-a572-508eaf82f51c"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab0cbfcf-9f3f-493e-b26f-dee0208425d1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45d46b9a-8889-4c40-97e5-334d933c8fa2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2322c9b-fb84-4696-a801-8b7764edb0ef"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5023ddd-6cf1-46ff-bce7-f3cd69da1fb4"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40b5d841-5cdf-4f68-a972-3d3fbf9f0f6a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ce80403-8a11-4f94-90cb-f54b7f693a3a"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5cc3d60-9919-47e6-a515-52680dc4ecb3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ice potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9eea13f8-a36c-4e3e-bc25-c5f0fa65ab0c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ice potion"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""f30819d5-b545-47e6-9149-16346d71a4ec"",
            ""actions"": [
                {
                    ""name"": ""Options"",
                    ""type"": ""Button"",
                    ""id"": ""b2d608c6-1322-4fcb-82e7-5c6305b6d638"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""a31cbe2d-3ba2-45f1-a1f6-94ba2f2c6ea3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""0fb3aa29-df5e-4aee-b373-4c604781a520"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""0662eed1-917e-44fa-b8ab-31b1862a98bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2761811b-6ef7-4a5a-b89d-d047957f73fd"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Options"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d948763-a672-447b-ab07-643dfe201738"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Options"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f7d9b3f-eb7d-41f8-b752-6d011188140a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d97e745-831a-4972-9b2d-b8482c9f09fd"",
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
                    ""id"": ""a1aa2d97-7cdc-4fdf-b6cc-d4a7a0e89e94"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1607355a-648c-4403-a5a5-96498a34aa4d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Select [Keyboard]"",
                    ""id"": ""061ce736-1d94-4152-9971-b2149f9cf506"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4be017f2-6a4d-4240-82ae-2c7e97a08bd7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a9191cc4-b044-4ebe-8fb3-903689519324"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Select 2 [Keyboard]"",
                    ""id"": ""f21bd092-5e44-491a-a480-6e3543fb60ea"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""85d634bc-c714-44bf-ab86-3ba23dd5cfb4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0c0bdbf4-778b-44c0-a1cd-ff61f8817203"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Select [Gamepad]"",
                    ""id"": ""590b32b1-34e4-45f8-b429-b6989ddc3025"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3a40fd42-38de-44aa-bfdc-983b4eac0c1b"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d1cc2b74-5500-4ddf-a916-3d7820a0a54d"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Select 2 [Gamepad]"",
                    ""id"": ""c596736e-ca17-403c-b9c2-acec77f1694b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c604b4ab-29fc-416e-9457-cdc0b8f91311"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""407db823-eb45-4d78-8931-4f1fdcbcbbdb"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // P1
        m_P1 = asset.FindActionMap("P1", throwIfNotFound: true);
        m_P1_Move = m_P1.FindAction("Move", throwIfNotFound: true);
        m_P1_Jump = m_P1.FindAction("Jump", throwIfNotFound: true);
        m_P1_Attack = m_P1.FindAction("Attack", throwIfNotFound: true);
        m_P1_Interaction = m_P1.FindAction("Interaction", throwIfNotFound: true);
        m_P1_Healpotion = m_P1.FindAction("Heal potion", throwIfNotFound: true);
        m_P1_Firepotion = m_P1.FindAction("Fire potion", throwIfNotFound: true);
        m_P1_Icepotion = m_P1.FindAction("Ice potion", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_Options = m_UI.FindAction("Options", throwIfNotFound: true);
        m_UI_Enter = m_UI.FindAction("Enter", throwIfNotFound: true);
        m_UI_Exit = m_UI.FindAction("Exit", throwIfNotFound: true);
        m_UI_Select = m_UI.FindAction("Select", throwIfNotFound: true);
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

    // P1
    private readonly InputActionMap m_P1;
    private List<IP1Actions> m_P1ActionsCallbackInterfaces = new List<IP1Actions>();
    private readonly InputAction m_P1_Move;
    private readonly InputAction m_P1_Jump;
    private readonly InputAction m_P1_Attack;
    private readonly InputAction m_P1_Interaction;
    private readonly InputAction m_P1_Healpotion;
    private readonly InputAction m_P1_Firepotion;
    private readonly InputAction m_P1_Icepotion;
    public struct P1Actions
    {
        private @Default_Inputs m_Wrapper;
        public P1Actions(@Default_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_P1_Move;
        public InputAction @Jump => m_Wrapper.m_P1_Jump;
        public InputAction @Attack => m_Wrapper.m_P1_Attack;
        public InputAction @Interaction => m_Wrapper.m_P1_Interaction;
        public InputAction @Healpotion => m_Wrapper.m_P1_Healpotion;
        public InputAction @Firepotion => m_Wrapper.m_P1_Firepotion;
        public InputAction @Icepotion => m_Wrapper.m_P1_Icepotion;
        public InputActionMap Get() { return m_Wrapper.m_P1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(P1Actions set) { return set.Get(); }
        public void AddCallbacks(IP1Actions instance)
        {
            if (instance == null || m_Wrapper.m_P1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_P1ActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Interaction.started += instance.OnInteraction;
            @Interaction.performed += instance.OnInteraction;
            @Interaction.canceled += instance.OnInteraction;
            @Healpotion.started += instance.OnHealpotion;
            @Healpotion.performed += instance.OnHealpotion;
            @Healpotion.canceled += instance.OnHealpotion;
            @Firepotion.started += instance.OnFirepotion;
            @Firepotion.performed += instance.OnFirepotion;
            @Firepotion.canceled += instance.OnFirepotion;
            @Icepotion.started += instance.OnIcepotion;
            @Icepotion.performed += instance.OnIcepotion;
            @Icepotion.canceled += instance.OnIcepotion;
        }

        private void UnregisterCallbacks(IP1Actions instance)
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
            @Interaction.started -= instance.OnInteraction;
            @Interaction.performed -= instance.OnInteraction;
            @Interaction.canceled -= instance.OnInteraction;
            @Healpotion.started -= instance.OnHealpotion;
            @Healpotion.performed -= instance.OnHealpotion;
            @Healpotion.canceled -= instance.OnHealpotion;
            @Firepotion.started -= instance.OnFirepotion;
            @Firepotion.performed -= instance.OnFirepotion;
            @Firepotion.canceled -= instance.OnFirepotion;
            @Icepotion.started -= instance.OnIcepotion;
            @Icepotion.performed -= instance.OnIcepotion;
            @Icepotion.canceled -= instance.OnIcepotion;
        }

        public void RemoveCallbacks(IP1Actions instance)
        {
            if (m_Wrapper.m_P1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IP1Actions instance)
        {
            foreach (var item in m_Wrapper.m_P1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_P1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public P1Actions @P1 => new P1Actions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_Options;
    private readonly InputAction m_UI_Enter;
    private readonly InputAction m_UI_Exit;
    private readonly InputAction m_UI_Select;
    public struct UIActions
    {
        private @Default_Inputs m_Wrapper;
        public UIActions(@Default_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Options => m_Wrapper.m_UI_Options;
        public InputAction @Enter => m_Wrapper.m_UI_Enter;
        public InputAction @Exit => m_Wrapper.m_UI_Exit;
        public InputAction @Select => m_Wrapper.m_UI_Select;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @Options.started += instance.OnOptions;
            @Options.performed += instance.OnOptions;
            @Options.canceled += instance.OnOptions;
            @Enter.started += instance.OnEnter;
            @Enter.performed += instance.OnEnter;
            @Enter.canceled += instance.OnEnter;
            @Exit.started += instance.OnExit;
            @Exit.performed += instance.OnExit;
            @Exit.canceled += instance.OnExit;
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @Options.started -= instance.OnOptions;
            @Options.performed -= instance.OnOptions;
            @Options.canceled -= instance.OnOptions;
            @Enter.started -= instance.OnEnter;
            @Enter.performed -= instance.OnEnter;
            @Enter.canceled -= instance.OnEnter;
            @Exit.started -= instance.OnExit;
            @Exit.performed -= instance.OnExit;
            @Exit.canceled -= instance.OnExit;
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IP1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnHealpotion(InputAction.CallbackContext context);
        void OnFirepotion(InputAction.CallbackContext context);
        void OnIcepotion(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnOptions(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
