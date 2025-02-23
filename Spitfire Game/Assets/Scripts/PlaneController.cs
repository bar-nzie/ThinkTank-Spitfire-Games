using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Sean
{
    public class planeMovement : MonoBehaviour
    {

        [SerializeField] private InputActionReference left, right, shoot;
        [SerializeField] private float speed;

        private bool _moveLeft;
        private bool _moveRight;
        private bool _moveUp;
        private bool _moveDown;
        private bool _isShooting;

        public GameObject point1;
        public GameObject point2;
        public GameObject point3;

        private void Start()
        {
/*          input.MovementLeftEvent += HandleMoveLeft;
            input.MovementLeftEvent += HandleCancelledMoveLeft;

            input.MovementRightEvent += HandleMoveRight;
            input.MovementRightEvent += HandleCancelledMoveRight;

            input.MovementUpEvent += HandleMoveUp;
            input.MovementUpEvent += HandleCancelledMoveUp;

            input.MovementDownEvent += HandleMoveDown;
            input.MovementDownEvent += HandleCancelledMoveDown;

            input.ShootEvent += HandleShoot;
            input.ShootEvent += HandleCancelledShoot;*/
        }

        // Update is called once per frame
        private void Update()
        {
            Move();
            Shoot();
        }

        private void HandleMoveLeft()
        {
            _moveLeft = true;
        }

        private void HandleCancelledMoveLeft()
        {
            _moveLeft = false;
        }

        private void HandleMoveRight()
        {
            _moveRight = true;
        }

        private void HandleCancelledMoveRight()
        {
            _moveRight = false;
        }

        private void HandleMoveUp()
        {
            _moveUp = true;
        }

        private void HandleCancelledMoveUp()
        {
            _moveUp = false;
        }

        private void HandleMoveDown()
        {
            _moveDown = true;
        }

        private void HandleCancelledMoveDown()
        {
            _moveDown = false;
        }

        private void HandleShoot()
        {
            _isShooting = true;
        }

        private void HandleCancelledShoot()
        {
            _isShooting = false;
        }

        private void Move()
        {
            // if (_moveLeft)
            //{
               // transform.position += Vector3.MoveTowards(transform.position, point3.transform.position, (speed * Time.deltaTime));
            //}
            if (left.action.inProgress)
            {
                Debug.Log("left");
                transform.position = Vector3.Lerp(transform.position, point1.transform.position, (speed * Time.fixedDeltaTime));
            }
            /*if (right.action.triggered)
            {
                Debug.Log("right");
                transform.position = Vector3.Lerp(transform.position, point3.transform.position, (speed * Time.deltaTime));
            }*/
            if (right.action.inProgress)
            {
                Debug.Log("right");
                transform.position = Vector3.Lerp(transform.position, point3.transform.position, (speed * Time.fixedDeltaTime));
            }


        }

        private void Shoot()
        {
            if (shoot.action.triggered)
            {
                Debug.Log("shoot");
            }
        }
    }
}
