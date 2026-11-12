using UnityEngine;

public class Background : MonoBehaviour
{
    
    public float velocidad = 0.1f;
    private Renderer rend;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = rend.material.mainTextureOffset;
        offset.x += velocidad * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
