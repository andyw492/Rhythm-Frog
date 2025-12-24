using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void move_camera(Vector3 movement)
    {
        transform.position += movement;
    }
}
