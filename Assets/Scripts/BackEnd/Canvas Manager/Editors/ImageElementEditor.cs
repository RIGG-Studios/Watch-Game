using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ImageElement))]
public class ImageElementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ImageElement element = (ImageElement)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Load Element"))
        {
            element.Setup();
        }
    }
}
