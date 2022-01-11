using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface denoting an object can have something inserted into it
public interface IInsertable
{
    //Insert method, called by the player script, passes the object they're currently dragging
    public void Execute(GameObject insertObject, Transform destination);

    public bool HasObject();
}
