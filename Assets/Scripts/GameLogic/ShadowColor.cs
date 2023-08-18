using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Odpowiada za kolory oraz przezroczystosc cieni zapalek

----------------------------------------------------------------------------------------------------------- */
public class ShadowColor : MonoBehaviour
{
    private string colorHex = "#FFFFFF";
    private float transparency = 0.1f;
    private SpriteRenderer spriteRenderer;
    private Color targetColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetColor = Color.black;

        ApplyColor(); // Ustawienie koloru na podstawie zmiennych
    }

    private void ApplyColor()
    {
        if (ColorUtility.TryParseHtmlString(colorHex, out targetColor))
        {
            targetColor.a = transparency;
            spriteRenderer.color = targetColor;
        }
    }

    // Ta metoda mo¿e byæ wywo³ana z zewn¹trz, np. po klonowaniu prefabu
    public void SetTransparency(float newTransparency)
    {
        transparency = newTransparency;
        ApplyColor(); // Ustawienie nowej wartoœci koloru
    }
}
