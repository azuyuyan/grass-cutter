using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public List<GameObject> weapons=new List<GameObject>();
    public int r;
    public GameObject temp;
    void Start()
    {
        temp.SetActive(false);
        r = Random.Range(0, weapons.Count);
        weapons[r].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
