using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<SceneLoader>().LoadScene();
    }
}
