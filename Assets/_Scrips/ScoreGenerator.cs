using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGenerator : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    public int meter;
    public GameObject cube;
    public float yValue;
    public Transform instantiatePos;
    public int materialValue;
    void Start()
    {
        for (int i = 0; i < 200; ++i)
        {
            meter += 10;
            yValue += 4;
            GameObject go= Instantiate(cube,instantiatePos);
            go.transform.localPosition=new Vector3(0,yValue, 14.15f);
            go.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text=meter.ToString();

            if (materialValue < materials.Count)
            {
                go.GetComponent<MeshRenderer>().material = materials[materialValue];
                materialValue += 1;
            }
            else
            {
                materialValue = 1;
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
