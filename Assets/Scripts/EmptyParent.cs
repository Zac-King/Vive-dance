using UnityEngine;
using System.Collections;

public class EmptyParent : MonoBehaviour {
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.childCount < 1)
            Destroy(gameObject);
	}
}
