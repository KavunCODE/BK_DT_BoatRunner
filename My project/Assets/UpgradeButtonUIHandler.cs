using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UpgradeButtonUIHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private BoatCharacteristics boatCharacteristics;
    private float upgradeStep = 0.03f; // 3%

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(transform.localScale.x - 0.3f, transform.localScale.y - 0.3f, transform.localScale.z - 0.3f), 0.2f);
        
        // Access and update the shootDelay variable from BoatCharacteristics
        boatCharacteristics.shootDelay -= boatCharacteristics.shootDelay * upgradeStep;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
    }
}
