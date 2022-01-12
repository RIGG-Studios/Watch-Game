using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewdriverTool : MonoBehaviour, ITool
{
    public LayerMask screwLayer;
    public LayerMask holesLayer;
    public int maxUses;

    GameObject currentScrew;
    bool hasScrew;
    int currentUses;

    Vector2 mousePosition;

    void Start()
    {
        currentUses = maxUses;
    }

    void Update()
    {
        if(currentScrew != null)
        {
            currentScrew.GetComponent<IDraggable>().WhileDragging(mousePosition);
        }
    }

    public void LeftClickTool(RaycastHit2D hit, IWatch currentWatch)
    {
        if(currentUses > 0)
        {
            if (!hasScrew)
            {
                currentScrew = hit.collider.gameObject;
                currentScrew.GetComponent<IDraggable>().StartDraggingObject(mousePosition);
            }
            else
            {
                RaycastHit2D holeHit = RaycastFromMousePosition(holesLayer);
                if (holeHit && currentScrew != null)
                {
                    currentWatch.Insert(currentScrew, holeHit.collider.transform);
                }
                currentScrew.GetComponent<IDraggable>().StopDraggingObject();
                currentScrew = null;

                currentUses--;
            }

            hasScrew = !hasScrew;
        }
        else
        {
            Debug.Log("Tool broke");
            GetComponent<PlayerManager>().SetCurrentTool(new NoTool());
        }
    }

    public void RightClickTool()
    {
        return;
    }

    public int GetRemainingUses() => currentUses;

    public void MouseMovePosition(Vector2 currentMousePos) => mousePosition = currentMousePos;

    public LayerMask GetPartsLayer() => screwLayer;

    public LayerMask GetLocationsLayer() => holesLayer;

    RaycastHit2D RaycastFromMousePosition(LayerMask layer)
    {
        //Raycasts from the mouse's position, along the forwards vector with a magnitude of infinity to the layer and returns it
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePosition, Camera.main.transform.forward, Mathf.Infinity, layer);

        return raycastHit;
    }
}
