using UnityEngine;

public class TextureRepeat : MonoBehaviour
{
    public Vector2 tiling = new Vector2(4f, 4f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>(); // get the renderer

        if (renderer != null)
        {
            renderer.material.mainTextureScale = tiling; // set the number of times the texture repeats to tiling (vector2)
        }
    }
}
