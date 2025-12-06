using System.Collections;
using UnityEngine;

public class FadeInAndEnable : MonoBehaviour
{
    public float fadeDuration = 1f;
    private Renderer[] renderers;
    private Material[] materials;

    void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        materials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
            materials[i] = renderers[i].material;
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        float time = 0;

        // Setear alpha inicial a 0
        for (int i = 0; i < materials.Length; i++)
        {
            Color c = materials[i].color;
            c.a = 0f;
            materials[i].color = c;
        }

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;

            for (int i = 0; i < materials.Length; i++)
            {
                Color c = materials[i].color;
                c.a = Mathf.Lerp(0f, 1f, t);
                materials[i].color = c;
            }

            time += Time.deltaTime;
            yield return null;
        }

        // A 1 totalmente
        for (int i = 0; i < materials.Length; i++)
        {
            Color c = materials[i].color;
            c.a = 1f;
            materials[i].color = c;
        }
    }
}

