using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : MonoBehaviour
{
    public GameObject globalVars;
    public string color = "red";
    public GameObject light;
    private SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        globalVars = GameObject.Find("GlobalVars");
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((transform.right + Vector3.right) * Time.deltaTime * 4);
        transform.Rotate((transform.up + Vector3.up) * Time.deltaTime * 4);
    }

    void OnTriggerEnter(Collider collider)
    {
        sm.sounds[2].Play();
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
