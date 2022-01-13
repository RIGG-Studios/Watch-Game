using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ATool: MonoBehaviour
{
    public LayerMask partsLayer;
    public LayerMask destinationsLayer;

    public int maxUses;
    protected int currentUses;

    protected GameObject currentPart;
    protected bool hasPart;

    protected Vector2 mousePosition;

    public void Awake()
    {
        currentUses = maxUses;
    }

    public virtual void LeftClickTool(RaycastHit2D hit, IWatch currentWatch) 
    {
        return;
    }

    public virtual void RightClickTool()
    {
        return;
    }

    public RaycastHit2D RaycastFromMousePosition(LayerMask layer)
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(mousePosition, Camera.main.transform.forward, Mathf.Infinity, layer);

        return raycastHit;
    }

    public virtual void MouseMovePosition(Vector2 currentMousePos) => mousePosition = currentMousePos;

    public virtual int GetRemainingUses() => currentUses;

    public LayerMask GetPartsLayer() => partsLayer;

    public LayerMask GetLocationsLayer() => destinationsLayer;
}
