using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShow : MonoBehaviour
{
    Animator m_anim;
    bool paused = false;

    AudioSource m_audio;

	// Use this for initialization
	void Start ()
    {
        m_anim = GetComponent<Animator>();
        m_audio = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            m_anim.SetTrigger("Play");

            LineManager[] pw = GameObject.FindObjectsOfType<LineManager>();
            foreach (LineManager p in pw)
            {
                Destroy(p.gameObject);
            }
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            if (paused)
                m_anim.speed = 1;

            else
            {
                m_anim.speed = 0;
            }

            paused = !paused;
        }


    }
}
