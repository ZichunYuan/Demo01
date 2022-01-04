using UnityEngine;
using UnityEngine.InputSystem;
using CrawfisSoftware;

namespace YuanLab3
{
    public class MovementControl : MonoBehaviour
    {
        [SerializeField] private GameObject playerToMove;
        [SerializeField] private float speed;
        private InputAction moveAction;
        private InputAction speedUpAction;
        private const float SLOW = 5;
        private const float  FAST = 10;

        public void Initialize(InputAction moveAction, InputAction speedUpAction)
        {
            this.moveAction = moveAction;
            moveAction.Enable();
            GameplayEvents.CharacterChanged += ChangePlayer;
            this.speedUpAction = speedUpAction;
            speedUpAction.Enable();
            speed = SLOW;
        }
        private void FixedUpdate()
        {
            MoveUpdate();
            SpeedUpdate();
        }

        private void MoveUpdate()
        {
            Vector2 movement = speed * Time.deltaTime * moveAction.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
            //Align Z-axis to the direction the player is facing.
            Quaternion rotationToCamera = Quaternion.LookRotation(playerToMove.transform.forward, Vector3.up);
            moveDirection = rotationToCamera * moveDirection;

            playerToMove.transform.position += moveDirection;
        }

        private void SpeedUpdate()
        {
            //Change player's movement speed by pressing shift button
            speedUpAction.performed += SpeedUpAction_performed;
            speedUpAction.canceled += SpeedUpAction_cancelled;
        }
        private void SpeedUpAction_performed(InputAction.CallbackContext obj)
        {
            this.speed = FAST;
        }
        private void SpeedUpAction_cancelled(InputAction.CallbackContext obj)
        {
            this.speed = SLOW;
        }

        public void ChangePlayer(GameObject playerToMove)
        {
            this.playerToMove = playerToMove;
        }
    }
}