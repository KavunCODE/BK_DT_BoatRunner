using System;
using UnityEngine;

/// <summary>
/// Класс обработки кликов
/// </summary>
namespace AwesomeTools
{
    public class MouseTrigger : MonoBehaviour
    {
        public event Action OnDrag;
        public event Action OnDown;
        public event Action OnUp;
        /// <summary>
        /// Событие на удерживании левой кнопки мыши
        /// </summary>
        private void OnMouseDrag()
            => OnDrag?.Invoke();
        /// <summary>
        /// Событие на нажатие левой кнопки мыши
        /// </summary>
        private void OnMouseDown()
            => OnDown?.Invoke();
        /// <summary>
        /// Событие на отпускание левой кнопки мыши
        /// </summary>
        private void OnMouseUp()
            => OnUp?.Invoke();
    }
}
