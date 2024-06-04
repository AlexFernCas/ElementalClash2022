using UnityEngine;
using TMPro;

public class MuteButton : MonoBehaviour
{
    public TextMeshProUGUI textoBoton;
    public bool sonidoActivado = true;

    public void ToggleSonido()
    {
        sonidoActivado = !sonidoActivado;
        ActualizarTextoBoton();
    }

    void ActualizarTextoBoton()
    {
        if (!sonidoActivado)
        {
            textoBoton.text = "Desilenciar";
        }
        else
        {
            textoBoton.text = "Silenciar";
        }
    }
}