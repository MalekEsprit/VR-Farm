using System;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

[RequireComponent(typeof (VehicleController))]
public class VehicleUserControl : MonoBehaviour
    {
        public XRKnob wheel;
        public XRJoystick joystick;
        private VehicleController m_Car;

   

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<VehicleController>();
        }


        private void FixedUpdate()
        {
        // pass the input to the car!
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        float h = Mathf.Lerp(-1, 1, wheel.value);

        float v = joystick.value.y;

#if !MOBILE_INPUT
        float handbrake = Input.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
            
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }

