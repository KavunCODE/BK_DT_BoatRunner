using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using SoundAndFX;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject bossBoat;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Boat"))
        {
            bossBoat.SetActive(true);
            ServiceLocator.Current.Get<SoundSystem>().FadeInMusic("MusicBG", 2f);
            StartCoroutine("TurnOnNewMusic");
        }
    }

    private IEnumerator TurnOnNewMusic()
    {
        yield return new WaitForSeconds(2f);
        ServiceLocator.Current.Get<SoundSystem>().FadeOutMusic("PirateMusic", 0.9f);
        yield return new WaitForSeconds(1f);
        ServiceLocator.Current.Get<SoundSystem>().FadeOutMusic("Water", 0.9f);
        yield return new WaitForSeconds(4f);
        ServiceLocator.Current.Get<SoundSystem>().FadeInMusic("Water", 1f);
    }
}
