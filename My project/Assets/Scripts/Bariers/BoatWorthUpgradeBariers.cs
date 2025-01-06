using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWorthUpgradeBariers : ShootSpeedUpgradeBarier
{
    protected override void SetUpgradeValue()
    {
        base.SetUpgradeValue();
        textMeshPro.text = $"+{value}k$";
    }
}
