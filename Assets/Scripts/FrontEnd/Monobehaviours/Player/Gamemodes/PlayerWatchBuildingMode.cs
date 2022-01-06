using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Watch building gamemode, contains logic for watch building
public class PlayerWatchBuildingMode : MonoBehaviour, IGamemode
{
    //Public variables that must be set in the inspector
    public LayerMask componentsLayer;
    public LayerMask destinationsLayer;

    //The current camera
    Camera mainCamera;

    //Current watch the player is working on
    public Transform currentWatch;

    //Dragging related private variables
    Vector3 mousePosition;
    bool isDragging;
    IDraggable currentComponent;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    //When the player moves their mouse, sets the mousePosition to the newMousePosition
    public void OnMoveMousePosition(Vector2 newMousePosition) => mousePosition = newMousePosition;

    public void OnRightClick()
    {
        return;
    }

    //When the player left clicks
    public void OnLeftClick()
    {
        //If the player clicked on a component
        if (CheckIfClickedObject())
        {
            //Inverts isDragging, tells us if the player released left click or pressed it
            isDragging = !isDragging;

            //If the player released left click
            if (!isDragging)
            {
                //Raycasts to the destinationsLayer with all the destinations
                RaycastHit2D raycastHit = RaycastFromMousePosition(destinationsLayer);

                //If the raycast hit something and we have something to insert then
                if (raycastHit && currentComponent != null)
                {
                    //Tells the current watch to insert this part and passes the thing behind it the raycast hit, the destination transform
                    currentWatch.GetComponentInChildren<IWatch>().Insert(currentComponent.GetGameObject(), raycastHit.transform);
                }

                //Calls StopDraggingObject on the currentComponent and sets currentComponent to null
                currentComponent.StopDraggingObject();
                currentComponent = null;
            }
            else
            {
                //Calls StartDraggingObject on the currentComponent
                currentComponent.StartDraggingObject(mousePosition);
            }
        }
    }

    //Checks if the player clicked on a component
    bool CheckIfClickedObject()
    {
        //Raycasts to the components layer
        RaycastHit2D raycastHit = RaycastFromMousePosition(componentsLayer);
        
        //If the raycastHit has an implementation of IDraggable then
        if (raycastHit && raycastHit.collider.GetComponent<IDraggable>() != null)
        {
            //Sets currentComponent to the IDraggable implementation and return true
            currentComponent = raycastHit.collider.GetComponent<IDraggable>();
            return true;
        }
        //Return false
        return false;
    }

    //Casts a ray from mousePosition to a layer, ignoring all others and returns a RayCastHit2D
    RaycastHit2D RaycastFromMousePosition(LayerMask layer)
    {
        //Raycasts from the mouse's position, along the forwards vector with a magnitude of infinity to the layer and returns it
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePosition, mainCamera.transform.forward, Mathf.Infinity, layer);
        
        return raycastHit;
    }

    void Update()
    {
        //If there is a currentComponent then it calls WhileDragging on it with mousePosition
        if(currentComponent != null)
        {
            currentComponent.WhileDragging(mousePosition);
        }
    }
}
