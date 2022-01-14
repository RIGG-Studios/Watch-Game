using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementation of IDraggable, used to rotate something around a rotation point
public class RotateAroundPointDraggingBehaviour : MonoBehaviour, IDraggable
{
    //Variables that must be set in the inspector
    public Transform rotationPoint;
    public Transform watchHandFront;
    public float rotateTolorence;
    public float rotateSpeed;
    public int angleToWin;
    public int winTolorence;

    PlayerManager player;
    //Variables that are used in hand rotation
    bool isMovingCounterClockwise;
    bool isMovingLeftLastFrame;
    float currentRotation;

    //Returns the gameobject
    public GameObject GetGameObject() => transform.parent.gameObject;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    //Does nothing
    public void StartDraggingObject(Vector2 mousePosition)
    {
        return;
    }

    //Checks if the player has placed the hand correctly
    public void StopDraggingObject()
    {
        //If the player places the hand at the right angle plus or minus some tolorence
        if((currentRotation < angleToWin + winTolorence && currentRotation > angleToWin - winTolorence) || (currentRotation < (-360 + angleToWin) + winTolorence && currentRotation > (-360 + angleToWin) - winTolorence))
        {
            player.IncrementCorrectWatchHands();
        }
    }

    //The meat and potatoes of this script
    public void WhileDragging(Vector2 mousePosition)
    {
        //Gets a 2d vector from the supplied rotation point, basically just dumps the z value, done so I don't have to retype this twice
        Vector2 rotationPointTo2DVector = new Vector2(rotationPoint.position.x, rotationPoint.position.y);
        
        //Gets a vector starting at the rotation point and ending at mouse position, with a magnitude of 1
        Vector2 rotateToVector = (mousePosition - rotationPointTo2DVector).normalized;
        //Gets a vector starting att he rotation point and ending at the front end of the hand, with a magnitude of 1
        Vector2 rotateFromVector = (new Vector2(watchHandFront.position.x, watchHandFront.position.y) - rotationPointTo2DVector).normalized;

        //Figures out the angle between rotateFromVector to rotateToVector
        float anglebetweenVectors = Vector2.Angle(rotateFromVector, rotateToVector);

        //All code beyond this point is basically just figuring out if the hands are turning clockwise or counterclockwise


        //The horizon is a horizontal line that divides the watch into 2 even hemispheres, the upper hemisphere, and the lower hemisphere,
        //reached when the rotateToVector's y value is 0

        //If the rotateToVector's y value, give or take a certain tolorence is not at the horizon

        //Ie, if the player's cursor is in the upper hemisphere of the watch face
        if (rotateToVector.y - rotateTolorence > 0)
        {
            //If the player is moving the hand right, increasing x values
            if(rotateToVector.x - rotateFromVector.x > 0)
            {
                //Then they are not moving the hand counter clockwise
                isMovingCounterClockwise = false;
            }
            //Else if the player is moving the hand to the left, decreasing x values
            else if(rotateToVector.x - rotateFromVector.x < 0)
            {
                //Then they are moving the hand counter clockwise
                isMovingCounterClockwise = true;
            }
        }
        //Else if the player's cursor is in the lower hemisphere
        else if(rotateToVector.y + rotateTolorence < 0)
        {
            //If the player is moving the hand right, increasing x values
            if (rotateToVector.x - rotateFromVector.x > 0)
            {
                //Then they are moving counter clockwise
                isMovingCounterClockwise = true;
            }
            //Else if the player is moving the hand left, decreasing x values
            else if (rotateToVector.x - rotateFromVector.x < 0)
            {
                //Then they are not moving counter clockwise
                isMovingCounterClockwise = false;
            }
        }
        //If the player's cursor is at the horizon give or take some tolorence
        else
        {
            //Whatever direction the player was moving last frame is the direction they are moving this frame
            isMovingCounterClockwise = !isMovingLeftLastFrame;
        }

        //If the player is moving counter clockwise, then rotate tje hand counter clockwise and decrease current angle
        if (isMovingCounterClockwise)
        {
            transform.Rotate(Vector3.forward, anglebetweenVectors);

            currentRotation -= anglebetweenVectors;
        }
        //Else, rotate the hand clockwise and increase the current angle
        else if (!isMovingCounterClockwise)
        {
            transform.Rotate(Vector3.forward, -anglebetweenVectors);
            currentRotation += anglebetweenVectors;
        }


        //If the current angle is greater than 360 or less than -360 then set it to 0
        if (currentRotation > 360 || currentRotation < -360)
        {
            currentRotation = 0;
        }

        //Setting what they did this frame to use next frame
        isMovingLeftLastFrame = isMovingCounterClockwise;
    }

    public Item GetItem() => null;
}
