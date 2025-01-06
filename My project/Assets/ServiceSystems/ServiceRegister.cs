using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundAndFX;

public class ServiceRegister : MonoBehaviour
{
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private FxSystem _fxSystem;
    [SerializeField] private DamageTable _damageTable;

    void Awake()
    {
        ServiceLocator.Initialize();
        ServiceLocator.Current.Register<SoundSystem>(_soundSystem);
        ServiceLocator.Current.Register<FxSystem>(_fxSystem);
        ServiceLocator.Current.Register<DamageTable>(_damageTable);
    }
}
