using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName = "DamageTable", menuName = "Custom/Damage Table")]

public class DamageTable : ScriptableObject
{
    [Header("Damage Table")]
    [Space(10)]

    public float sandBoxDMG = 20f;
    public float towerBulletDamage = 10f;
    public float boatBulletDamage = 10f;
}
