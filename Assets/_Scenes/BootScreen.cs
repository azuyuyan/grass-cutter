using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BootScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGameDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator StartGameDelay()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(Random.Range(1,6));
    }
}
