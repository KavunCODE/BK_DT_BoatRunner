using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class ExitButton : HudElement
    {

        // Starts the panel animation by making it appear, and try to find "AdsInterstitial"
        private void Start()
        {
            Appear();
        }

        private void EndCycle()
        {
            Disappear();
        }
    }
}