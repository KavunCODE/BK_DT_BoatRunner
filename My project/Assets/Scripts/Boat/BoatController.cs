/*using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class BoatController : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float forwardSpeed = 3.5f;

    void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 curScreenPoint = new Vector3(touch.position.x, touch.position.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

            // Freeze Y and Z movement
            curPosition.y = transform.position.y;
            curPosition.z = transform.position.z;

            transform.position = curPosition;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}*/

/// <summary>
/// Code for PC Inputs.
/// </summary>
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class BoatController : MonoBehaviour 
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float forwardSpeed = 3.5f;
    private bool isStopped;
    [SerializeField] private GunHead gunHead;

    void OnMouseDown()
    {
        if(isStopped)
        {
            return;
        }

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        
        // Freeze Y and Z movement
        curPosition.y = transform.position.y;
        curPosition.z = transform.position.z;
        
        transform.position = curPosition;
    }

    void FixedUpdate()
    {
        if(isStopped)
        {
            return;
        }

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    public void ChangeIsStopped(bool _isStopped)
    {
        isStopped = _isStopped;
    }

    public void SetShooting(bool _shooting)
    {
        gunHead.SetShooting(_shooting);
    }
}