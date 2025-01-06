using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundAndFX;
using TMPro;

public class SandBarierScript : MonoBehaviour
{
    [SerializeField] private GameObject diamondPrefab;
    private bool isSpawningDiamond = false;
    private Vector3 smokeOffset = new (0f, 1f, 0f);

    public readonly float damage = 30f;
    private TMP_Text textOnSandBox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            if(CheckIfOneHitToDestroy())
            {
                if(isSpawningDiamond)
                {
                    return;
                }

                isSpawningDiamond = true;
            
                PlayDestroyFXEffect();
                PlayDestroySoundEffect();
                SpawnDiamond();
                Destroy(this.gameObject);
            }
        }

        else if(other.CompareTag("Boat"))
        {
            PlayDestroyFXEffect();
            PlayDestroySoundEffect();
            Destroy(this.gameObject);
        }
    }

    private void PlayDestroyFXEffect()
    {
        ServiceLocator.Current.Get<FxSystem>().PlayEffect("Explosion", this.transform.position);
    }

    private void PlayDestroySoundEffect()
    {
        ServiceLocator.Current.Get<SoundSystem>().PlaySound("DestroySandBox");
    }

    private void SpawnDiamond()
    {
        GameObject diamond = Instantiate(diamondPrefab, this.transform.position + new Vector3(0f, 1.75f, 0f), Quaternion.Euler(-90, 0, 0));
    }

    private bool CheckIfOneHitToDestroy()
    {
    // Find the TextMeshProUGUI component in the children of this GameObject
        TMP_Text textOnSandBox = GetComponentInChildren<TMP_Text>();

    // Check if the TextMeshProUGUI component exists
        if (textOnSandBox != null)
        {
        // Convert the text content to a float and check if it's greater than 1
            if (float.TryParse(textOnSandBox.text, out float value))
            {
                if (value == 2 || value == 3)
                {
                    value--;
                    textOnSandBox.text = value.ToString();
                    return false;
                }

                else if (value > 1)
                {
                    value--;
                    textOnSandBox.text = value.ToString();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
