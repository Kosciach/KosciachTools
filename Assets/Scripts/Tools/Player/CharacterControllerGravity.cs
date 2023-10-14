using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KosciachTools.CharacterControllerExtentions
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(CharacterControllerGroundCheck))]
    public class CharacterControllerGravity : MonoBehaviour
    {
        [Header("====Settings====")]
        [SerializeField] float _gravityForce;
        [SerializeField] bool _gravityToggle;


        [Space(20)]
        [Header("====Debugs====")]
        [SerializeField] float _currentGravityForce;


        private CharacterController _characterController;
        private CharacterControllerGroundCheck _characterControllerGroundCheck;




        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterControllerGroundCheck = GetComponent<CharacterControllerGroundCheck>();
        }
        private void Update()
        {
            CalculateCurrentGravity();
            ApplyGravity();
        }


        private void CalculateCurrentGravity()
        {
            if (_characterController == null || _characterControllerGroundCheck == null) return;

            if (_characterControllerGroundCheck.IsGrounded)
            {
                _currentGravityForce = -0.2f;
                return;
            }

            _currentGravityForce -= _gravityForce * Time.deltaTime;
            _currentGravityForce *= _gravityToggle ? 1 : 0;
        }
        private void ApplyGravity()
        {
            Vector3 gravityVector = _characterController.velocity;
            gravityVector.y = _currentGravityForce;

            _characterController.Move(gravityVector * Time.deltaTime);
        }
    }
}