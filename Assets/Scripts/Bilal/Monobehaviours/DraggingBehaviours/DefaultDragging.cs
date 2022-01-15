using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default dragging behaviour, the object follows the mouse when dragged
public class DefaultDragging : MonoBehaviour, IDraggable
{
    public bool inserted { get; set; }
    public bool misPlaced { get; set; }

    //item that this draggable gameobject belongs too
    public Item correspondingItem;

    public GameObject stuckInDestination;

    //Supplying the method with the transform
    public GameObject GetGameObject() => gameObject;

    public Item GetItem() => correspondingItem;

    //Doing nothing
    public void StartDraggingObject(Vector2 mousePosition)
    {
        inserted = true;
    }

    //Doing nothing
    public void StopDraggingObject()
    {
        if (!misPlaced)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
            stuckInDestination = null;
            if (gameObject.layer == 11)
            {
                gameObject.layer = 3;
            }
        }
        if (inserted)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        if(misPlaced)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -3);
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            if(gameObject.layer != 8)
            {
                gameObject.layer = 11;
            }
        }
    }

    //Making the object follow the mouse position
    public void WhileDragging(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, -6);
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
    }
}
