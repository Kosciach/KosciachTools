using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace KosciachTools.CharacterControllerExtentions
{
    public class CharacterControllerGroundCheck : MonoBehaviour
    {
        [Header("====Settings====")]
        [SerializeField] Transform _origin;
        [SerializeField] LayerMask _walkableLayers;
        [Range(0.1f, 2)]
        [SerializeField] float _range;
        [Range(0.1f, 2)]
        [SerializeField] float _radius;
        [Range(3, 10)]
        [SerializeField] int _rayCount;


        [Space(20)]
        [Header("====Debugs====")]
        [SerializeField] bool _isGrounded; public bool IsGrounded { get { return _isGrounded; } }
        [SerializeField] List<bool> _groundChecks = new List<bool>();




        private void Update()
        {
            CheckGround();
        }


        private void CheckGround()
        {
            if (_origin == null) return;

            _groundChecks.Clear();
            _groundChecks.Add(Physics.Raycast(_origin.position, Vector3.down, _range, _walkableLayers));
            Debug.DrawRay(_origin.position, Vector3.down * _range, Color.red);

            for(int i=0; i< _rayCount; i++)
            {
                float angle = i * 360 / _rayCount;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
                Vector3 origin = _origin.position + direction * _radius;

                _groundChecks.Add(Physics.Raycast(origin, Vector3.down, _range, _walkableLayers));
                Debug.DrawRay(origin, Vector3.down * _range, Color.red);
            }

            _isGrounded = _groundChecks.Contains(true);
        }
    }
}