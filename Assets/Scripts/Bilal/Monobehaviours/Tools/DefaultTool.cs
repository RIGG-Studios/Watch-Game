using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTool : ATool
{
    public string toolID;
    public Database database;

    private CanvasManager canvas
    {
        get
        {
            return FindObjectOfType<CanvasManager>();
        }
    }

    void Update()
    {
        if(currentPart != null)
        {
            currentPart.GetComponent<IDraggable>().WhileDragging(mousePosition);
        }
    }

    public override void LeftClickTool(RaycastHit2D hit, IWatch currentWatch, bool pressed)
    {
        if(currentUses > 0)
        {
            if (pressed)
            {
                currentPart = hit.collider.gameObject;
                currentPart.GetComponent<IDraggable>().StartDraggingObject(mousePosition);
            }
            else if(!pressed && currentPart)
            {
                RaycastHit2D holeHit = RaycastFromMousePosition(destinationsLayer);
                if (holeHit && currentPart != null)
                {
                    currentWatch.Insert(currentPart, holeHit.collider.transform);
                }
                currentPart.GetComponent<IDraggable>().StopDraggingObject();
                currentPart = null;

                currentUses--;
                canvas.FindElementGroupByID("GameGroup").FindElement("tooluses").OverrideValue(currentUses.ToString() + "/" + maxUses.ToString());   
            }
        }
        else
        {
            canvas.FindElementGroupByID("GameGroup").FindElement("tooluses").FadeElement(0, 0.25f);
            canvas.FindElementGroupByID("GameGroup").FindElement("toolicon").FadeElement(0, 0.25f);

            transform.root.GetComponent<PlayerInventory>().RemoveItem(database.GetItem(toolID), 1);
            transform.root.GetComponent<PlayerWatchBuildingMode>().currentTool = new NoTool();
        }
    }

    public void UpdateUses(int amount) => currentUses = amount;
}
