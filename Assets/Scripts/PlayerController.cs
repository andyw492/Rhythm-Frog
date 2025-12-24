using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public void move_player(Vector3 movement)
    {
        transform.position += movement;
    }
}
