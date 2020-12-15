using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundColor : MonoBehaviour
{
    [SerializeField]
    int colorChangeInterval = 3;

    private Camera cam;

    // Variable of byte type data for setting Color32 value
    byte red = 0;
    byte green = 0;
    byte blue = 0;
    byte alpha = 255;

    int frameCount = 0;
    
    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        red = 255;
        cam.backgroundColor = new Color32(red, green, blue, alpha); 
    }

    // Update is called once per frame
    void Update()
    {
        TimedColorAnim();
    }
    private void TimedColorAnim() // Function for calling AnimateLightingInRainbow() in certain frames
    {
        if (colorChangeInterval == frameCount)
        {
            AnimateColor();
            frameCount = 0; 
        }
        else if (colorChangeInterval != frameCount)
        {
            frameCount++;
        }
    }

    private void AnimateColor() // Function for changing the color of Light 
    {
        // if - else statement that calculates RGB value for the color change 
        if (red == 0 && green == 0 && blue == 0)
            red = 255;
        else if (red == 0 && green < 255 && blue == 255)
            green++;
        else if (red == 0 && green == 255 && blue > 0)
            blue--;
        else if (red == 255 && green == 0 && blue < 255)
            blue++;
        else if (red == 255 && green > 0 && blue == 0)
            green--;
        else if (red > 0 && green == 0 && blue == 255)
            red--;
        else if (red < 255 && green == 255 && blue == 0)
            red++;

        cam.backgroundColor = new Color32(red, green, blue, alpha); // Update the RGB value of the color of Light with the RGB value calculated from the above if-else statements
        Debug.Log("R value: " + red + " | G value: " + green + " | B value: " + blue); // Log the new RGB value in the console
    }
}
