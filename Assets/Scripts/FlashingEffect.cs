using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FlashingEffect : MonoBehaviour
{
    public Image image;

    public Color white => Color.white;
    public Color grey => new Color(200,200,200);
    public float speed;


    // Update is called once per frame
    void Update()
    {
        image.color = Lerp(white,grey,speed);
        
    }

    public Color Lerp(Color firstColor, Color secondColor, float speed)
    {
        return Color.Lerp(firstColor, secondColor, Mathf.Sin(Time.time * speed));
    }
}
