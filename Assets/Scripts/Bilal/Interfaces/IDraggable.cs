using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface denoting an object can be dragged
public interface IDraggable
{
    //Method for what happens when dragging starts
    public void StopDraggingObject();

    //Method for what happens when dragging ends
    public void StartDraggingObject(Vector2 mousePosition);

    //Method for what happens when the object is being dragged
    public void WhileDragging(Vector2 mousePosition);

    //method to return the object's transform to be used in IInsertable
    public GameObject GetGameObject();

    public Item GetItem();
}
