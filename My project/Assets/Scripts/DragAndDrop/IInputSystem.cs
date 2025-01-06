using System;
using UnityEngine;

namespace AwesomeTools.Inputs
{
    /// <summary>
    /// Интерфейс, что отвечает за событие с нажатием и методом подсчёта позиции
    /// </summary>
    public interface IInputSystem
    {
        event Action<Vector3> OnTapped;
        Vector2 CalculateTouchPosition();
    }
}