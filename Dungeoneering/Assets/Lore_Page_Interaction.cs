using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lore_Page_Interaction : MonoBehaviour
{

    public GameObject globalVars;
    public string page_num = "1";

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;

    }

    void OnTriggerEnter(Collider collider)
    {
        if (page_num.Equals("1"))
        {
 

        }
        else if (page_num.Equals("2"))
        {


        }
        else if (page_num.Equals("3"))
        {


        }
        else if (page_num.Equals("4"))
        {


        }
        Destroy(gameObject);
    }
}
