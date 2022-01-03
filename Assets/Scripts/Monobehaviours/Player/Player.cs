using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player script, delegates tasks to interfaces based on input and does raycasting
public class Player : MonoBehaviour
{
    //Public variables that must be set in the inspector
    public Camera mainCamera;
    public LayerMask componentsLayer;
    public LayerMask destinationsLayer;

    //Input actions thingy for the new input system
    InputActions inputActions;

    //Dragging related private variables
    Vector3 mousePosition;
    bool isDragging;
    IDraggable currentComponent;

    //Initializing and cleaning up the inputActions
    private void OnEnable() => inputActions.Enable();

    private void OnDisable() => inputActions.Disable();

    private void Awake()
    {
        //Creates a new inputActions
        inputActions = new InputActions();

        //Whenever the mouse moves, its position is transformed from screen space to world space and then cached in mousePosition
        inputActions.PCMap.MousePosition.performed += ctx => mousePosition = mainCamera.ScreenToWorldPoint(ctx.ReadValue<Vector2>());

        //Whenever the player left clicks
        inputActions.PCMap.LeftClick.performed += ctx =>
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
                    
                    //If the raycast hit something, that something can have something else inserted into it, and we have something to insert then
                    if (raycastHit && raycastHit.collider.GetComponent<IInsertable>() != null && currentComponent != null)
                    {
                        //Inserts the current component into it, acceptance or refusal of the component is handled by IInsertable
                        raycastHit.collider.GetComponent<IInsertable>().Insert(currentComponent.GetTransform());
                    }

                    //Calls StopDraggingObject on the currentComponent and sets currentComponent to null
                    currentComponent.StopDraggingObject();
                    currentComponent = null;
                }
                else
                {
                    //Calls StartDraggingObject on the currentComponent
                    currentComponent.StartDraggingObject();
                }
            }
        };

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
