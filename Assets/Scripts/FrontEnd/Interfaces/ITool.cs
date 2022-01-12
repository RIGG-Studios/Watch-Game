using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITool
{
    public void LeftClickTool(RaycastHit2D hit, IWatch currentWatch);

    public void RightClickTool();

    public int GetRemainingUses();

    public void MouseMovePosition(Vector2 currentMousePos);

    public LayerMask GetPartsLayer();

    public LayerMask GetLocationsLayer();
}
