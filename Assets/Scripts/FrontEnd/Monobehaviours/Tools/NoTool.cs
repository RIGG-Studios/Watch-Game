using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTool : ATool
{
    public override int GetRemainingUses() => 0;

    public override void MouseMovePosition(Vector2 currentMousePos)
    {
        return;
    }
}
