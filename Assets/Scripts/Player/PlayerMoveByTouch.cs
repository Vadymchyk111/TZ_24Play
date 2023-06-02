using UnityEngine;

namespace Player
{
    public class PlayerMoveByTouch : MonoBehaviour
    { 
        [SerializeField] private float _speed;
        [SerializeField] private float _dragSpeed;
        [SerializeField] private float _maxXPosition;

        private bool _isDragging;
        private float _dragStartPositionX;

        private void Update()
        {
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
            
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _dragStartPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
            }

            if (!_isDragging)
            {
                return;
            }
            
            float dragDelta = (Input.mousePosition.x - _dragStartPositionX) * _dragSpeed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(dragDelta, 0, 0);
            newPosition.x = Mathf.Clamp(newPosition.x, -_maxXPosition, _maxXPosition);
            transform.position = newPosition;
        }
    }
}