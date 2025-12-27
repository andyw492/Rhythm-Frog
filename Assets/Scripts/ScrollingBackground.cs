using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    Renderer r;
    float width;

    public float speed;
    
    [SerializeField]
    private Renderer bgRenderer;

    void Awake()
    {
        r = GetComponent<Renderer>();
        width = r.bounds.size.x;
    }

    public void move_background(Vector3 movement)
    {
        Debug.Log(movement.x / width);
        Debug.Log(speed * Time.deltaTime);
        bgRenderer.material.mainTextureOffset += new Vector2(movement.x / width, 0);
        //bgRenderer.material.mainTextureOffset += new UnityEngine.Vector2(speed * Time.deltaTime, 0);
    }
}
