using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangFont : MonoBehaviour
{
    [SerializeField]
    Canvas textCanvas = null;
    [SerializeField]
    float speed = 2.0f;
    // Font & String array that can be edited in the editor
    [SerializeField]
    Font[] fontArray = null;
    [SerializeField]
    string[] textArray = null;

    Vector2 posInCanvas;
    Vector2 newPosInCanvas;
    Text thisText= null;
    int randFontIndex = 0; // This random number will be used to choose a random font to display
    int randTextIndex = 0; // This random number will be used to choose a random text to display
    int randFontSize = 0; // This random number will be used to choose a random size for text

    void Awake()
    {
        Cursor.visible = false;
        thisText = GetComponent<Text>();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(textCanvas.transform as RectTransform, Input.mousePosition, textCanvas.worldCamera, out posInCanvas);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeFont(1.5f));
        Debug.Log("textArray length is " + textArray.Length);
    }

    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(textCanvas.transform as RectTransform, Input.mousePosition, textCanvas.worldCamera, out newPosInCanvas);
        transform.position = Vector2.MoveTowards(transform.position, textCanvas.transform.TransformPoint(newPosInCanvas), speed);
        //transform.position = textCanvas.transform.TransformPoint(newPosInCanvas);
    }

    IEnumerator ChangeFont(float wait)
    {
        randFontIndex = Random.Range(0, fontArray.Length);
        randTextIndex = Random.Range(0, textArray.Length);
        randFontSize = Random.Range(40, 80);
        Debug.Log("random index is " + randFontIndex);
        yield return new WaitForSeconds(wait);
        thisText.fontSize = randFontSize;
        thisText.font = fontArray[randFontIndex];
        thisText.text = textArray[randTextIndex];
        print("Font changed: " + Time.time + " seconds");
        StartCoroutine(ChangeFont(1.5f));
    }
}
