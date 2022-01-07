using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIElementGroup))]
public class UIElementGroupEditor : Editor
{
    public override void OnInspectorGUI()
    {
        UIElementGroup element = (UIElementGroup)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Find Elements"))
            element.FindUIElements();
    }
}
