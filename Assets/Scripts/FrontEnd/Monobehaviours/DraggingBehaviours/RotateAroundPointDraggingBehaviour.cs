using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPointDraggingBehaviour : MonoBehaviour, IDraggable
{
    //Variables that must be set in the inspector
    public Transform rotationPoint;
    public Transform watchHandFront;
    public float rotateTolorence;
    public float rotateSpeed;
    public int angleToWin;
    public int winTolorence;

    bool isMovingleft;
    bool isMovingLeftLastFrame;
    float currentRotation;


    public GameObject GetGameObject() => transform.parent.gameObject;

    public void StartDraggingObject(Vector2 mousePosition)
    {

    }

    public void StopDraggingObject()
    {
        if(currentRotation < angleToWin + winTolorence && currentRotation > angleToWin - winTolorence || currentRotation < (-360 + angleToWin) + winTolorence && currentRotation > (-360 + angleToWin) - winTolorence)
        {
            Debug.Log("Hand is in the right place");
        }
    }

    public void WhileDragging(Vector2 mousePosition)
    {
        Vector2 rotationPointTo2DVector = new Vector2(rotationPoint.position.x, rotationPoint.position.y);
        
        Vector2 rotateToVector = (mousePosition - rotationPointTo2DVector).normalized;
        Vector2 rotateFromVector = (new Vector2(watchHandFront.position.x, watchHandFront.position.y) - rotationPointTo2DVector).normalized;

        float anglebetweenVectors = Vector2.Angle(rotateFromVector, rotateToVector);

        if (rotateToVector.y - rotateTolorence > 0)
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
        else if(rotateToVector.y + rotateTolorence < 0)
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
        else
        {
            isMovingleft = !isMovingLeftLastFrame;
        }

        if (isMovingleft)
        {
            transform.Rotate(Vector3.forward, anglebetweenVectors);
            currentRotation -= anglebetweenVectors;
        }
        else if (!isMovingleft)
        {
            transform.Rotate(Vector3.forward, -anglebetweenVectors);
            currentRotation += anglebetweenVectors;
        }

        if(currentRotation > 360 || currentRotation < -360)
        {
            currentRotation = 0;
        }

        isMovingLeftLastFrame = isMovingleft;
    }
}
