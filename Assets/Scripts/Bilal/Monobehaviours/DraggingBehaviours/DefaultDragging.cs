using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default dragging behaviour, the object follows the mouse when dragged
public class DefaultDragging : MonoBehaviour, IDraggable
{
    //item that this draggable gameobject belongs too
    public Item correspondingItem;

    //Supplying the method with the transform
    public GameObject GetGameObject() => gameObject;

    public Item GetItem() => correspondingItem;

    //Doing nothing
    public void StartDraggingObject(Vector2 mousePosition)
    {
        return;
    }

    //Doing nothing
    public void StopDraggingObject()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }

    //Making the object follow the mouse position
    public void WhileDragging(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, -20);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
}
