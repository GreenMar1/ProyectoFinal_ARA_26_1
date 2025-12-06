using System.Collections;
using UnityEngine;

public class FadeOutAndDisable : MonoBehaviour
{
    public float fadeDuration = 1f;
    private Renderer[] renderers;
    private Material[] materials;
    private bool isFading = false;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        materials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
            materials[i] = renderers[i].material;
    }

    public void FadeOut()
    {
        if (!isFading)
            StartCoroutine(FadeOutRoutine());
    }

    IEnumerator FadeOutRoutine()
    {
        isFading = true;
        float time = 0;

        // Guarda colores iniciales
        Color[] startColors = new Color[materials.Length];
        for (int i = 0; i < materials.Length; i++)
            startColors[i] = materials[i].color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;

            for (int i = 0; i < materials.Length; i++)
            {
                Color c = startColors[i];
                c.a = Mathf.Lerp(1f, 0f, t);
                materials[i].color = c;
            }

            time += Time.deltaTime;
            yield return null;
        }

        // A 0 totalmente
        for (int i = 0; i < materials.Length; i++)
        {
            Color c = materials[i].color;
            c.a = 0f;
            materials[i].color = c;
        }

        // Finalmente apagar el objeto
        gameObject.SetActive(false);

        isFading = false;
    }
}

