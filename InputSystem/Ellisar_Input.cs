// GENERATED AUTOMATICALLY FROM 'Assets/EllisarAssets/Scripts/InputSystem/Ellisar.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Ellisar.EllisarAssets.Scripts.InputSystem
{
    public class @Ellisar_Input : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Ellisar_Input()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Ellisar"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""2e27c64f-56de-4632-b529-c11917cc8a01"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ab084433-433d-48f9-b432-84b08c6bf35c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""e1cae3d5-0900-40a3-930d-768248588250"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""88c558b1-05c1-4ee7-9de2-a739654ab691"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ba3403e3-df34-4975-af05-9e6d23395026"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToFlight"",
                    ""type"": ""Button"",
                    ""id"": ""eb5ddeb9-5564-4786-8ba9-988ca13502b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToFlight1"",
                    ""type"": ""Button"",
                    ""id"": ""8656cbe7-28cf-419f-b9dd-657b08db061d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToBiped"",
                    ""type"": ""Button"",
                    ""id"": ""4bb58e71-944e-4220-be39-2f7e374605a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToBiped1"",
                    ""type"": ""Button"",
                    ""id"": ""8b29024a-3c79-4a01-b767-5b2397dbd5e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToAgile"",
                    ""type"": ""Button"",
                    ""id"": ""2a7b5be3-bcc2-436b-9570-06600df29d97"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToAgile1"",
                    ""type"": ""Button"",
                    ""id"": ""9331b50e-7290-4c87-9c86-dbfd771a1c8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYCam"",
                    ""type"": ""Button"",
                    ""id"": ""ff41abf5-728d-4be2-bcde-c523b3ebb484"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYFlight"",
                    ""type"": ""Button"",
                    ""id"": ""46787e46-c78b-49ee-9495-9f0406550ee8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LessSensitivity"",
                    ""type"": ""Button"",
                    ""id"": ""c2138d37-98b1-4c3f-9a2a-32d9945603df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoreSensitivity"",
                    ""type"": ""Button"",
                    ""id"": ""8cb28e4c-5894-4dc7-9619-3f1899c5acc3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TranformationModifierButton"",
                    ""type"": ""Button"",
                    ""id"": ""10e99d4c-dabe-4a21-8c43-32dc2fab16a3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""2a1b03e5-5d76-4e49-8c13-40430d63a7ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowControls"",
                    ""type"": ""Button"",
                    ""id"": ""ab1ab409-09cf-4f86-8935-a5d50b173c16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""48927b45-7fbc-4e97-a034-094a73f3ecf2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""978bfe49-cc26-4a3d-ab7b-7d7a29327403"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""00ca640b-d935-4593-8157-c05846ea39b3"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2062cb9-1b15-46a2-838c-2f8d72a0bdd9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8180e8bd-4097-4f4e-ab88-4523101a6ce9"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""320bffee-a40b-4347-ac70-c210eb8bc73a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1c5327b5-f71c-4f60-99c7-4e737386f1d1"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d2581a9b-1d11-4566-b27d-b92aff5fabbc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2e46982e-44cc-431b-9f0b-c11910bf467a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcfe95b8-67b9-4526-84b5-5d0bc98d6400"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""77bff152-3580-4b21-b6de-dcd0c7e41164"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1635d3fe-58b6-4ba9-a4e2-f4b964f6b5c8"",
                    ""path"": ""<XRController>/{Primary2DAxis}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ea4d645-4504-4529-b061-ab81934c3752"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1f7a91b-d0fd-4a62-997e-7fb9b69bf235"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c8e490b-c610-4785-884f-f04217b23ca4"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e5f5442-8668-4b27-a940-df99bad7e831"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""143bb1cd-cc10-4eca-a2f0-a3664166fe91"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05f6913d-c316-48b2-a6bb-e225f14c7960"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""886e731e-7071-4ae4-95c0-e61739dad6fd"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Touch"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee3d0cd2-254e-47a7-a8cb-bc94d9658c54"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8255d333-5683-4943-a58a-ccb207ff1dce"",
                    ""path"": ""<XRController>/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8da117c2-1711-4d46-ae57-6fd87d99619e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36c79660-b0ef-4356-be96-fcb0767c1b55"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8855481b-8286-4cfa-8d12-d9b1a8d3a245"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""313e9ac6-069d-4dc8-98a1-308d1cab722c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""37d736a1-276c-4236-ab70-ee5ea2f3cbdc"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""2edfe904-ccee-4e5c-b9a9-6eb01b947b26"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""032208c5-5747-420f-9bd8-be4149c5cf95"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""3cfa6b7c-aecd-45f8-977d-8e2e82f22af6"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""f7bd8cbe-1159-4bda-a3b2-898b313403f7"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""5d3bd198-9673-4c2b-8300-687a9b2f6af9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ddb7376e-6408-4cb7-ab74-c78749d8b79d"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InvertYCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4e9b634-523d-47b3-a2d5-e75285d23efa"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InvertYCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a00b2888-1c2c-41b6-9782-1269abaa11de"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InvertYFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c349113c-23f4-47ad-9a93-e2bec633ecfc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InvertYFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce92ebbe-7de3-42bd-abd5-ebfbcc46bc73"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""LessSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fc2cdd7-85d4-4e4f-a800-b435bdada14e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LessSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5be52c66-3742-4df6-947a-efe073c4048a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoreSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61fc729a-76d2-4dde-a8b0-3e9d260faeee"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoreSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3bfe2c5d-f5a2-4da8-99d0-a783f96c3a68"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TranformationModifierButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92c1a46e-8878-48b6-9e1b-f67ffadf3c6e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""fae0eb66-6403-4749-b287-58c6e393867b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""d7a00fb1-bb03-435c-a87e-b840cafc29bc"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""23b87000-c9b5-4da1-a04b-22a64c0d1912"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2847dbfd-3372-4747-b9fc-0df472e927bd"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09772679-5aae-44ca-bf6b-bbc07c1b24ca"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9acf7a39-f1b4-4928-9d29-5c703afefc39"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToFlight1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""879c0023-1684-453d-bffc-38b3d6975f64"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdace9a0-4a60-4257-af56-50c2d86fd7d1"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToBiped1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a68af469-7fb3-41ef-b638-bafb5bff8333"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0de7b4b0-2bf7-47f1-b870-be4f12f4bf46"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToAgile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ce0c139b-cdc1-43d9-a7ce-9d3dc39e569e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d99d1800-b6f9-41ff-ab92-3280b03e2496"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShowControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99725a7f-1f35-421b-8822-4aa7e6e33fa2"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ShowControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ad01be3-265a-42f8-962b-cea8ca19c121"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bad3b298-b478-446d-bd02-31c0b8c2bd97"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""1HandL"",
            ""id"": ""24dadd7a-3d10-4277-8588-a1309f8d3341"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""eee2a3c5-84d1-457d-b675-a805eb3fd662"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""ba23049b-2f5e-456e-b763-c3e5f9db76cc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""71dda59b-ee90-49c8-bed8-54b319f86009"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""3fe25779-ecdf-4dff-ac79-59306851d28c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToFlight"",
                    ""type"": ""Button"",
                    ""id"": ""3266b20c-a9b6-4e18-9057-b43f9444b718"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToFlight1"",
                    ""type"": ""Button"",
                    ""id"": ""b66cb5da-8a18-423c-ba78-b6b32edb2ef9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToBiped"",
                    ""type"": ""Button"",
                    ""id"": ""9dfd6633-5b75-42a0-b6f2-c15ef63e5493"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToBiped1"",
                    ""type"": ""Button"",
                    ""id"": ""1c505f45-441c-4efd-b452-f0acca3f7cc0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToAgile"",
                    ""type"": ""Button"",
                    ""id"": ""965a9a96-c2e6-473c-a570-26be3d4e8d3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToAgile1"",
                    ""type"": ""Button"",
                    ""id"": ""3881f765-7494-4017-8089-443f5ece54e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYCam"",
                    ""type"": ""Button"",
                    ""id"": ""ab6a3569-8d07-4cff-a9f9-8c407262fac9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYFlight"",
                    ""type"": ""Button"",
                    ""id"": ""97e3bcd4-909c-4de5-a324-05ed2b4cb308"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LessSensitivity"",
                    ""type"": ""Button"",
                    ""id"": ""ef55cd2a-cf91-4c60-bf8b-24b621752051"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoreSensitivity"",
                    ""type"": ""Button"",
                    ""id"": ""d8f373c6-7e39-438f-a59c-eda1791c5716"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TranformationModifierButton"",
                    ""type"": ""Button"",
                    ""id"": ""26a9d076-e7e4-46c6-b689-efdadd0e11c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3007c9cd-7298-4d3f-9ad1-57caf1aad30f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowControls"",
                    ""type"": ""Button"",
                    ""id"": ""6586a825-8107-4d5f-86cf-ea30e1142810"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""68ebc223-16a5-47f1-b895-f78ebe340bc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""59ad7fbe-4f92-4965-bb3d-cc1f837b9aa5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""c7d73f53-94a8-4705-948a-acaecd97db6f"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b90d3750-5196-4bb1-abdb-f61db31f3261"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""04a32994-222f-4cd0-b07a-ac4ea276a994"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""99a130fd-c8d7-4131-9b9a-ae651283e85d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""48cb1c60-ffd9-4984-a800-d81b327f146d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6288ef64-262f-42fb-9592-490ab93ab536"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""894fa09e-478f-49fd-a487-e2fb7633ad9f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dc377573-952e-47d1-aa83-5318e4bd0ecb"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0e443bf4-5259-4404-bba3-01c7e25a5122"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d666db0f-a57a-4cfc-bae1-ac94240448e7"",
                    ""path"": ""<XRController>/{Primary2DAxis}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c77ea99d-a18d-4c25-9cc2-08f81aeab7e1"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32a8a5d7-8b92-4f1f-9a04-900faa3bd680"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4a848ae-10e6-42dc-a3d7-de2c5adbfea8"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7e9abfe-95dd-4268-b2b3-0f272e372d8c"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""023d6aad-69ed-4a33-9147-3367e6c20ac7"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""daae15b9-b6cc-4d9a-a2bc-9769c090c23a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48612e51-de98-444e-b8d8-d0c4dd0bd0ab"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Touch"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59439bf4-2b09-4c56-8b25-2591b2068f93"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8cf6a5b7-b721-48ef-83b7-8bf2bfb8c445"",
                    ""path"": ""<XRController>/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e51c8437-da01-444e-b64f-f5c0c07d3173"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62460e1f-8184-458b-ae72-c395ee1151b6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2f8d359-6e2a-415a-b5e7-559a705ea5c0"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""0f0345e6-2257-4f5a-9f32-41eb8f2cb37b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""486422b6-6435-47c1-9217-a765346a99cf"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""775f40a8-d34a-43d3-a00c-f36135168e43"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b0a79e68-4acb-4c22-b624-0bd8c23387e4"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""2806ed81-0e1b-4316-bf83-cbcde8848b20"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4c25f58b-1078-4087-8c73-6a93432b847f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""bd0e5046-17c4-41e9-8c4b-f63f13b3159f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ffbf966a-7baf-4ebc-b202-7bc9dbabfc7c"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InvertYCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""601c1225-f74e-405b-bb84-ca61683fefb2"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InvertYCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d919460-e970-477f-964b-d0caf9ea5fb7"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InvertYFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc22a381-1543-40a1-883a-f3795570ecc4"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InvertYFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d101405-14aa-4bdf-95b7-a2110325c5af"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""LessSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0a4f7ef-f6d1-4c8a-8858-e01285c285f6"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LessSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9017f456-10c3-4a88-ba06-220f35db1403"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoreSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""da72d7bd-fc94-4501-8444-96a17dbcc13f"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoreSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5cce89d7-a858-49f8-9a8d-d7cda5b4ee6b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TranformationModifierButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb46ed7a-a968-4ee1-b850-0d4e1f8bbadd"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""8585ade8-bbcc-43dc-8967-474b9c721d5f"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""fe3513b7-7540-4bba-a63c-a3f205b591f0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""44b3eb27-dc7f-42c8-9b86-9538798a02c4"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3dbe8ffe-e447-4db2-908c-a62aa01d0584"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aad0da52-9647-4edd-82d8-1dac227419a1"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0381e251-7cdc-40de-bb67-9693a30bbbdb"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToFlight1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52c2f3d6-ff4f-4eed-83d6-619ced85534b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0b63ed5-d754-40c6-9dea-108a469ee83f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToBiped1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c7df9fd-2d3b-4336-886b-a3bf5ff8e0d2"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dce4aaec-7b5d-41e6-85e6-1313494e6650"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToAgile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5abf4ed1-62ba-4b93-a2d9-311f3d3982f3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02bedab8-c005-4f0e-9405-ba60231d1368"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShowControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0045e054-4a8b-4f7b-9132-710e871d0743"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ShowControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db47e1fd-ca3b-4ac5-bfc9-a928790e5c81"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cf4b1f1-3faf-4b60-9d38-2717d80c615f"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""1HandR"",
            ""id"": ""71d7b2b1-c17d-4392-9f0d-74e4d808209c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7b86fe1f-6575-4121-a2d7-0ea6551ea2e2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""604989f5-fd3c-425b-811e-c57f85b59672"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""5bcbc0ba-f9e3-4a1a-926b-efbe6b7035bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c440f6d0-171d-4c6f-9775-86a14f19bb16"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToFlight"",
                    ""type"": ""Button"",
                    ""id"": ""fbb70096-989f-4206-aca3-e3f8625e17fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToFlight1"",
                    ""type"": ""Button"",
                    ""id"": ""10d20d97-d7dd-4d30-aef3-3f94205f3856"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToBiped"",
                    ""type"": ""Button"",
                    ""id"": ""4dfd6cef-d9c8-4d46-bd37-5d51b6a5f06b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToBiped1"",
                    ""type"": ""Button"",
                    ""id"": ""94c71966-629b-4011-ab4c-8115187cd72c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToAgile"",
                    ""type"": ""Button"",
                    ""id"": ""1acdbfb1-603d-4648-9105-c4294273e988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeToAgile1"",
                    ""type"": ""Button"",
                    ""id"": ""51b3db66-d987-44c4-9130-5fe9fdf80f27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYCam"",
                    ""type"": ""Button"",
                    ""id"": ""119155c2-35c3-4ac3-819e-3a053f78e70c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvertYFlight"",
                    ""type"": ""Button"",
                    ""id"": ""8480624d-5b58-4040-932c-659a9dad1468"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LessSensitivity"",
                    ""type"": ""Button"",
                    ""id"": ""04d7b92c-4133-44dd-9603-005009bbd7b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoreSensitivity"",
                    ""type"": ""Button"",
                    ""id"": ""98afacd2-b2ef-4a08-a0ba-0653cbe101ae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TranformationModifierButton"",
                    ""type"": ""Button"",
                    ""id"": ""631552ad-8123-4a24-966d-904dbc08ce17"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""8d38d1da-eb1f-41e8-b2f5-c5d4c5c69a71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowControls"",
                    ""type"": ""Button"",
                    ""id"": ""f6062e39-3d36-4cce-ab04-5de0686ce438"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenMenu"",
                    ""type"": ""Button"",
                    ""id"": ""7ab1083a-a25c-4a74-b06a-ce1df8862791"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""81585a56-ac64-4bda-9e7f-b5993fa0f7c5"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""26916ad3-0ce8-43f4-a15c-ca5df54f900c"",
                    ""path"": ""Dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""57a47a2c-726e-4bcc-b2e2-396f78b908e4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""216b31d7-386d-4e5b-9098-5cc6527d48c8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7cb1c2ee-a3f1-4bc2-a2d0-d4f4af6be695"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7644a4d1-5b5d-4e11-bcac-1436beef6f5a"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""69dda5cd-ab7a-430b-b826-9007adb67c15"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b82b137-15d4-4a64-a2ee-1d4796161d43"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9e06e2e3-91d4-4881-b5a0-ffc332c47200"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""02d35567-93b3-4a6f-994f-4163a80fce78"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4cacfb01-ff54-4a07-88ff-9169d3bad83e"",
                    ""path"": ""<XRController>/{Primary2DAxis}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fe7f310-ea6e-4335-b7d0-c33a89431583"",
                    ""path"": ""<Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7d1e91df-d837-4e79-847d-b4aced16c77f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ede963f3-5ab3-4ccb-90f0-f9a66edec653"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse;Touch"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f6683f4-f206-47b1-a5d4-c824ff3eda53"",
                    ""path"": ""<Joystick>/{Hatswitch}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34cf40c6-113f-4782-a3e0-d0c3d0d998cc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85be7c7e-07c9-4541-9094-bd381f87a8aa"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fad7774-2048-44e6-9975-e3f30799dc1b"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Touch"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bbdf53d-160e-4ac3-8bca-3de4069b9916"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93061700-2424-4fc3-a6a6-cc95bb30d8c1"",
                    ""path"": ""<XRController>/{PrimaryAction}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba69212d-1267-4a46-bade-a97d18ca9d39"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8bebe285-ae9a-48a1-9222-84d617a3aec0"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""664df21d-46f6-48c9-8590-23aef311aabe"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""a01dfc8d-f54b-4af2-8ff9-f84caec2f175"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""04fa28b0-6130-48ea-abaf-2178219a81db"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""3857cdbe-4e38-4b02-9451-345c1f3e5314"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bd8695bc-6220-437a-b2b1-4b85c1648270"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""73d011de-254d-4592-bc05-f662ebdd661e"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""adeae44c-eef4-4218-a3af-9bb3ad124e54"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e66c415d-973d-449b-9b3c-59c5f743c1c2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""be24832f-cd88-4741-b86a-c45b79331c04"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InvertYCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcbd1b80-bb7c-497d-ab0a-483531fa3ce4"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InvertYCam"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f1b7992-55c9-4d03-af12-0bd466e83c71"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""InvertYFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a88896b1-262f-4a4f-973c-cc333e0bf53e"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""InvertYFlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e2007aa-e95c-451d-94ee-aa9c1f87cf86"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""LessSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae00f4e0-d21f-4e1b-b449-79e1bfd4ed6e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LessSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19c3a328-3248-459a-8a40-f99716313209"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""MoreSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f870cef7-2e9b-4fdc-ac3d-82a3d5866b01"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MoreSensitivity"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8a7e54a-d7cf-46f6-8242-c0fc41fa4697"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""TranformationModifierButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ece9082a-b8a5-43ff-a107-3b59c1fc639e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""4d2049f4-38d8-4bc5-a3a4-304a0d9b6429"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4415acc6-ed36-4800-bc26-67b23bb3fc10"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""7ef1fa13-7b15-420f-9d1e-e08eeda48f5c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bd1e73a8-2829-4f85-9ee5-2c98c82b0ac8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ec5789f-191a-4f8a-bd68-74ab28047126"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59229ae6-857a-4fc6-a2c8-af2ad5e7bcc2"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToFlight1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95fd69e2-5b54-4326-be2b-c8025c1b3222"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToFlight1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23155d20-03ed-418f-83b2-026f7b48ced4"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToBiped1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0706c34-99a6-42c6-ba6a-65f74a9fc870"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToBiped1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""206de64f-788b-400e-a26c-5acfafd43666"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ChangeToAgile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07e857b0-307e-41d7-959a-ec9c809f56d9"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ChangeToAgile1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d64c0fc5-5dcf-4a7e-b064-3e44f07e60ca"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""ShowControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""453424df-2eef-4a86-9407-d1aec7f4fc46"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""ShowControls"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a88a439f-c443-4fb0-ba76-a48159abb6ea"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdb3d733-a76c-405b-ac68-5b9fc43fdb53"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""OpenMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""7160f732-6ec7-4bbb-a3f1-ac8cb3948455"",
            ""actions"": [
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""5b06954f-3cb9-44aa-bd8e-294ae308c568"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""f3dfdeb9-0a07-412f-8247-8c4028e7c27f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""1b206dd5-62f2-49ce-a4f7-36229f72807e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ee29469e-11fa-43a1-9763-adb25e5a9f25"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b89b5f0a-2278-4e33-92fb-c73651a29687"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ca54a693-48d1-46ce-b2f8-cec3090effac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a1da46c7-6772-4785-a806-2c27598c8001"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7aee4f26-0e8f-401c-b0bf-d37bc67dc338"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""619216a0-d2f4-4596-a386-d184601e342d"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ce464803-b912-466f-a2a2-39f0fbdb7532"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""809f371f-c5e2-4e7a-83a1-d867598f40dd"",
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
                    ""id"": ""14a5d6e8-4aaf-4119-a9ef-34b8c2c548bf"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9144cbe6-05e1-4687-a6d7-24f99d23dd81"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2db08d65-c5fb-421b-983f-c71163608d67"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""58748904-2ea9-4a80-8579-b500e6a76df8"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8ba04515-75aa-45de-966d-393d9bbd1c14"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""712e721c-bdfb-4b23-a86c-a0d9fcfea921"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fcd248ae-a788-4676-a12e-f4d81205600b"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f04d9bc-c50b-41a1-bfcc-afb75475ec20"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fb8277d4-c5cd-4663-9dc7-ee3f0b506d90"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""e25d9774-381c-4a61-b47c-7b6b299ad9f9"",
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
                    ""id"": ""3db53b26-6601-41be-9887-63ac74e79d19"",
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
                    ""id"": ""0cb3e13e-3d90-4178-8ae6-d9c5501d653f"",
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
                    ""id"": ""0392d399-f6dd-4c82-8062-c1e9c0d34835"",
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
                    ""id"": ""942a66d9-d42f-43d6-8d70-ecb4ba5363bc"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ff527021-f211-4c02-933e-5976594c46ed"",
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
                    ""id"": ""563fbfdd-0f09-408d-aa75-8642c4f08ef0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eb480147-c587-4a33-85ed-eb0ab9942c43"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2bf42165-60bc-42ca-8072-8c13ab40239b"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""85d264ad-e0a0-4565-b7ff-1a37edde51ac"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""74214943-c580-44e4-98eb-ad7eebe17902"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cea9b045-a000-445b-95b8-0c171af70a3b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8607c725-d935-4808-84b1-8354e29bab63"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4cda81dc-9edd-4e03-9d7c-a71a14345d0b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9e92bb26-7e3b-4ec4-b06b-3c8f8e498ddc"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82627dcc-3b13-4ba9-841d-e4b746d6553e"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c52c8e0b-8179-41d3-b8a1-d149033bbe86"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1394cbc-336e-44ce-9ea8-6007ed6193f7"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5693e57a-238a-46ed-b5ae-e64e6e574302"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4faf7dc9-b979-4210-aa8c-e808e1ef89f5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8d66d5ba-88d7-48e6-b1cd-198bbfef7ace"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47c2a644-3ebc-4dae-a106-589b7ca75b59"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb9e6b34-44bf-4381-ac63-5aa15d19f677"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""38c99815-14ea-4617-8627-164d27641299"",
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
                    ""id"": ""24066f69-da47-44f3-a07e-0015fb02eb2e"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c191405-5738-4d4b-a523-c6a301dbf754"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7236c0d9-6ca3-47cf-a6ee-a97f5b59ea77"",
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
                    ""id"": ""23e01e3a-f935-4948-8d8b-9bcac77714fb"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
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
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
            m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_ChangeToFlight = m_Player.FindAction("ChangeToFlight", throwIfNotFound: true);
            m_Player_ChangeToFlight1 = m_Player.FindAction("ChangeToFlight1", throwIfNotFound: true);
            m_Player_ChangeToBiped = m_Player.FindAction("ChangeToBiped", throwIfNotFound: true);
            m_Player_ChangeToBiped1 = m_Player.FindAction("ChangeToBiped1", throwIfNotFound: true);
            m_Player_ChangeToAgile = m_Player.FindAction("ChangeToAgile", throwIfNotFound: true);
            m_Player_ChangeToAgile1 = m_Player.FindAction("ChangeToAgile1", throwIfNotFound: true);
            m_Player_InvertYCam = m_Player.FindAction("InvertYCam", throwIfNotFound: true);
            m_Player_InvertYFlight = m_Player.FindAction("InvertYFlight", throwIfNotFound: true);
            m_Player_LessSensitivity = m_Player.FindAction("LessSensitivity", throwIfNotFound: true);
            m_Player_MoreSensitivity = m_Player.FindAction("MoreSensitivity", throwIfNotFound: true);
            m_Player_TranformationModifierButton = m_Player.FindAction("TranformationModifierButton", throwIfNotFound: true);
            m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
            m_Player_ShowControls = m_Player.FindAction("ShowControls", throwIfNotFound: true);
            m_Player_OpenMenu = m_Player.FindAction("OpenMenu", throwIfNotFound: true);
            // 1HandL
            m__1HandL = asset.FindActionMap("1HandL", throwIfNotFound: true);
            m__1HandL_Move = m__1HandL.FindAction("Move", throwIfNotFound: true);
            m__1HandL_Look = m__1HandL.FindAction("Look", throwIfNotFound: true);
            m__1HandL_Fire = m__1HandL.FindAction("Fire", throwIfNotFound: true);
            m__1HandL_Jump = m__1HandL.FindAction("Jump", throwIfNotFound: true);
            m__1HandL_ChangeToFlight = m__1HandL.FindAction("ChangeToFlight", throwIfNotFound: true);
            m__1HandL_ChangeToFlight1 = m__1HandL.FindAction("ChangeToFlight1", throwIfNotFound: true);
            m__1HandL_ChangeToBiped = m__1HandL.FindAction("ChangeToBiped", throwIfNotFound: true);
            m__1HandL_ChangeToBiped1 = m__1HandL.FindAction("ChangeToBiped1", throwIfNotFound: true);
            m__1HandL_ChangeToAgile = m__1HandL.FindAction("ChangeToAgile", throwIfNotFound: true);
            m__1HandL_ChangeToAgile1 = m__1HandL.FindAction("ChangeToAgile1", throwIfNotFound: true);
            m__1HandL_InvertYCam = m__1HandL.FindAction("InvertYCam", throwIfNotFound: true);
            m__1HandL_InvertYFlight = m__1HandL.FindAction("InvertYFlight", throwIfNotFound: true);
            m__1HandL_LessSensitivity = m__1HandL.FindAction("LessSensitivity", throwIfNotFound: true);
            m__1HandL_MoreSensitivity = m__1HandL.FindAction("MoreSensitivity", throwIfNotFound: true);
            m__1HandL_TranformationModifierButton = m__1HandL.FindAction("TranformationModifierButton", throwIfNotFound: true);
            m__1HandL_Interact = m__1HandL.FindAction("Interact", throwIfNotFound: true);
            m__1HandL_ShowControls = m__1HandL.FindAction("ShowControls", throwIfNotFound: true);
            m__1HandL_OpenMenu = m__1HandL.FindAction("OpenMenu", throwIfNotFound: true);
            // 1HandR
            m__1HandR = asset.FindActionMap("1HandR", throwIfNotFound: true);
            m__1HandR_Move = m__1HandR.FindAction("Move", throwIfNotFound: true);
            m__1HandR_Look = m__1HandR.FindAction("Look", throwIfNotFound: true);
            m__1HandR_Fire = m__1HandR.FindAction("Fire", throwIfNotFound: true);
            m__1HandR_Jump = m__1HandR.FindAction("Jump", throwIfNotFound: true);
            m__1HandR_ChangeToFlight = m__1HandR.FindAction("ChangeToFlight", throwIfNotFound: true);
            m__1HandR_ChangeToFlight1 = m__1HandR.FindAction("ChangeToFlight1", throwIfNotFound: true);
            m__1HandR_ChangeToBiped = m__1HandR.FindAction("ChangeToBiped", throwIfNotFound: true);
            m__1HandR_ChangeToBiped1 = m__1HandR.FindAction("ChangeToBiped1", throwIfNotFound: true);
            m__1HandR_ChangeToAgile = m__1HandR.FindAction("ChangeToAgile", throwIfNotFound: true);
            m__1HandR_ChangeToAgile1 = m__1HandR.FindAction("ChangeToAgile1", throwIfNotFound: true);
            m__1HandR_InvertYCam = m__1HandR.FindAction("InvertYCam", throwIfNotFound: true);
            m__1HandR_InvertYFlight = m__1HandR.FindAction("InvertYFlight", throwIfNotFound: true);
            m__1HandR_LessSensitivity = m__1HandR.FindAction("LessSensitivity", throwIfNotFound: true);
            m__1HandR_MoreSensitivity = m__1HandR.FindAction("MoreSensitivity", throwIfNotFound: true);
            m__1HandR_TranformationModifierButton = m__1HandR.FindAction("TranformationModifierButton", throwIfNotFound: true);
            m__1HandR_Interact = m__1HandR.FindAction("Interact", throwIfNotFound: true);
            m__1HandR_ShowControls = m__1HandR.FindAction("ShowControls", throwIfNotFound: true);
            m__1HandR_OpenMenu = m__1HandR.FindAction("OpenMenu", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
            m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
            m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
            m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
            m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
            m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
            m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
            m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
            m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
            m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Fire;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_ChangeToFlight;
        private readonly InputAction m_Player_ChangeToFlight1;
        private readonly InputAction m_Player_ChangeToBiped;
        private readonly InputAction m_Player_ChangeToBiped1;
        private readonly InputAction m_Player_ChangeToAgile;
        private readonly InputAction m_Player_ChangeToAgile1;
        private readonly InputAction m_Player_InvertYCam;
        private readonly InputAction m_Player_InvertYFlight;
        private readonly InputAction m_Player_LessSensitivity;
        private readonly InputAction m_Player_MoreSensitivity;
        private readonly InputAction m_Player_TranformationModifierButton;
        private readonly InputAction m_Player_Interact;
        private readonly InputAction m_Player_ShowControls;
        private readonly InputAction m_Player_OpenMenu;
        public struct PlayerActions
        {
            private @Ellisar_Input m_Wrapper;
            public PlayerActions(@Ellisar_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @Look => m_Wrapper.m_Player_Look;
            public InputAction @Fire => m_Wrapper.m_Player_Fire;
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @ChangeToFlight => m_Wrapper.m_Player_ChangeToFlight;
            public InputAction @ChangeToFlight1 => m_Wrapper.m_Player_ChangeToFlight1;
            public InputAction @ChangeToBiped => m_Wrapper.m_Player_ChangeToBiped;
            public InputAction @ChangeToBiped1 => m_Wrapper.m_Player_ChangeToBiped1;
            public InputAction @ChangeToAgile => m_Wrapper.m_Player_ChangeToAgile;
            public InputAction @ChangeToAgile1 => m_Wrapper.m_Player_ChangeToAgile1;
            public InputAction @InvertYCam => m_Wrapper.m_Player_InvertYCam;
            public InputAction @InvertYFlight => m_Wrapper.m_Player_InvertYFlight;
            public InputAction @LessSensitivity => m_Wrapper.m_Player_LessSensitivity;
            public InputAction @MoreSensitivity => m_Wrapper.m_Player_MoreSensitivity;
            public InputAction @TranformationModifierButton => m_Wrapper.m_Player_TranformationModifierButton;
            public InputAction @Interact => m_Wrapper.m_Player_Interact;
            public InputAction @ShowControls => m_Wrapper.m_Player_ShowControls;
            public InputAction @OpenMenu => m_Wrapper.m_Player_OpenMenu;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @ChangeToFlight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToFlight1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToFlight1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToBiped.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToBiped1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToBiped1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToAgile.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToAgile1;
                    @ChangeToAgile1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToAgile1;
                    @ChangeToAgile1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnChangeToAgile1;
                    @InvertYCam.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvertYCam;
                    @InvertYCam.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvertYCam;
                    @InvertYCam.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvertYCam;
                    @InvertYFlight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvertYFlight;
                    @InvertYFlight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvertYFlight;
                    @InvertYFlight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvertYFlight;
                    @LessSensitivity.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLessSensitivity;
                    @LessSensitivity.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLessSensitivity;
                    @LessSensitivity.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLessSensitivity;
                    @MoreSensitivity.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoreSensitivity;
                    @MoreSensitivity.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoreSensitivity;
                    @MoreSensitivity.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMoreSensitivity;
                    @TranformationModifierButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTranformationModifierButton;
                    @TranformationModifierButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTranformationModifierButton;
                    @TranformationModifierButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTranformationModifierButton;
                    @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                    @ShowControls.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShowControls;
                    @ShowControls.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShowControls;
                    @ShowControls.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShowControls;
                    @OpenMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOpenMenu;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @ChangeToFlight.started += instance.OnChangeToFlight;
                    @ChangeToFlight.performed += instance.OnChangeToFlight;
                    @ChangeToFlight.canceled += instance.OnChangeToFlight;
                    @ChangeToFlight1.started += instance.OnChangeToFlight1;
                    @ChangeToFlight1.performed += instance.OnChangeToFlight1;
                    @ChangeToFlight1.canceled += instance.OnChangeToFlight1;
                    @ChangeToBiped.started += instance.OnChangeToBiped;
                    @ChangeToBiped.performed += instance.OnChangeToBiped;
                    @ChangeToBiped.canceled += instance.OnChangeToBiped;
                    @ChangeToBiped1.started += instance.OnChangeToBiped1;
                    @ChangeToBiped1.performed += instance.OnChangeToBiped1;
                    @ChangeToBiped1.canceled += instance.OnChangeToBiped1;
                    @ChangeToAgile.started += instance.OnChangeToAgile;
                    @ChangeToAgile.performed += instance.OnChangeToAgile;
                    @ChangeToAgile.canceled += instance.OnChangeToAgile;
                    @ChangeToAgile1.started += instance.OnChangeToAgile1;
                    @ChangeToAgile1.performed += instance.OnChangeToAgile1;
                    @ChangeToAgile1.canceled += instance.OnChangeToAgile1;
                    @InvertYCam.started += instance.OnInvertYCam;
                    @InvertYCam.performed += instance.OnInvertYCam;
                    @InvertYCam.canceled += instance.OnInvertYCam;
                    @InvertYFlight.started += instance.OnInvertYFlight;
                    @InvertYFlight.performed += instance.OnInvertYFlight;
                    @InvertYFlight.canceled += instance.OnInvertYFlight;
                    @LessSensitivity.started += instance.OnLessSensitivity;
                    @LessSensitivity.performed += instance.OnLessSensitivity;
                    @LessSensitivity.canceled += instance.OnLessSensitivity;
                    @MoreSensitivity.started += instance.OnMoreSensitivity;
                    @MoreSensitivity.performed += instance.OnMoreSensitivity;
                    @MoreSensitivity.canceled += instance.OnMoreSensitivity;
                    @TranformationModifierButton.started += instance.OnTranformationModifierButton;
                    @TranformationModifierButton.performed += instance.OnTranformationModifierButton;
                    @TranformationModifierButton.canceled += instance.OnTranformationModifierButton;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @ShowControls.started += instance.OnShowControls;
                    @ShowControls.performed += instance.OnShowControls;
                    @ShowControls.canceled += instance.OnShowControls;
                    @OpenMenu.started += instance.OnOpenMenu;
                    @OpenMenu.performed += instance.OnOpenMenu;
                    @OpenMenu.canceled += instance.OnOpenMenu;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // 1HandL
        private readonly InputActionMap m__1HandL;
        private I_1HandLActions m__1HandLActionsCallbackInterface;
        private readonly InputAction m__1HandL_Move;
        private readonly InputAction m__1HandL_Look;
        private readonly InputAction m__1HandL_Fire;
        private readonly InputAction m__1HandL_Jump;
        private readonly InputAction m__1HandL_ChangeToFlight;
        private readonly InputAction m__1HandL_ChangeToFlight1;
        private readonly InputAction m__1HandL_ChangeToBiped;
        private readonly InputAction m__1HandL_ChangeToBiped1;
        private readonly InputAction m__1HandL_ChangeToAgile;
        private readonly InputAction m__1HandL_ChangeToAgile1;
        private readonly InputAction m__1HandL_InvertYCam;
        private readonly InputAction m__1HandL_InvertYFlight;
        private readonly InputAction m__1HandL_LessSensitivity;
        private readonly InputAction m__1HandL_MoreSensitivity;
        private readonly InputAction m__1HandL_TranformationModifierButton;
        private readonly InputAction m__1HandL_Interact;
        private readonly InputAction m__1HandL_ShowControls;
        private readonly InputAction m__1HandL_OpenMenu;
        public struct _1HandLActions
        {
            private @Ellisar_Input m_Wrapper;
            public _1HandLActions(@Ellisar_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m__1HandL_Move;
            public InputAction @Look => m_Wrapper.m__1HandL_Look;
            public InputAction @Fire => m_Wrapper.m__1HandL_Fire;
            public InputAction @Jump => m_Wrapper.m__1HandL_Jump;
            public InputAction @ChangeToFlight => m_Wrapper.m__1HandL_ChangeToFlight;
            public InputAction @ChangeToFlight1 => m_Wrapper.m__1HandL_ChangeToFlight1;
            public InputAction @ChangeToBiped => m_Wrapper.m__1HandL_ChangeToBiped;
            public InputAction @ChangeToBiped1 => m_Wrapper.m__1HandL_ChangeToBiped1;
            public InputAction @ChangeToAgile => m_Wrapper.m__1HandL_ChangeToAgile;
            public InputAction @ChangeToAgile1 => m_Wrapper.m__1HandL_ChangeToAgile1;
            public InputAction @InvertYCam => m_Wrapper.m__1HandL_InvertYCam;
            public InputAction @InvertYFlight => m_Wrapper.m__1HandL_InvertYFlight;
            public InputAction @LessSensitivity => m_Wrapper.m__1HandL_LessSensitivity;
            public InputAction @MoreSensitivity => m_Wrapper.m__1HandL_MoreSensitivity;
            public InputAction @TranformationModifierButton => m_Wrapper.m__1HandL_TranformationModifierButton;
            public InputAction @Interact => m_Wrapper.m__1HandL_Interact;
            public InputAction @ShowControls => m_Wrapper.m__1HandL_ShowControls;
            public InputAction @OpenMenu => m_Wrapper.m__1HandL_OpenMenu;
            public InputActionMap Get() { return m_Wrapper.m__1HandL; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(_1HandLActions set) { return set.Get(); }
            public void SetCallbacks(I_1HandLActions instance)
            {
                if (m_Wrapper.m__1HandLActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnMove;
                    @Look.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnLook;
                    @Fire.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnFire;
                    @Jump.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnJump;
                    @ChangeToFlight.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight1.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToFlight1.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToFlight1.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToBiped.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped1.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToBiped1.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToBiped1.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToAgile.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile1.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToAgile1;
                    @ChangeToAgile1.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToAgile1;
                    @ChangeToAgile1.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnChangeToAgile1;
                    @InvertYCam.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInvertYCam;
                    @InvertYCam.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInvertYCam;
                    @InvertYCam.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInvertYCam;
                    @InvertYFlight.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInvertYFlight;
                    @InvertYFlight.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInvertYFlight;
                    @InvertYFlight.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInvertYFlight;
                    @LessSensitivity.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnLessSensitivity;
                    @LessSensitivity.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnLessSensitivity;
                    @LessSensitivity.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnLessSensitivity;
                    @MoreSensitivity.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnMoreSensitivity;
                    @MoreSensitivity.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnMoreSensitivity;
                    @MoreSensitivity.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnMoreSensitivity;
                    @TranformationModifierButton.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnTranformationModifierButton;
                    @TranformationModifierButton.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnTranformationModifierButton;
                    @TranformationModifierButton.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnTranformationModifierButton;
                    @Interact.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnInteract;
                    @ShowControls.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnShowControls;
                    @ShowControls.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnShowControls;
                    @ShowControls.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnShowControls;
                    @OpenMenu.started -= m_Wrapper.m__1HandLActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.performed -= m_Wrapper.m__1HandLActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.canceled -= m_Wrapper.m__1HandLActionsCallbackInterface.OnOpenMenu;
                }
                m_Wrapper.m__1HandLActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @ChangeToFlight.started += instance.OnChangeToFlight;
                    @ChangeToFlight.performed += instance.OnChangeToFlight;
                    @ChangeToFlight.canceled += instance.OnChangeToFlight;
                    @ChangeToFlight1.started += instance.OnChangeToFlight1;
                    @ChangeToFlight1.performed += instance.OnChangeToFlight1;
                    @ChangeToFlight1.canceled += instance.OnChangeToFlight1;
                    @ChangeToBiped.started += instance.OnChangeToBiped;
                    @ChangeToBiped.performed += instance.OnChangeToBiped;
                    @ChangeToBiped.canceled += instance.OnChangeToBiped;
                    @ChangeToBiped1.started += instance.OnChangeToBiped1;
                    @ChangeToBiped1.performed += instance.OnChangeToBiped1;
                    @ChangeToBiped1.canceled += instance.OnChangeToBiped1;
                    @ChangeToAgile.started += instance.OnChangeToAgile;
                    @ChangeToAgile.performed += instance.OnChangeToAgile;
                    @ChangeToAgile.canceled += instance.OnChangeToAgile;
                    @ChangeToAgile1.started += instance.OnChangeToAgile1;
                    @ChangeToAgile1.performed += instance.OnChangeToAgile1;
                    @ChangeToAgile1.canceled += instance.OnChangeToAgile1;
                    @InvertYCam.started += instance.OnInvertYCam;
                    @InvertYCam.performed += instance.OnInvertYCam;
                    @InvertYCam.canceled += instance.OnInvertYCam;
                    @InvertYFlight.started += instance.OnInvertYFlight;
                    @InvertYFlight.performed += instance.OnInvertYFlight;
                    @InvertYFlight.canceled += instance.OnInvertYFlight;
                    @LessSensitivity.started += instance.OnLessSensitivity;
                    @LessSensitivity.performed += instance.OnLessSensitivity;
                    @LessSensitivity.canceled += instance.OnLessSensitivity;
                    @MoreSensitivity.started += instance.OnMoreSensitivity;
                    @MoreSensitivity.performed += instance.OnMoreSensitivity;
                    @MoreSensitivity.canceled += instance.OnMoreSensitivity;
                    @TranformationModifierButton.started += instance.OnTranformationModifierButton;
                    @TranformationModifierButton.performed += instance.OnTranformationModifierButton;
                    @TranformationModifierButton.canceled += instance.OnTranformationModifierButton;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @ShowControls.started += instance.OnShowControls;
                    @ShowControls.performed += instance.OnShowControls;
                    @ShowControls.canceled += instance.OnShowControls;
                    @OpenMenu.started += instance.OnOpenMenu;
                    @OpenMenu.performed += instance.OnOpenMenu;
                    @OpenMenu.canceled += instance.OnOpenMenu;
                }
            }
        }
        public _1HandLActions @_1HandL => new _1HandLActions(this);

        // 1HandR
        private readonly InputActionMap m__1HandR;
        private I_1HandRActions m__1HandRActionsCallbackInterface;
        private readonly InputAction m__1HandR_Move;
        private readonly InputAction m__1HandR_Look;
        private readonly InputAction m__1HandR_Fire;
        private readonly InputAction m__1HandR_Jump;
        private readonly InputAction m__1HandR_ChangeToFlight;
        private readonly InputAction m__1HandR_ChangeToFlight1;
        private readonly InputAction m__1HandR_ChangeToBiped;
        private readonly InputAction m__1HandR_ChangeToBiped1;
        private readonly InputAction m__1HandR_ChangeToAgile;
        private readonly InputAction m__1HandR_ChangeToAgile1;
        private readonly InputAction m__1HandR_InvertYCam;
        private readonly InputAction m__1HandR_InvertYFlight;
        private readonly InputAction m__1HandR_LessSensitivity;
        private readonly InputAction m__1HandR_MoreSensitivity;
        private readonly InputAction m__1HandR_TranformationModifierButton;
        private readonly InputAction m__1HandR_Interact;
        private readonly InputAction m__1HandR_ShowControls;
        private readonly InputAction m__1HandR_OpenMenu;
        public struct _1HandRActions
        {
            private @Ellisar_Input m_Wrapper;
            public _1HandRActions(@Ellisar_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m__1HandR_Move;
            public InputAction @Look => m_Wrapper.m__1HandR_Look;
            public InputAction @Fire => m_Wrapper.m__1HandR_Fire;
            public InputAction @Jump => m_Wrapper.m__1HandR_Jump;
            public InputAction @ChangeToFlight => m_Wrapper.m__1HandR_ChangeToFlight;
            public InputAction @ChangeToFlight1 => m_Wrapper.m__1HandR_ChangeToFlight1;
            public InputAction @ChangeToBiped => m_Wrapper.m__1HandR_ChangeToBiped;
            public InputAction @ChangeToBiped1 => m_Wrapper.m__1HandR_ChangeToBiped1;
            public InputAction @ChangeToAgile => m_Wrapper.m__1HandR_ChangeToAgile;
            public InputAction @ChangeToAgile1 => m_Wrapper.m__1HandR_ChangeToAgile1;
            public InputAction @InvertYCam => m_Wrapper.m__1HandR_InvertYCam;
            public InputAction @InvertYFlight => m_Wrapper.m__1HandR_InvertYFlight;
            public InputAction @LessSensitivity => m_Wrapper.m__1HandR_LessSensitivity;
            public InputAction @MoreSensitivity => m_Wrapper.m__1HandR_MoreSensitivity;
            public InputAction @TranformationModifierButton => m_Wrapper.m__1HandR_TranformationModifierButton;
            public InputAction @Interact => m_Wrapper.m__1HandR_Interact;
            public InputAction @ShowControls => m_Wrapper.m__1HandR_ShowControls;
            public InputAction @OpenMenu => m_Wrapper.m__1HandR_OpenMenu;
            public InputActionMap Get() { return m_Wrapper.m__1HandR; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(_1HandRActions set) { return set.Get(); }
            public void SetCallbacks(I_1HandRActions instance)
            {
                if (m_Wrapper.m__1HandRActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnMove;
                    @Look.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnLook;
                    @Fire.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnFire;
                    @Jump.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnJump;
                    @ChangeToFlight.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToFlight;
                    @ChangeToFlight1.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToFlight1.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToFlight1.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToFlight1;
                    @ChangeToBiped.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToBiped;
                    @ChangeToBiped1.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToBiped1.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToBiped1.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToBiped1;
                    @ChangeToAgile.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToAgile;
                    @ChangeToAgile1.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToAgile1;
                    @ChangeToAgile1.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToAgile1;
                    @ChangeToAgile1.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnChangeToAgile1;
                    @InvertYCam.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInvertYCam;
                    @InvertYCam.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInvertYCam;
                    @InvertYCam.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInvertYCam;
                    @InvertYFlight.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInvertYFlight;
                    @InvertYFlight.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInvertYFlight;
                    @InvertYFlight.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInvertYFlight;
                    @LessSensitivity.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnLessSensitivity;
                    @LessSensitivity.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnLessSensitivity;
                    @LessSensitivity.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnLessSensitivity;
                    @MoreSensitivity.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnMoreSensitivity;
                    @MoreSensitivity.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnMoreSensitivity;
                    @MoreSensitivity.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnMoreSensitivity;
                    @TranformationModifierButton.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnTranformationModifierButton;
                    @TranformationModifierButton.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnTranformationModifierButton;
                    @TranformationModifierButton.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnTranformationModifierButton;
                    @Interact.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnInteract;
                    @ShowControls.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnShowControls;
                    @ShowControls.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnShowControls;
                    @ShowControls.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnShowControls;
                    @OpenMenu.started -= m_Wrapper.m__1HandRActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.performed -= m_Wrapper.m__1HandRActionsCallbackInterface.OnOpenMenu;
                    @OpenMenu.canceled -= m_Wrapper.m__1HandRActionsCallbackInterface.OnOpenMenu;
                }
                m_Wrapper.m__1HandRActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @ChangeToFlight.started += instance.OnChangeToFlight;
                    @ChangeToFlight.performed += instance.OnChangeToFlight;
                    @ChangeToFlight.canceled += instance.OnChangeToFlight;
                    @ChangeToFlight1.started += instance.OnChangeToFlight1;
                    @ChangeToFlight1.performed += instance.OnChangeToFlight1;
                    @ChangeToFlight1.canceled += instance.OnChangeToFlight1;
                    @ChangeToBiped.started += instance.OnChangeToBiped;
                    @ChangeToBiped.performed += instance.OnChangeToBiped;
                    @ChangeToBiped.canceled += instance.OnChangeToBiped;
                    @ChangeToBiped1.started += instance.OnChangeToBiped1;
                    @ChangeToBiped1.performed += instance.OnChangeToBiped1;
                    @ChangeToBiped1.canceled += instance.OnChangeToBiped1;
                    @ChangeToAgile.started += instance.OnChangeToAgile;
                    @ChangeToAgile.performed += instance.OnChangeToAgile;
                    @ChangeToAgile.canceled += instance.OnChangeToAgile;
                    @ChangeToAgile1.started += instance.OnChangeToAgile1;
                    @ChangeToAgile1.performed += instance.OnChangeToAgile1;
                    @ChangeToAgile1.canceled += instance.OnChangeToAgile1;
                    @InvertYCam.started += instance.OnInvertYCam;
                    @InvertYCam.performed += instance.OnInvertYCam;
                    @InvertYCam.canceled += instance.OnInvertYCam;
                    @InvertYFlight.started += instance.OnInvertYFlight;
                    @InvertYFlight.performed += instance.OnInvertYFlight;
                    @InvertYFlight.canceled += instance.OnInvertYFlight;
                    @LessSensitivity.started += instance.OnLessSensitivity;
                    @LessSensitivity.performed += instance.OnLessSensitivity;
                    @LessSensitivity.canceled += instance.OnLessSensitivity;
                    @MoreSensitivity.started += instance.OnMoreSensitivity;
                    @MoreSensitivity.performed += instance.OnMoreSensitivity;
                    @MoreSensitivity.canceled += instance.OnMoreSensitivity;
                    @TranformationModifierButton.started += instance.OnTranformationModifierButton;
                    @TranformationModifierButton.performed += instance.OnTranformationModifierButton;
                    @TranformationModifierButton.canceled += instance.OnTranformationModifierButton;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @ShowControls.started += instance.OnShowControls;
                    @ShowControls.performed += instance.OnShowControls;
                    @ShowControls.canceled += instance.OnShowControls;
                    @OpenMenu.started += instance.OnOpenMenu;
                    @OpenMenu.performed += instance.OnOpenMenu;
                    @OpenMenu.canceled += instance.OnOpenMenu;
                }
            }
        }
        public _1HandRActions @_1HandR => new _1HandRActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Navigate;
        private readonly InputAction m_UI_Submit;
        private readonly InputAction m_UI_Cancel;
        private readonly InputAction m_UI_Point;
        private readonly InputAction m_UI_Click;
        private readonly InputAction m_UI_ScrollWheel;
        private readonly InputAction m_UI_MiddleClick;
        private readonly InputAction m_UI_RightClick;
        private readonly InputAction m_UI_TrackedDevicePosition;
        private readonly InputAction m_UI_TrackedDeviceOrientation;
        public struct UIActions
        {
            private @Ellisar_Input m_Wrapper;
            public UIActions(@Ellisar_Input wrapper) { m_Wrapper = wrapper; }
            public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
            public InputAction @Submit => m_Wrapper.m_UI_Submit;
            public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
            public InputAction @Point => m_Wrapper.m_UI_Point;
            public InputAction @Click => m_Wrapper.m_UI_Click;
            public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
            public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
            public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
            public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
            public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                    @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                    @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                    @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                    @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                    @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                    @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                    @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                    @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                    @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Navigate.started += instance.OnNavigate;
                    @Navigate.performed += instance.OnNavigate;
                    @Navigate.canceled += instance.OnNavigate;
                    @Submit.started += instance.OnSubmit;
                    @Submit.performed += instance.OnSubmit;
                    @Submit.canceled += instance.OnSubmit;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                    @Point.started += instance.OnPoint;
                    @Point.performed += instance.OnPoint;
                    @Point.canceled += instance.OnPoint;
                    @Click.started += instance.OnClick;
                    @Click.performed += instance.OnClick;
                    @Click.canceled += instance.OnClick;
                    @ScrollWheel.started += instance.OnScrollWheel;
                    @ScrollWheel.performed += instance.OnScrollWheel;
                    @ScrollWheel.canceled += instance.OnScrollWheel;
                    @MiddleClick.started += instance.OnMiddleClick;
                    @MiddleClick.performed += instance.OnMiddleClick;
                    @MiddleClick.canceled += instance.OnMiddleClick;
                    @RightClick.started += instance.OnRightClick;
                    @RightClick.performed += instance.OnRightClick;
                    @RightClick.canceled += instance.OnRightClick;
                    @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                    @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                    @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                    @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                    @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_TouchSchemeIndex = -1;
        public InputControlScheme TouchScheme
        {
            get
            {
                if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
                return asset.controlSchemes[m_TouchSchemeIndex];
            }
        }
        private int m_JoystickSchemeIndex = -1;
        public InputControlScheme JoystickScheme
        {
            get
            {
                if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
                return asset.controlSchemes[m_JoystickSchemeIndex];
            }
        }
        private int m_XRSchemeIndex = -1;
        public InputControlScheme XRScheme
        {
            get
            {
                if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
                return asset.controlSchemes[m_XRSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnChangeToFlight(InputAction.CallbackContext context);
            void OnChangeToFlight1(InputAction.CallbackContext context);
            void OnChangeToBiped(InputAction.CallbackContext context);
            void OnChangeToBiped1(InputAction.CallbackContext context);
            void OnChangeToAgile(InputAction.CallbackContext context);
            void OnChangeToAgile1(InputAction.CallbackContext context);
            void OnInvertYCam(InputAction.CallbackContext context);
            void OnInvertYFlight(InputAction.CallbackContext context);
            void OnLessSensitivity(InputAction.CallbackContext context);
            void OnMoreSensitivity(InputAction.CallbackContext context);
            void OnTranformationModifierButton(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnShowControls(InputAction.CallbackContext context);
            void OnOpenMenu(InputAction.CallbackContext context);
        }
        public interface I_1HandLActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnChangeToFlight(InputAction.CallbackContext context);
            void OnChangeToFlight1(InputAction.CallbackContext context);
            void OnChangeToBiped(InputAction.CallbackContext context);
            void OnChangeToBiped1(InputAction.CallbackContext context);
            void OnChangeToAgile(InputAction.CallbackContext context);
            void OnChangeToAgile1(InputAction.CallbackContext context);
            void OnInvertYCam(InputAction.CallbackContext context);
            void OnInvertYFlight(InputAction.CallbackContext context);
            void OnLessSensitivity(InputAction.CallbackContext context);
            void OnMoreSensitivity(InputAction.CallbackContext context);
            void OnTranformationModifierButton(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnShowControls(InputAction.CallbackContext context);
            void OnOpenMenu(InputAction.CallbackContext context);
        }
        public interface I_1HandRActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnLook(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnChangeToFlight(InputAction.CallbackContext context);
            void OnChangeToFlight1(InputAction.CallbackContext context);
            void OnChangeToBiped(InputAction.CallbackContext context);
            void OnChangeToBiped1(InputAction.CallbackContext context);
            void OnChangeToAgile(InputAction.CallbackContext context);
            void OnChangeToAgile1(InputAction.CallbackContext context);
            void OnInvertYCam(InputAction.CallbackContext context);
            void OnInvertYFlight(InputAction.CallbackContext context);
            void OnLessSensitivity(InputAction.CallbackContext context);
            void OnMoreSensitivity(InputAction.CallbackContext context);
            void OnTranformationModifierButton(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnShowControls(InputAction.CallbackContext context);
            void OnOpenMenu(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnNavigate(InputAction.CallbackContext context);
            void OnSubmit(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
            void OnPoint(InputAction.CallbackContext context);
            void OnClick(InputAction.CallbackContext context);
            void OnScrollWheel(InputAction.CallbackContext context);
            void OnMiddleClick(InputAction.CallbackContext context);
            void OnRightClick(InputAction.CallbackContext context);
            void OnTrackedDevicePosition(InputAction.CallbackContext context);
            void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        }
    }
}
