using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.KartSystems
{
    public class InputManager : MonoBehaviour
    {
        void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            GetComponent<KartMovement>().input = GetComponent<PhoneInput>();
#else
            GetComponent<KartMovement>().input = GetComponent<KeyboardInput>();
#endif
        }
    }
}