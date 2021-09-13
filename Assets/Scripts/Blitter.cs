using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Blitter : MonoBehaviour
{

    [SerializeField]
    private Material material;
    [SerializeField]
    private RenderTexture texture;

    private void Update()
    {
        if (texture != null && material != null)
        {
            Blit3D.Blit(texture, material);
        }
    }
}