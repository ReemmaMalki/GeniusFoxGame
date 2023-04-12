using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTheQus : MonoBehaviour
{
    public GameObject Uiobject;
    public GameObject Cube;

    // Start is called before the first frame update
    void Start()
    {
        Uiobject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Uiobject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        Uiobject.SetActive(false);
        
    }
}
