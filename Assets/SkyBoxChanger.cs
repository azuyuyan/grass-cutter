using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChanger : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    public int r;
    void Start()
    {
        r=Random.Range(0,materials.Count);
        RenderSettings.skybox = materials[r];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
