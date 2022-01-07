using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class ImageElement : UIElement
{
    private Image Image
    {
        get
        {
            return GetComponent<Image>();
        }
    }

    public override void OverrideValue(object message)
    {
        Sprite sprite = (Sprite)message;

        if (sprite != null)
            Image.sprite = sprite;
    }
}
