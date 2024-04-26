using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float parallaxEffectMultiplier = 0.5f;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        //Calculates the distance the camera has moved
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        float deltaY = cameraTransform.position.y - lastCameraPosition.y;

        //Update the position of the background objects
        transform.position += new Vector3(deltaX * parallaxEffectMultiplier, deltaY * parallaxEffectMultiplier, 0f);

        //Updates last position to be used in the next frame
        lastCameraPosition = cameraTransform.position;
    }
}
