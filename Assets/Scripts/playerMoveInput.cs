// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/playerMoveInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMoveInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMoveInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerMoveInput"",
    ""maps"": [
        {
            ""name"": ""playerMovement"",
            ""id"": ""148221b2-0025-4a2f-9d42-f1e1ec0a532e"",
            ""actions"": [
                {
                    ""name"": ""moveForward"",
                    ""type"": ""Button"",
                    ""id"": ""21439880-3306-451c-b7d5-0af43e2ef9b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""turnRight"",
                    ""type"": ""Button"",
                    ""id"": ""88dd1d20-f03f-46ee-8ebf-915cef88a0fe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""turnLeft"",
                    ""type"": ""Button"",
                    ""id"": ""230a342e-10ed-41ea-8d90-d302ae9e207b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""placeStart"",
                    ""type"": ""Button"",
                    ""id"": ""859a0dbb-b953-4854-81d8-749b40bedce4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""placeEnd"",
                    ""type"": ""Button"",
                    ""id"": ""3a0f803d-1dcc-48ec-a786-3be0b7d1e259"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9c3f81e8-cb49-47ea-9f3a-4c30668a001a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a97c8b9e-b661-4d60-9c08-67515027aa4a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""moveForward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2dd6d837-24f1-4ac7-b0ff-c7ba8b3367bf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""065490d6-0aae-4d97-834b-d00e57467d51"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turnRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0e31be14-7ceb-4072-a1af-1fc3f42e8078"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8807801-47e0-4f7c-a445-f616fc8b03e5"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""turnLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0a63f2c-797e-4008-b446-b554bd3aaa9d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(pressPoint=0.1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""placeStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""291a82fe-db07-47bb-b9d6-25f4712ff5f4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(pressPoint=0.1,behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""placeEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerMovement
        m_playerMovement = asset.FindActionMap("playerMovement", throwIfNotFound: true);
        m_playerMovement_moveForward = m_playerMovement.FindAction("moveForward", throwIfNotFound: true);
        m_playerMovement_turnRight = m_playerMovement.FindAction("turnRight", throwIfNotFound: true);
        m_playerMovement_turnLeft = m_playerMovement.FindAction("turnLeft", throwIfNotFound: true);
        m_playerMovement_placeStart = m_playerMovement.FindAction("placeStart", throwIfNotFound: true);
        m_playerMovement_placeEnd = m_playerMovement.FindAction("placeEnd", throwIfNotFound: true);
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

    // playerMovement
    private readonly InputActionMap m_playerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_playerMovement_moveForward;
    private readonly InputAction m_playerMovement_turnRight;
    private readonly InputAction m_playerMovement_turnLeft;
    private readonly InputAction m_playerMovement_placeStart;
    private readonly InputAction m_playerMovement_placeEnd;
    public struct PlayerMovementActions
    {
        private @PlayerMoveInput m_Wrapper;
        public PlayerMovementActions(@PlayerMoveInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @moveForward => m_Wrapper.m_playerMovement_moveForward;
        public InputAction @turnRight => m_Wrapper.m_playerMovement_turnRight;
        public InputAction @turnLeft => m_Wrapper.m_playerMovement_turnLeft;
        public InputAction @placeStart => m_Wrapper.m_playerMovement_placeStart;
        public InputAction @placeEnd => m_Wrapper.m_playerMovement_placeEnd;
        public InputActionMap Get() { return m_Wrapper.m_playerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @moveForward.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMoveForward;
                @moveForward.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMoveForward;
                @moveForward.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMoveForward;
                @turnRight.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurnRight;
                @turnRight.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurnRight;
                @turnRight.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurnRight;
                @turnLeft.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurnLeft;
                @turnLeft.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurnLeft;
                @turnLeft.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnTurnLeft;
                @placeStart.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPlaceStart;
                @placeStart.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPlaceStart;
                @placeStart.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPlaceStart;
                @placeEnd.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPlaceEnd;
                @placeEnd.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPlaceEnd;
                @placeEnd.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPlaceEnd;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @moveForward.started += instance.OnMoveForward;
                @moveForward.performed += instance.OnMoveForward;
                @moveForward.canceled += instance.OnMoveForward;
                @turnRight.started += instance.OnTurnRight;
                @turnRight.performed += instance.OnTurnRight;
                @turnRight.canceled += instance.OnTurnRight;
                @turnLeft.started += instance.OnTurnLeft;
                @turnLeft.performed += instance.OnTurnLeft;
                @turnLeft.canceled += instance.OnTurnLeft;
                @placeStart.started += instance.OnPlaceStart;
                @placeStart.performed += instance.OnPlaceStart;
                @placeStart.canceled += instance.OnPlaceStart;
                @placeEnd.started += instance.OnPlaceEnd;
                @placeEnd.performed += instance.OnPlaceEnd;
                @placeEnd.canceled += instance.OnPlaceEnd;
            }
        }
    }
    public PlayerMovementActions @playerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnMoveForward(InputAction.CallbackContext context);
        void OnTurnRight(InputAction.CallbackContext context);
        void OnTurnLeft(InputAction.CallbackContext context);
        void OnPlaceStart(InputAction.CallbackContext context);
        void OnPlaceEnd(InputAction.CallbackContext context);
    }
}
