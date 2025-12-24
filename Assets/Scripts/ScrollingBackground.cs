using System.Numerics;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    
    [SerializeField]
    private Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new UnityEngine.Vector2(speed * Time.deltaTime, 0);
    }
}
