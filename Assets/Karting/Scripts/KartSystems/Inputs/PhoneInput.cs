using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    public class PhoneInput : MonoBehaviour, IInput
    {
        public float m_Acceleration = 0.75f;
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
        private int m_firstTouchId;

        private void Start()
        {
            m_halfScreenWidth = Screen.width / 2; // Only allowing landscape right/left, screen resolution is always the same
        }

        void Update()
        {
            m_Steering = 0;

            Touch touch;
            for (int i = 0; i < Input.touchCount; ++i)
            {
                touch = Input.GetTouch(i);
                if (Input.touchCount == 1 && m_firstTouchId != touch.fingerId)
                {
                    m_firstTouchId = touch.fingerId;
                }

                if (touch.fingerId == m_firstTouchId && (touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended))
                {
                    m_firstTouchId = -1;
                }

                if (touch.fingerId == m_firstTouchId)
                {
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
            }

            m_HopHeld = Input.touchCount > 1;

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            if (Input.touchCount > 1)
            {
                for (int i = 0; i < Input.touchCount; ++i)
                {
                    touch = Input.GetTouch(i);
                    m_HopPressed |= touch.fingerId != m_firstTouchId && touch.phase == TouchPhase.Began;
                }
            }
            
            m_BoostPressed |= Input.GetKeyDown(KeyCode.RightShift);
            m_FirePressed  |= Input.GetKeyDown(KeyCode.RightControl);
        }

        void FixedUpdate()
        {
            m_FixedUpdateHappened = true;
        }
    }

}
