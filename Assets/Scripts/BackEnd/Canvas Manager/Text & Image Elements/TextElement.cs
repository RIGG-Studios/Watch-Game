using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

public class TextElement : UIElement
{
    private Text Text
    {
        get
        {
            return GetComponent<Text>();
        }
    }

    public override void OverrideValue(object message)
    {
        string msg = (string)message;

        if (msg != null)
            Text.text = msg;
    }
}
