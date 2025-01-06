using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoatWaterParticlesController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DisableParticleEmission());
    }

    private IEnumerator DisableParticleEmission()
    {
        // Wait for 5 seconds before starting to disable particle emission
        yield return new WaitForSeconds(7f);

        // Loop until the GameObject is destroyed
        while (true)
        {
            // Iterate through all child objects of the current GameObject
            foreach (Transform child in transform)
            {
                // Get the ParticleSystem component attached to the child GameObject
                ParticleSystem particleSystem = child.GetComponent<ParticleSystem>();

                // If a ParticleSystem component is found, disable its emission
                if (particleSystem != null)
                {
                    var emission = particleSystem.emission;
                    emission.enabled = false;
                }
            }

            // Wait for a short duration before checking again
            yield return new WaitForSeconds(0.5f);

            // Check if the GameObject has been destroyed, and if so, exit the coroutine
            if (gameObject == null)
            {
                yield break;
            }
        }
    }
}
