using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTool : ATool
{

    void Update()
    {
        if(currentPart != null)
        {
            currentPart.GetComponent<IDraggable>().WhileDragging(mousePosition);
        }
    }

    public override void LeftClickTool(RaycastHit2D hit, IWatch currentWatch)
    {
        if(currentUses > 0)
        {
            if (!hasPart)
            {
                currentPart = hit.collider.gameObject;
                currentPart.GetComponent<IDraggable>().StartDraggingObject(mousePosition);
            }
            else
            {
                RaycastHit2D holeHit = RaycastFromMousePosition(destinationsLayer);
                if (holeHit && currentPart != null)
                {
                    currentWatch.Insert(currentPart, holeHit.collider.transform);
                }
                currentPart.GetComponent<IDraggable>().StopDraggingObject();
                currentPart = null;

                currentUses--;
            }

            hasPart = !hasPart;
        }
        else
        {
            GetComponent<PlayerWatchBuildingMode>().currentTool = new NoTool();
        }
    }
}
