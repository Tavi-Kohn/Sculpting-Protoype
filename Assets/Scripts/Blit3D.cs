using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blit3D
{
    public static void Blit(RenderTexture tex, Material blitMat)
    {
        GL.PushMatrix();
        GL.LoadOrtho();
        for (int i = 0; i < tex.volumeDepth; i++)
        {
            // make sure tex.dimension is Tex3D. I think it works with Tex2DArray too
            Graphics.SetRenderTarget(tex, 0, CubemapFace.Unknown, i);

            // because i was using this for noise generation, I wanted the uvs to be strictly 0 to 1
            // (i had to remap the x and y coords in the shader as well)
            // but you may want to change it to how textures normally go 
            // (something like 0.5 -> size - 0.5)
            // float z = Mathf.Clamp01(i / (float)(tex.volumeDepth - 1));
            float z = Mathf.Clamp01(i / (float)(tex.volumeDepth - 1));

            blitMat.SetPass(0);
            GL.Begin(GL.QUADS);

            GL.TexCoord3(0, 0, z);
            GL.Vertex3(0, 0, 0);
            GL.TexCoord3(1, 0, z);
            GL.Vertex3(1, 0, 0);
            GL.TexCoord3(1, 1, z);
            GL.Vertex3(1, 1, 0);
            GL.TexCoord3(0, 1, z);
            GL.Vertex3(0, 1, 0);

            GL.End();
        }
        GL.PopMatrix();
    }
}
