using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoatCharacteristics))]
public class BoatCharacteristicsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Cast the target to BoatCharacteristics
        BoatCharacteristics boatCharacteristics = (BoatCharacteristics)target;

        // Add a button to refresh values to initial
        if (GUILayout.Button("Reset Values"))
        {
            // Call a method to reset the values to their initial state
            RefreshValuesToInitial(boatCharacteristics);
        }
    }

    private void RefreshValuesToInitial(BoatCharacteristics boatCharacteristics)
    {
        // Reset the values to their initial state
        boatCharacteristics.playerName = "";
        boatCharacteristics.playerLevel = 1;
        boatCharacteristics.boatLevel = 1;
        boatCharacteristics.gunLevel = 1;
        boatCharacteristics.damageDealt = 0;
        boatCharacteristics.speed = 3f;
        boatCharacteristics.shootDelay = 1.5f;
        boatCharacteristics.amountOfDamage = 25f;
    }
}
