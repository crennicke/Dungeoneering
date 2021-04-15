using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject globalVars;
    public string color = "red";

    // Start is called before the first frame update
    void Start()
    {
        globalVars = GameObject.Find("GlobalVars");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((transform.right + Vector3.right) * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (color.Equals("blue"))
        {
            globalVars.GetComponent<GlobalVars>().SetBlueKey();
        }
        else if (color.Equals("red"))
        {
            Debug.Log("RED IS TOUCHED");
            globalVars.GetComponent<GlobalVars>().SetRedKey();
        }
        else if (color.Equals("purple"))
        {
            globalVars.GetComponent<GlobalVars>().SetPurpleKey();
        }
        else if (color.Equals("green"))
        {
            globalVars.GetComponent<GlobalVars>().SetGreenKey();
        }
        Destroy(gameObject);
    }
}
