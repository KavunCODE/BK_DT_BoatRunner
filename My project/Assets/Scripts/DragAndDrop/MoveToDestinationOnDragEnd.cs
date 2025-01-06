using DG.Tweening;
using System;
using UnityEngine;

/// <summary>
/// Перемещение на новое место позиции при окончании захвата
/// </summary>

namespace AwesomeTools
{
    public class MoveToDestinationOnDragEnd : MonoBehaviour
    {
        public Action OnMoveComplete;
        [SerializeField] private DragAndDrop _dragAndDrop;
        [SerializeField] private float _duration = 0.5f;
        private Vector3 _destination;
        private Tween _movingToDestination;

        public float Duration => _duration;
        public Tween MovingTween => _movingToDestination;

        /// <summary>
        /// Конструктов получения местоположения и подписка на окончание перемещения
        /// </summary>
        /// <param name="destination"></param>
        public void Construct(Vector3 destination)
        {
            _destination = destination;
            _dragAndDrop.OnDragEnded += MoveToDestination;
        }
        /// <summary>
        /// При уничтожении объекта отписка от события окончание перемещения
        /// </summary>
        private void OnDestroy() 
            => _dragAndDrop.OnDragEnded -= MoveToDestination;
        /// <summary>
        /// Перемещение на другое местоположение при помощи метода DoMove
        /// </summary>
        public void MoveToDestination()
        {
            _dragAndDrop.IsDraggable = false;
            _movingToDestination =  transform.DOMove(_destination, Duration)
                .OnComplete(() => {
                    OnMoveComplete?.Invoke();    
                    _dragAndDrop.IsDraggable = true;
                });
        }
    }   
}