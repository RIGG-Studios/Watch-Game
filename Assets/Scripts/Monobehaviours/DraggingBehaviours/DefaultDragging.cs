using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default dragging behaviour, the object follows the mouse when dragged
public class DefaultDragging : MonoBehaviour, IDraggable
{
    //Supplying the method with the transform
    public GameObject GetGameObject() => gameObject;

    //Doing nothing
    public void StartDraggingObject()
    {
        return;
    }

    //Doing nothing
    public void StopDraggingObject()
    {
        return;
    }

    //Making the object follow the mouse position
    public void WhileDragging(Vector2 position)
    {
        transform.position = position;
    }
}
