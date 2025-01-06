using UnityEngine;

namespace UI
{
    public class Hud : MonoBehaviour
    {
        [SerializeField] private ExitButton _exitButton;

        private void Awake()
            => Appear();

        private void Appear()
        {
            _exitButton.Appear();
        }

        public virtual void Disappear()
        {
            _exitButton.Disappear();
        }
    }
}