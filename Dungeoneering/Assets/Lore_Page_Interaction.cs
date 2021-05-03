using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lore_Page_Interaction : MonoBehaviour
{

    public GameObject globalVars;
    public string page_num = "1";

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public Text Page1;

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
        else if (page_num.Equals("5"))
        {


        }
        Destroy(gameObject);
    }


}

/*
 Text for notes: 
 
1 - I have no idea if anyone will find this but I’m writing some notes in hopes that it might help someone else. I’d heard rumors about something weird going on around here, so I went looking and I guess I found it.  

I don’t know where I am, but what I do know is that this place is dangerous. 

You must be careful.	 

 

2 - The last thing I remember was going for a walk in the woods near my house. I was stressed and I couldn’t sleep, so I thought it might help.  

Next thing I know I was waking up here.  

I was looking for this place, drawing attention to it, so it would only make sense I would draw 	the attention of whoever it is that’s been bringing people here.  

 

3 - I just don’t get why this structure is here. It doesn’t look particularly old or worn, so it’s not like these are real ruins. 

But then why is this here? Did someone make this themselves just so they could mess with 	people? 

 

4 - People have been disappearing, that’s why I started looking into what was happening here. I thought it was just some people messing around, or at least that’s what I hoped. But after seeing the size of this place I think there’s something bigger going on here, either that or whoever made this place is just very committed. 

 

5 - I think I know how to get out of here, but it’s going to take some work. I was never very good at puzzles or anything so I’m not sure I’ll be able to make it. But to anyone else who comes through here and sees this note, good luck. 

 */