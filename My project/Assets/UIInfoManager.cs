using UnityEngine;
using TMPro;

public class UIInfoManager : MonoBehaviour
{
    public PlayerInfoGetter playerInfoGetter;
    public TMP_Text playerLevelText;
    public TMP_Text gunLevelText;
    public TMP_Text boatLevelText;
    public TMP_Text damageDealtText;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        playerLevelText.text = playerInfoGetter.GetPlayerLevel();
        gunLevelText.text = playerInfoGetter.GetGunLevel();
        boatLevelText.text = playerInfoGetter.GetBoatLevel();
        damageDealtText.text = playerInfoGetter.GetDamageDealt();
    }
}
