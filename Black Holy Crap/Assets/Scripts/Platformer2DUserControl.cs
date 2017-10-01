using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {

        private bool SideControlsEnabled = true;
        private bool JetPackEnabled = true;
        public MovementDirection currentDirection = MovementDirection.Right;
        float scrollDirection = 0;
        public float RocketForceGoingUp = 10;
        private Rigidbody2D _rigidBody;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool crouch = false;


        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            switch (currentDirection)
            {
                case MovementDirection.Up:
                    SideControlsEnabled = true;
                    JetPackEnabled = true;
                    break;
                case MovementDirection.Down:
                    SideControlsEnabled = true;
                    JetPackEnabled = true;
                    break;
                case MovementDirection.Left:
                    SideControlsEnabled = false;
                    JetPackEnabled = true;
                    scrollDirection = -1;
                    break;
                case MovementDirection.Right:
                    SideControlsEnabled = false;
                    JetPackEnabled = true;
                    scrollDirection = 1;
                    break;
            }
        }


        private void Update()
        {
            //if (JetPackEnabled)
            //{
            //    // Read the jump input in Update so button presses aren't missed.
            // //   m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            //}
            if (CrossPlatformInputManager.GetButtonDown("Fire1") || CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Vector2 currentsize = GetComponent<BoxCollider2D>().size;
                GetComponent<BoxCollider2D>().size = new Vector2(currentsize.x / 2, currentsize.y / 2);
                crouch = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("Fire1") || CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                Vector2 currentsize = GetComponent<BoxCollider2D>().size;
                GetComponent<BoxCollider2D>().size = new Vector2(currentsize.x * 2, currentsize.y * 2);
                crouch = false;
            }
        }

        private void FixedUpdate()
        {

            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.LeftControl);
            if (SideControlsEnabled)
            {
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                if (crouch)
                {
                    h /= 5;
                }
                m_Character.Move(h, 0, crouch, m_Jump);

                //Add contant force if we're going up
                if (currentDirection == MovementDirection.Up)
                {
                    _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, RocketForceGoingUp + Score.diffinc);
                }
                else if (currentDirection == MovementDirection.Down)
                {
                    _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, -RocketForceGoingUp - Score.diffinc);

                }
            }
            else
            {
                float v = CrossPlatformInputManager.GetAxis("Vertical");

                if (crouch)
                {
                    v /= 5;
                }

                //Left and Right Movement
                if (currentDirection == MovementDirection.Right)
                {
                    m_Character.Move(scrollDirection + (Score.diffinc * 0.1F), v, crouch, m_Jump);
                }else
                {
                    m_Character.Move(scrollDirection - (Score.diffinc * 0.1F), v, crouch, m_Jump);

                }
            }
            m_Jump = false;
        }
    }

    public enum MovementDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
