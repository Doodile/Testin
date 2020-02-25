using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutlineGen : MonoBehaviour
{
    private Camera _mainCamera;
    private Camera _tempCamera;
    private Material _material;

    public Shader Matte;
    public Shader Outline;

    private void Awake()
    {
        _mainCamera = GetComponent<Camera>();
        _tempCamera = new GameObject("TempCamera").AddComponent<Camera>();
        _tempCamera.enabled = false;

        _material = new Material(Outline);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        _tempCamera.CopyFrom(_mainCamera);
        _tempCamera.clearFlags = CameraClearFlags.Color;
        _tempCamera.backgroundColor = Color.black;
        _tempCamera.cullingMask = 1 << LayerMask.NameToLayer("Outline");

        RenderTexture tempRT = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.Default); //was R8
        tempRT.Create();

        _tempCamera.targetTexture = tempRT;
        _tempCamera.RenderWithShader(Matte, "");

        _material.SetTexture("_SceneTex", source);
        Graphics.Blit(tempRT, destination, _material);

        tempRT.Release();
    }
}
