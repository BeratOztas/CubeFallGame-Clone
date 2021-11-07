using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float scroll_Speed = 0.3f;
    private string MAIN_TEXT = "_MainTex";
    private MeshRenderer mesh_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        
    }
    void Scroll()
    {
        Vector2 ofset = mesh_Renderer.sharedMaterial.GetTextureOffset(MAIN_TEXT);
        ofset.y += Time.deltaTime * scroll_Speed;
        mesh_Renderer.sharedMaterial.SetTextureOffset(MAIN_TEXT, ofset);

    }
}
