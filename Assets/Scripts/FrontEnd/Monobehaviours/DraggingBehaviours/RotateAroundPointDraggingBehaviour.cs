using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPointDraggingBehaviour : MonoBehaviour, IDraggable
{
    //Variables that must be set in the inspector
    public Transform rotationPoint;
    public Transform watchHandFront;
    public float tolorence;
    public float rotateSpeed;

    bool isMovingleft;


    public GameObject GetGameObject() => transform.parent.gameObject;

    public void StartDraggingObject(Vector2 mousePosition)
    {

    }

    public void StopDraggingObject()
    {
        return;
    }

    public void WhileDragging(Vector2 mousePosition)
    {
        Vector2 rotationPointTo2DVector = new Vector2(rotationPoint.position.x, rotationPoint.position.y);
        
        Vector2 rotateToVector = (mousePosition - rotationPointTo2DVector).normalized;
        Vector2 rotateFromVector = (new Vector2(watchHandFront.position.x, watchHandFront.position.y) - rotationPointTo2DVector).normalized;

        float anglebetweenVectors = Mathf.Acos(Vector2.Dot(rotateToVector, rotateFromVector)) * rotateSpeed;

        if(rotateToVector.y - tolorence > 0)
        {
            if(rotateToVector.x - rotateFromVector.x > 0)
            {
                isMovingleft = false;
            }
            else if(rotateToVector.x - rotateFromVector.x < 0)
            {
                isMovingleft = true;
            }
        }
        else if(rotateToVector.y + tolorence < 0)
        {
            if (rotateToVector.x - rotateFromVector.x > 0)
            {
                isMovingleft = true;
            }
            else if (rotateToVector.x - rotateFromVector.x < 0)
            {
                isMovingleft = false;
            }
        }

        if (isMovingleft)
        {
            transform.Rotate(Vector3.forward, anglebetweenVectors);
        }
        else if (!isMovingleft)
        {
            transform.Rotate(Vector3.forward, -anglebetweenVectors);
        }
    }
}
