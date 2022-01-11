using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTool : MonoBehaviour, ITool
{
    public LayerMask GetLocationsLayer()
    {
        return LayerMask.NameToLayer("Nothing");
    }

    public LayerMask GetPartsLayer()
    {
        return LayerMask.NameToLayer("Nothing");
    }

    public int GetRemainingUses() => 0;

    public void LeftClickTool(RaycastHit2D hit)
    {
        return;
    }

    public void MouseMovePosition(Vector2 currentMousePos)
    {
        return;
    }

    public void RightClickTool()
    {
        return;
    }
}
