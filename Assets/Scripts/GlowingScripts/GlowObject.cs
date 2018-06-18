using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour
{
	public Color GlowColor;
	public float LerpFactor = 10;

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

    private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
		Renderers = GetComponentsInChildren<Renderer>();
        _targetColor = GlowColor;
        m_highlightMaterial = new Material(Shader.Find("StandardGlow"));
    }

    public void GlowMachine()
    {
        for (int i = 0; i < Renderers.Length; i++)
        {
            Renderers[i].material = m_highlightMaterial;
            Renderers[i].material.SetColor("_GlowColor", GlowColor);
        }
    }

    
}
