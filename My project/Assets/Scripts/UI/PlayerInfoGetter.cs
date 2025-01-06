using UnityEngine;
using TMPro;

public class PlayerInfoGetter : MonoBehaviour
{
    [SerializeField] BoatCharacteristics playerInfo;

    public string GetName()
    {
        if(playerInfo != null) return playerInfo.playerName;
        else return "N/A";
    }

    public string GetPlayerLevel()
    {
        if(playerInfo != null) return playerInfo.playerLevel.ToString();
        else return "N/A";
    }

    public string GetBoatLevel()
    {
        if(playerInfo != null) return playerInfo.boatLevel.ToString();
        else return "N/A";
    }

    public string GetGunLevel()
    {
        if(playerInfo != null) return playerInfo.gunLevel.ToString();
        else return "N/A";
    }

    public string GetDamageDealt()
    {
        if(playerInfo != null) return playerInfo.damageDealt.ToString();
        else return "N/A";
    }
}
