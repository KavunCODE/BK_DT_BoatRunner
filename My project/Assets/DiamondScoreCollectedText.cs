using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DiamondScoreCollectedText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        
        // Move the object upwards
        sequence.Append(transform.DOMoveY(transform.position.y + 1f, 1f));
        
        // Fade out the object simultaneously
        sequence.Join(transform.DOScale(Vector3.zero, 1.5f));
        
        // Destroy the object when the animation is complete
        sequence.OnComplete(() => Destroy(gameObject));
    }
}
