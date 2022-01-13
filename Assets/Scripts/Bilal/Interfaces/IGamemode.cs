using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that denotes a class is a gamemode
public interface IGamemode
{
    //Logic when left clicked
    public void OnLeftClick();

    //Logic when right clicked
    public void OnRightClick();

    //Logic when the mouse is moved
    public void OnMoveMousePosition(Vector2 mousePosition);

    public void SetCurrentWatch(Transform currentWatch);
}
