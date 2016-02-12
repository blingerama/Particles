using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    // Use this for initialization
    void OnTriggerEnter(Collider hit) {

        Debug.Log(hit.gameObject.name);

    }
}
