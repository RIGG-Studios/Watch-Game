using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Watch building gamemode, contains logic for watch building
public class PlayerWatchBuildingMode : MonoBehaviour, IGamemode
{
    //Public variables that must be set in the inspector
    public LayerMask componentsLayer;
    public LayerMask destinationsLayer;
    public LayerMask allLayers;
    public int insertedObjectsLayer;

    //Current watch the player is working on
    public Transform currentWatch;
    //Current tool the player is using
    public ATool currentTool;

    public DefaultTool screwDriver;
    public DefaultTool tweezers;

    //Dragging related private variables
    Vector3 mousePosition;
    IDraggable currentComponent;
    //The current camera
    Camera mainCamera;
    CanvasManager canvas;
    PlayerInventory inventory;

    UIElementGroup selectionGroupUi;
    UIElement selectionGroupName;
    UIElement selectionGroupRequirements;
    bool playedIntro, playedExit;

    public bool canDrag { get; set; }

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
        inventory = FindObjectOfType<PlayerInventory>();
        mainCamera = Camera.main;

        if(canvas != null)
        {
            selectionGroupUi = canvas.FindElementGroupByID("DraggableSelectionGroup");

            selectionGroupName = selectionGroupUi.FindElement("name");
            selectionGroupRequirements = selectionGroupUi.FindElement("requirements");
        }
    }

    //When the player moves their mouse, sets the mousePosition to the newMousePosition
    public void OnMoveMousePosition(Vector2 newMousePosition)
    {
        mousePosition = newMousePosition;
        currentTool.MouseMovePosition(newMousePosition);
    }

    public void OnRightClick()
    {
        return;
    }

    //When the player left clicks
    public void OnLeftClick(bool pressed)
    {
        RaycastHit2D hit = RaycastFromMousePosition(allLayers);

        bool useTool = false;

        if (hit)
        {
            //evil floating point bit hack (not really floating point)
            if(currentTool.GetPartsLayer().value == (currentTool.GetPartsLayer().value | (1 << hit.collider.gameObject.layer)))
            {
                useTool = true;
            }
            else
            {
                useTool = false;
            }
        }

        //If the player clicked on a component and check if were currently in game
        if (CheckIfClickedObject(pressed) && !useTool) 
        {
            //If the player released left click
            if (!pressed)
            {
                //Raycasts to the destinationsLayer with all the destinations
                RaycastHit2D raycastHit = RaycastFromMousePosition(destinationsLayer);

                //If the raycast hit something and we have something to insert then
                if (raycastHit && currentComponent != null && !raycastHit.collider.gameObject.GetComponent<IInsertable>().HasObject())
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
        else if(hit && useTool)
        {
            currentTool.LeftClickTool(hit, currentWatch.GetComponentInChildren<IWatch>(), pressed);
        }
    }

    //Checks if the player clicked on a component
    bool CheckIfClickedObject(bool pressed)
    {
        if (!canDrag)
            return false;

        //Raycasts to the components layer
        RaycastHit2D raycastHit = RaycastFromMousePosition(componentsLayer);
        
        //If the raycastHit has an implementation of IDraggable then
        if (raycastHit && raycastHit.collider.GetComponent<IDraggable>() != null)
        {
            //Sets currentComponent to the IDraggable implementation and return true
            if (pressed)
            {
                Debug.Log("Found object");
                currentComponent = raycastHit.collider.GetComponent<IDraggable>();
            }
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
        if (currentComponent != null)
        {
            currentComponent.WhileDragging(mousePosition);
        }

        RaycastHit2D hit = RaycastFromMousePosition(allLayers);
        if (hit && hit.collider.GetComponent<DefaultDragging>() != null)
        {
            DefaultDragging draggable = hit.collider.GetComponent<DefaultDragging>();

            if (!playedIntro)
            {
                Item item = draggable.correspondingItem;

                selectionGroupName.OverrideValue(item.itemName);

                if (item.itemName == "Screw")
                {
                    selectionGroupRequirements.OverrideValue(!inventory.HasItem("Screwdriver", 1) ? "<color=red>REQUIRED ITEM:</color> SCREWDRIVER" : string.Empty);
                }

                if (hit.collider.gameObject.layer == 10 && draggable.inserted)
                {
                    if (draggable.misPlaced)
                    {
                        if (currentTool != tweezers)
                            selectionGroupRequirements.OverrideValue("<color=red>REQUIRED ITEM:</color> TWEEZERS");
                    }
                    else
                        selectionGroupRequirements.OverrideValue("<color=green>SUCCESFULLY PLACED</color>");
                }

                canvas.ShowElementGroup(selectionGroupUi);
                playedIntro = true;
                playedExit = false;
            }
        }
        else
        {
            if (!playedExit)
            {
                selectionGroupName.OverrideValue(string.Empty);
                selectionGroupRequirements.OverrideValue(string.Empty);
                playedExit = true;
                playedIntro = false;
            }
        }
    }

    public void SetCurrentWatch(Transform newCurrentWatch) => currentWatch = newCurrentWatch;
}
