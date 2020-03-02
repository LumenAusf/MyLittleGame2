using System;
using UnityEngine;

namespace OtherNow
{
    public class PlayerCubeController : MonoBehaviour
    {
        public Action MoveNext = delegate { };
        public Action Finish = delegate { };
        public Action Failure = delegate { };

        private CircleController circle;
        private float magicPos;
        private float speed;
        private bool isMove;
        private bool canMoveNext;
        private bool canFinish;

        private Vector3 CameraOriginalPos;

        private void Awake()
        {
            CameraOriginalPos = Camera.main.transform.position;
        }

        public void SetMove(bool isMove)
        {
            this.isMove = isMove;
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }

        public void Clear()
        {
            canMoveNext = false;
            canFinish = false;
            isMove = false;
            circle = null;
        }

        public void SetCircle(CircleController circle)
        {
            this.circle = circle;
            var locY = circle.y + transform.localScale.y / 2f;
            magicPos = 0.75f;
            var x = Mathf.Cos(magicPos * 2 * Mathf.PI) * circle.MoveRadius;
            var z = Mathf.Sin(magicPos * 2 * Mathf.PI) * circle.MoveRadius + circle.transform.position.z;
            var newPos = new Vector3(x, locY, z);
            transform.localPosition = newPos;
            Camera.main.transform.position = CameraOriginalPos + Vector3.forward * circle.transform.position.z;
            canMoveNext = false;
            canFinish = false;
        }

        private void Update()
        {
            if (!Input.GetMouseButton(0))
            {
                if (canMoveNext)
                {
                    canMoveNext = false;
                    MoveNext.Invoke();
                }

                if (canFinish)
                {
                    canFinish = false;
                    Finish.Invoke();
                }
                return;
            }
            if (!isMove) return;
            if (circle == null) return;

            if (circle.IsLeftMove)
            {
                magicPos += Time.deltaTime * speed;
                if (magicPos > 1) magicPos = 0;
            }
            else
            {
                magicPos -= Time.deltaTime * speed;
                if (magicPos < 0) magicPos = 1;
            }

            var x = Mathf.Cos(magicPos * 2 * Mathf.PI) * circle.MoveRadius;
            var z = Mathf.Sin(magicPos * 2 * Mathf.PI) * circle.MoveRadius + circle.transform.position.z;
            var newPos = new Vector3(x, transform.localPosition.y, z);

            transform.rotation = Quaternion.LookRotation(newPos - transform.position);
            transform.localPosition = newPos;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                Failure.Invoke();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("Mover"))
            {
                canMoveNext = true;
            }
            
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                canFinish = true;
            }
        }

        
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Mover"))
            {
                canMoveNext = false;
            }
            
            if (other.gameObject.layer == LayerMask.NameToLayer("Finish"))
            {
                canFinish = false;
            }
        }
    }
}