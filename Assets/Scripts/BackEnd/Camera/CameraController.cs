using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    [Range(0, 10)]
    public float cameraSmoothing;

    public Vector3 offset = new Vector3(0, 0, -10);

    private Transform target;

    private void Update()
    {
        if(target != null)
        {
            //lerp the position to the targets position, plus an offset so it the camera isn't right on top of what
            //were trying to look at
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * cameraSmoothing);
        }
    }

    //call this method to set the target of the camera
    public void SetTarget(Transform target) => this.target = target;
}
