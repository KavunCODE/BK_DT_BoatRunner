using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SoundAndFX;

public class PlayButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Image img;
    [SerializeField] private Sprite defaultbut, pressedbut;
    [SerializeField] private AudioClip compressedClip, uncompressedClip;
    [SerializeField] private SoundSystem soundSystem;

    public void OnPointerDown(PointerEventData eventData)
    {
        img.sprite = pressedbut;
        soundSystem.PlaySound("PlayButtonDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(WaitForLoading());
    }

    private IEnumerator WaitForLoading()
    {
        img.sprite = defaultbut;
        soundSystem.PlaySound("PlayButtonDown");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
