using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    bool redKey = false;
    bool blueKey = false;
    bool purpleKey = false;
    bool greenKey = false;

    public void SetRedKey()
    {
        redKey = true;
    }
    public void SetBlueKey()
    {
        blueKey = true;
    }
    public void SetGreenKey()
    {
        greenKey = true;
    }
    public void SetPurpleKey()
    {
        purpleKey = true;
    }

    public bool AllKeysCollected()
    {
        if(redKey && greenKey && purpleKey && blueKey)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
