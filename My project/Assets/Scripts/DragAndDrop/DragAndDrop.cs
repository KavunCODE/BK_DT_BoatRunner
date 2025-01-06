using AwesomeTools.Inputs;
using System;
using System.Collections;
using UnityEngine;

namespace AwesomeTools
{
    /// <summary>
    /// Класс, який забеспечує перетягування об'єктів
    /// </summary>
    public class DragAndDrop : MonoBehaviour
    {
        private const int DESTROY_TIME = 3;
        // public bool sDraggable; // Визначає чи можна перетягувати об'єкт
        public event Action OnDragEnded; // "OnDragEnded" Викликається коли гравець закінчив перетягувати об'єкт
        public event Action OnDragStart; // "OnDragStart" Викликається коли гравець починає перетягувати об'єкт
        public event Action OnDrag; // "OnDrag" Викликається під час перетягування

        [SerializeField] private MouseTrigger _mouseTrigger;
        private InputSystem _inputSystem;
        private Vector2 _clampedYPosition;
        public bool IsDragging; // Визначає, чи перетягується об'єкт на данний момент.
        public bool IsDraggable;// Визначає чи можна перетягувати об'єкт
        public Vector2 offset;
        /// <summary>
        /// Вводимо систему вводу [inputSystem] та позицію "y" взяття [clampedYPosition] -
        /// присвоюємо у відповідні поля параметри
        /// </summary>
        public void Construct(InputSystem inputSystem, Vector2 clampedYPosition = default(Vector2))
        {        
            _inputSystem = inputSystem;
            _clampedYPosition = clampedYPosition;
        }

        /// <summary>
        /// Присвоюємо ф-ції подіям 
        /// </summary>
        private void Awake()
        {
            _mouseTrigger.OnDrag += CalculateDrag;
            _mouseTrigger.OnDrag += Draging;
            _mouseTrigger.OnDown += DragStart;
            _mouseTrigger.OnUp += DragEnd;
        }

        /// <summary>
        /// Видаляємо ф-ції з подій
        /// </summary>
        private void OnDestroy()
        {
            _mouseTrigger.OnDrag -= CalculateDrag;
            _mouseTrigger.OnDrag -= Draging;
            _mouseTrigger.OnDown -= DragStart;
            _mouseTrigger.OnUp -= DragEnd;

            StopCoroutine(DestroyInTime());
        }

        /// <summary>
        /// Рахує позицію елементу під час перетягування
        /// </summary>
        private void CalculateDrag()
        {
            if (!IsDraggable|| !IsDragging) return;
            Vector3 newPosition = _inputSystem.CalculateTouchPosition() + offset;
            if (_clampedYPosition != default(Vector2))
            {
                newPosition.y = Mathf.Clamp(newPosition.y, _clampedYPosition.x, _clampedYPosition.y);
            }

            transform.position = newPosition;

        }

        /// <summary>
        /// Викликається подія "OnDragEnded"
        /// </summary>
        private void DragEnd()
        {
            
            if (!IsDraggable) return;
            if (IsDragging == false)
                IsDraggable = true;
            else
            {
                IsDragging = false;
                OnDragEnded?.Invoke();
            }
        }

        /// <summary>
        /// Викликається подія "OnDragStart"
        /// </summary>
        private void DragStart()
        {
            if (!IsDraggable) return;
            IsDragging = true;
            OnDragStart?.Invoke();
        }

        /// <summary>
        /// Викликається подія "OnDrag"
        /// </summary>
        private void Draging()
        {
            if (!IsDraggable) return;
            OnDrag?.Invoke(); 
        }

        /// <summary>
        /// Змушує об'єкт падати та запускає Coroutine "DestroyInTime"
        /// </summary>
        public void DestroyGameObject()
        {
            AddFallingForGameObject();
            StartCoroutine(DestroyInTime());
        }

        /// <summary>
        /// Додає падіння до об'єкту
        /// </summary>
        private void AddFallingForGameObject()
        {
            Rigidbody2D rigidbody2D = transform.GetComponent<Rigidbody2D>();
            if (rigidbody2D == null)
            {
                gameObject.AddComponent<Rigidbody2D>();
            }
            else
            {
                rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            }
        }

        /// <summary>
        /// Знищує об'єкт через "DESTROY_TIME" секунд
        /// </summary>
        private IEnumerator DestroyInTime()
        {
            yield return new WaitForSeconds(DESTROY_TIME);
            Destroy(gameObject);
        }
    }
}
