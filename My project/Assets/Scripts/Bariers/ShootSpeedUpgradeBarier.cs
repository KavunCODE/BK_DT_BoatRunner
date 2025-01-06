using UnityEngine;
using TMPro;

/// <summary>
/// Updates UpgradeBariers Text int part value every time any bullet hits the barier.
/// </summary>

public class ShootSpeedUpgradeBarier : MonoBehaviour
{
    [SerializeField] private BoatCharacteristics boatCharacteristics;
    protected TextMeshPro textMeshPro;
    protected string upgradeString;
    protected float value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            UpdateText(); // Call the method on the ShootSpeedUpgradeBarierManager
        }
    }

    public void UpdateText()
    {
        GetCurrentText();   
        IncreaseUpgradeValue();
    }

    private void GetCurrentText()
    {
        textMeshPro = GetComponent<TextMeshPro>();

        if (textMeshPro != null)
        {
            upgradeString = textMeshPro.text;
        }
        else
        {
            Debug.LogError("TextMeshPro reference is not set!");
        }
    }

    private void IncreaseUpgradeValue()
    {
        value = GetUpgradeValue();
        value++;
        SetUpgradeValue();
    }

    /// <summary>
    /// Gets int part of the barier's text value
    /// </summary>

    private int GetUpgradeValue()
    {
        string upgradeValue = "";

        for (int i = 0; i < upgradeString.Length; i++)
        {
            if (char.IsDigit(upgradeString[i]))
            {
                upgradeValue += upgradeString[i];
            }
        }

        int parsedValue;
        if (int.TryParse(upgradeValue, out parsedValue))
        {
            return parsedValue;
        }
        else
        {
            Debug.LogError("Failed to parse numeric part of the string: " + upgradeValue);
            return 0; // Return 0 if parsing fails
        }
    }

    protected virtual void SetUpgradeValue()
    {
        textMeshPro.text = $"+{value}%";
    }

    public void IncreaseBoatShootSpeed()
    {
        boatCharacteristics.ShootDelay -= boatCharacteristics.ShootDelay*(this.value/100);
    }
}
