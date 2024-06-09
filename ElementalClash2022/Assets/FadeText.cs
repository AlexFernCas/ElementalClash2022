using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeText : MonoBehaviour
{
     public TextMeshProUGUI textToFade; // El componente de texto que quieres hacer transparente.
    public float fadeDuration = 2.0f; // Duración de la animación de desvanecimiento.

    void Start()
    {
        // Iniciar la coroutine para desvanecer el texto.
        StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        // Obtenemos el color actual del texto.
        Color originalColor = textToFade.color;

        // Desvanecemos el texto poco a poco.
        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            // Calculamos la proporción de la animación completada.
            float blend = t / fadeDuration;

            // Interpolamos entre el color original y un color transparente.
            textToFade.color = Color.Lerp(originalColor, new Color(originalColor.r, originalColor.g, originalColor.b, 0), blend);

            // Esperamos al siguiente frame.
            yield return null;
        }

        // Nos aseguramos de que el texto sea completamente transparente al final.
        textToFade.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
}