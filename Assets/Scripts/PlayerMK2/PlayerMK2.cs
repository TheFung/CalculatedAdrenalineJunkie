using System;
using System.Collections.Generic;
using System.Data;
using NUnit.Framework;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerMK2
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMK2 : MonoBehaviour
    {
        private placeExplosive _placeExplosive;
        private CharacterController _controller = null;
        private PlayerMoveInput _playerMovement;
        private Vector3 startPos;
        private float _rotationDirection;
        private bool _movingForward;
        public bool _moving;
        private float _timer;
        private int rotation = 0;
        private float startRot;
        private float rotationCurve;
        public Vector3 lastPos;
        [SerializeField] private List<float> rotationValueX;
        [SerializeField] private List<float> rotationValueZ;
        [SerializeField] private AnimationCurve _movementAnimationY;
        [SerializeField] private AnimationCurve _movementAnimationXZ;
        [SerializeField] private AnimationCurve _rotationAnim;
        [SerializeField] private float speedModifier;
        private RaycastHit hit;
        private bool somethingInfront;
        private knockBack _knockBack;
        public Vector3 eularAgnleBeforeLookAt;
        private void Start()
        {
            _placeExplosive = GetComponent<placeExplosive>();
            _controller = GetComponent<CharacterController>();
            _knockBack = GetComponent<knockBack>();
        }
        private void Update()
        {
            Physics.Raycast(transform.position, transform.forward, out hit, 0.5f);
            somethingInfront = hit.collider != null;
            
            if (_movingForward) moveForward();
            if (_rotationDirection != 0) rotate();
            
            _timer += Time.deltaTime * speedModifier;
            if (_knockBack.blastingAway) _timer = 0;
            _moving = _timer <= 1f;
            if (!_moving)
            {
                _rotationDirection = 0f;
                transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
                transform.eulerAngles = new Vector3(0, Mathf.Round(transform.eulerAngles.y), 0);
            }
        }
        private void OnMoveForward()
        {
            if (!_moving && !somethingInfront)
            {
                eularAgnleBeforeLookAt = transform.eulerAngles;
                _placeExplosive.PlaceWhenMove();
                startPos = transform.position;
                _movingForward = true;
                _timer = 0f;
            }
        }
        private void moveForward()
        {
            var moveCurve = new Vector3(_movementAnimationXZ.Evaluate(_timer) * rotationValueX[rotation],
                _movementAnimationY.Evaluate(_timer), _movementAnimationXZ.Evaluate(_timer) * rotationValueZ[rotation]);
            transform.position = startPos + moveCurve;
            if (_timer >= 1f) _movingForward = false;
        }
        private void OnTurnRight()
        {
            if (!_moving)
            {
                if (rotation == 3) rotation = 0;
                else rotation++;
                _timer = 0f;
                _rotationDirection = 1f;
                startRot = transform.eulerAngles.y;
                startPos = transform.position;
            }
        }
        private void OnTurnLeft()
        {
            if (!_moving)
            {
                if (rotation == 0) rotation = 3;
                else rotation--;
                _timer = 0f;
                _rotationDirection = -1f;
                startRot = transform.eulerAngles.y;   
                startPos = transform.position;
            }
        }
        private void rotate()
        {
            rotationCurve = _rotationAnim.Evaluate(_timer) * _rotationDirection;
            transform.eulerAngles = new Vector3(0,rotationCurve + startRot, 0);
            var jumpCurve = new Vector3(0, _movementAnimationY.Evaluate(_timer), 0);
            transform.position = startPos + jumpCurve;
        }
    }
}