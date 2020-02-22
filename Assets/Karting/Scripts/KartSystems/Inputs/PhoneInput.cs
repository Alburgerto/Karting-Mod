using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    public class PhoneInput : MonoBehaviour, IInput
    {
        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        public float Acceleration {
            get { return m_Acceleration; }
        }
        public float Steering {
            get { return m_Steering; }
        }
        public bool BoostPressed {
            get { return m_BoostPressed; }
        }
        public bool FirePressed {
            get { return m_FirePressed; }
        }
        public bool HopPressed {
            get { return m_HopPressed; }
        }
        public bool HopHeld {
            get { return m_HopHeld; }
        }

        bool m_FixedUpdateHappened;
        private float m_halfScreenWidth;

        private void Start()
        {
            m_halfScreenWidth = Screen.width / 2; // Only allowing landscape right/left, screen resolution is always the same
        }

        void Update()
        {
            m_Steering = 0;
            m_Acceleration = 1f;
            
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float distance = Mathf.Abs(m_halfScreenWidth - touch.position.x);
                if (touch.position.x < m_halfScreenWidth)
                {
                    m_Steering = -1 * distance / m_halfScreenWidth;
                }
                else
                {
                    m_Steering = 1 * distance / m_halfScreenWidth;
                }
            }
            if (Input.touchCount > 1)
            {
                m_HopHeld = true;
                
            }

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= Input.GetKeyDown(KeyCode.Space);
            m_BoostPressed |= Input.GetKeyDown(KeyCode.RightShift);
            m_FirePressed |= Input.GetKeyDown(KeyCode.RightControl);
        }

        void FixedUpdate()
        {
            m_FixedUpdateHappened = true;
        }
    }

}
