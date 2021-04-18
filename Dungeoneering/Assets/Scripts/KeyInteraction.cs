using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject globalVars;
    public string color = "red";
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        globalVars = GameObject.Find("GlobalVars");
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((transform.right + Vector3.right) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (color.Equals("blue"))
        {
            globalVars.GetComponent<GlobalVars>().SetBlueKey();
            light.SetActive(true);
        }
        else if (color.Equals("red"))
        {
            globalVars.GetComponent<GlobalVars>().SetRedKey();
            light.SetActive(true);
        }
        else if (color.Equals("purple"))
        {
            globalVars.GetComponent<GlobalVars>().SetPurpleKey();
            light.SetActive(true);
        }
        else if (color.Equals("green"))
        {
            globalVars.GetComponent<GlobalVars>().SetGreenKey();
            light.SetActive(true);
        }
        Destroy(gameObject);
    }
}
