using UnityEngine;
using TMPro;

public class NameHolder : MonoBehaviour
{
    public TMP_Text nameText; // Use TMP_Text instead of Text
    public TMP_InputField inputField; // Use TMP_InputField instead of InputField
    public BoatCharacteristics boatCharacteristics; // Reference to your ScriptableObject

    private void Start()
    {
        // Add a listener to the input field's onEndEdit event
        inputField.onEndEdit.AddListener(OnEndEdit);
    }

    // Event handler for the input field's onEndEdit event
    private void OnEndEdit(string input)
    {
        // Update the playerName field in the BoatCharacteristics ScriptableObject
        boatCharacteristics.playerName = input;
        // Optionally, update the text display to reflect the new name
        nameText.text = input;
    }
}
