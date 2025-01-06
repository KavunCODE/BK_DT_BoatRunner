using System;
using UnityEngine;
using AwesomeTools.DefinesConstant;

namespace AwesomeTools.Inputs
{
    /// <summary>
    /// Система управления
    /// </summary>
    public class InputSystem : MonoBehaviour, IInputSystem
    {
        public event Action<Vector3> OnTapped;

        private Camera _camera;
        /// <summary>
        /// Получает главную камеру
        /// </summary>
        private void Awake()
        {
            _camera = Camera.main;
        }
        /// <summary>
        /// Проверяет событие на нажатие
        /// </summary>
        private void Update()
        {
            if (Tapped())
            {
                OnTapped?.Invoke(CalculateTouchPosition());
            }
        }
        /// <summary>
        /// подсчитывает позицию нажатия на телефоне
        /// </summary>
        /// <returns>возвращает позицию нажатия</returns>
        public Vector2 CalculateTouchPosition()
        {
            Vector2 tapPosition = new Vector3();

            if (ConstantsPlatform.UNITY_EDITOR)
            {
                if (_camera != null)
                {
                    tapPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
                    return tapPosition;
                }
                return tapPosition;
            }

            if (ConstantsPlatform.ANDROID || ConstantsPlatform.IOS)
            {
                tapPosition = CalculateFingerTouchPosition();
                return tapPosition;
            }

            return tapPosition;
        }
        /// <summary>
        /// Если нажал пальцем или левой кнопкой мыши
        /// </summary>
        /// <returns></returns>
        private bool Tapped()
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Подсчёт положения пальца
        /// </summary>
        /// <returns>возвращает положение нажатия</returns>
        private Vector2 CalculateFingerTouchPosition()
        {
            var touch = Input.GetTouch(0);
            var touchPosition = _camera.ScreenToWorldPoint(touch.position);
            return touchPosition;
        }
    }
}