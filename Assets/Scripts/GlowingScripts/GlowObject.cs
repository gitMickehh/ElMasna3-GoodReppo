using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour
{
    public Color GlowColor;
    public float LerpFactor = 10;
    public Material machineMaterial;

    public Renderer[] Renderers
    {
        get;
        private set;
    }

    public Color CurrentColor
    {
        get { return _currentColor; }
    }

    //private List<Material> _materials = new List<Material>();
    public Material m_highlightMaterial;
    //try making the material and referencing it here

    private Color _currentColor;
    private Color _targetColor;

    //private void OnEnable()
    //{
    //    m_highlightMaterial = new Material(Shader.Find("StandardGlow"));
    //}
    void Start()
    {
        Renderers = GetComponentsInChildren<Renderer>();
        _targetColor = GlowColor;
        
    }

    public void GlowMachine()
    {
        for (int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].material = m_highlightMaterial;
            Renderers[i].material.mainTexture = machineMaterial.mainTexture;
            Renderers[i].material.SetColor("_GlowColor", GlowColor);

        }
    }

    public void StopGlowing()
    {
        for (int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].material.SetColor("_GlowColor", Color.black);
            Renderers[i].material = machineMaterial;
        }
    }


}
