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
        float deltaX = cameraTransform.position.x - lastCameraPosition.x;
        float deltaY = cameraTransform.position.y - lastCameraPosition.y;

        transform.position += new Vector3(deltaX * parallaxEffectMultiplier, deltaY * parallaxEffectMultiplier, 0f);

        lastCameraPosition = cameraTransform.position;
    }
}
