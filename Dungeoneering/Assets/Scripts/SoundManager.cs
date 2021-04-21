using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] sounds = new AudioSource[10];

    public void PlaySound(int num)
    {
        sounds[num].Play();
    }

}
