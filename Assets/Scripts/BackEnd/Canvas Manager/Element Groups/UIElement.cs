using UnityEngine;
using UnityEngine.UI;
using System;


public class UIElement : MonoBehaviour
{
    public string id;
    public MaskableGraphic graphics;

    public Transform GetTransform() => transform;
    public void SetActive(bool state) => gameObject.SetActive(state);

    public virtual void OverrideValue(object message) { }

    public void Setup()
    {
        id = gameObject.name.ToLower();
        graphics = GetComponent<MaskableGraphic>();
    }
}


