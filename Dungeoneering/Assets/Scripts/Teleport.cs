using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with:");
        Debug.Log(gameObject.name);
        Debug.Log(other.name);
        gameObject.GetComponent<SceneLoader>().LoadScene();
    }
}
