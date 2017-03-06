using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShow : MonoBehaviour
{
    Animator m_anim;

	// Use this for initialization
	void Start ()
    {
        m_anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_anim.SetTrigger("Play");
        }
    }
}
