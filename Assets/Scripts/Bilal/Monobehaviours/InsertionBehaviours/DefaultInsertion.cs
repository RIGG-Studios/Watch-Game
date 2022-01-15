using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default inserting behaviour, just positions the object if it is valid
public class DefaultInsertion : MonoBehaviour, IInsertable
{
    private bool occupied;
    public GameObject missingPiece;

    public Vector3 restingPosition { get; private set; }
    public Vector3 originalPos { get; private set; }

    void Awake()
    {
        restingPosition = transform.GetChild(0).position + new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), 0);
        originalPos = transform.position;
    }

    //Transforming the insertObject to this object's position
    public void Execute(GameObject insertObject, Transform destination)
    {
        if (insertObject.GetComponentInChildren<Animator>())
        {
            insertObject.GetComponentInChildren<Animator>().SetTrigger("onInsert");
        }

        insertObject.gameObject.layer = 11;
        insertObject.transform.position = destination.position;
        occupied = true;
    }

    public bool HasObject() => occupied;
}
