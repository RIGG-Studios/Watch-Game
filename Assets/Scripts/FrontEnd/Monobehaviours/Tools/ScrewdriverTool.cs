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

    public void LeftClickTool(RaycastHit2D hit)
    {
        if(currentUses > 0)
        {
            if (!hasScrew)
            {
                hasScrew = true;
                currentScrew = hit.collider.gameObject;
                currentScrew.GetComponent<IDraggable>().StartDraggingObject(mousePosition);
            }
            else
            {
                hasScrew = false;
                currentScrew.GetComponent<IDraggable>().StopDraggingObject();
                currentScrew = null;

                currentUses--;
            }
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
}
