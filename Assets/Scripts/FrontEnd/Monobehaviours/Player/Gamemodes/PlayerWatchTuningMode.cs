using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Watch tuning gamemode, handles logic for watch tuning
public class PlayerWatchTuningMode : MonoBehaviour, IGamemode
{
    //Public variables that must be set in the inspector
    public LayerMask watchHandsLayer;
    
    //Player's camera
    Camera mainCamera;

    //Current mousePosition
    Vector2 mousePosition;

    //Is the player dragging a part
    bool isDragging;

    //Current hand being dragged
    IDraggable currentHand;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isDragging && currentHand != null)
        {
            currentHand.WhileDragging(mousePosition);
        }
    }

    public void OnLeftClick()
    {
        RaycastHit2D hit = RaycastFromMousePosition(watchHandsLayer);
        isDragging = !isDragging;

        if (hit && hit.transform.parent.GetComponent<IDraggable>() != null)
        {
            if (isDragging)
            {
                currentHand = hit.transform.parent.GetComponent<IDraggable>();
                currentHand.StartDraggingObject(mousePosition);
            }
            else
            {
                currentHand.StopDraggingObject();
                currentHand = null;
            }
        }
        else
        {
            if (currentHand != null)
            {
                currentHand.StopDraggingObject();
                currentHand = null;
            }
        }
    }

    public void OnMoveMousePosition(Vector2 newMousePosition)
    {
        mousePosition = newMousePosition;
    }

    public void OnRightClick()
    {
        return;
    }

    RaycastHit2D RaycastFromMousePosition(LayerMask layer)
    {
        //Raycasts from the mouse's position, along the forwards vector with a magnitude of infinity to the layer and returns it
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePosition, mainCamera.transform.forward, Mathf.Infinity, layer);

        return raycastHit;
    }

    public void SetCurrentWatch(Transform currentWatch)
    {
        return;
    }
}
