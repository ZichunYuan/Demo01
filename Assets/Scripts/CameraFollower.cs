using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CrawfisSoftware;


    public class CameraFollower : MonoBehaviour
    {
       // [SerializeField] ControlStyle controlStyle;
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed;

        private const float MOUSE_SENSITIVITY = 0.3f;
        private const float ROTATION_SPEED = 10f;
        private const float ROTATION_LIMIT = 90f;
        float xRotation = 0f;
        float yRotation = 0f;
        float step;

        bool canSetOffeset = false;
        private InputAction mouseRotateAction;
        private InputAction joyStickRotateAction;

        public void Initialize(InputAction mouseRotateAction, InputAction joyStickRotateAction)
        {
            this.mouseRotateAction = mouseRotateAction;
            mouseRotateAction.Enable();

            this.joyStickRotateAction = joyStickRotateAction;
            joyStickRotateAction.Enable();

            GameplayEvents.CharacterChanged += GameplayEvents_CharacterChanged;
            //get the height and width of the player
            float height = this.target.GetComponent<Collider>().bounds.size.y;
            float width = this.target.GetComponent<Collider>().bounds.size.z;
            offset = new Vector3(0f, height , 0f);
            //rotation speed setup.
            step = speed * Time.deltaTime;

        }

        private void GameplayEvents_CharacterChanged(GameObject player)
        {
            this.target = player.transform;
        }

        private void MouseFollower()
        {
            if (canSetOffeset)
            {
                //Read Mouse Position
                Vector2 mousePosition = mouseRotateAction.ReadValue<Vector2>();
                //Rotate to Follow Mouse.
                yRotation = (mousePosition.y - Screen.height/2) * MOUSE_SENSITIVITY;
                xRotation = (mousePosition.x - Screen.width/2) * MOUSE_SENSITIVITY;
                yRotation = Mathf.Clamp(yRotation, -ROTATION_LIMIT, ROTATION_LIMIT); //limit the y-rotation to 90 degree.
            }
        }

        private void JoyStickFollower()
        {
            //Read JoyStick Position
            Vector2 joystickPosition = joyStickRotateAction.ReadValue<Vector2>();
            //Rotate to Follow Joystick.
            yRotation += joystickPosition.y;
            xRotation += joystickPosition.x;
            yRotation = Mathf.Clamp(yRotation, -ROTATION_LIMIT, ROTATION_LIMIT); //limit the y-rotation to 90 degree.
        }

        private void SetMouseValue(InputAction.CallbackContext obj)
        {
            //Allow to set the offset of screen size
            //To avoid the sudden change of view of first-person camera at the start of the game. 
            canSetOffeset = true;
        }

        private void MovementFollower()
        {
            this.transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.position + offset, ROTATION_SPEED);
        }

        private void Update()
        {
            mouseRotateAction.performed += SetMouseValue;
            MovementFollower();
           // if (controlStyle == ControlStyle.PC) 
                MouseFollower();
           // else JoyStickFollower();
            Quaternion xQuat = Quaternion.AngleAxis(xRotation, Vector3.up);
            Quaternion yQuat = Quaternion.AngleAxis(yRotation, Vector3.left);
            Quaternion toRotation = xQuat *yQuat;
            //Rotate the Camera Vertically
            this.transform.localRotation = Quaternion.RotateTowards(this.transform.localRotation, toRotation, step);
            //Rotate the Player Horizontally
            target.localRotation = Quaternion.RotateTowards(this.target.localRotation, xQuat, step);
        }
    }
