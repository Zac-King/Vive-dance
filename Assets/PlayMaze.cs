using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMaze : MonoBehaviour
{

    [SerializeField] Animation m_anim;
    [SerializeField] AudioSource m_audio;




	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            m_anim.Stop();
            m_anim.Play();

            m_audio.Play();

            LineManager [] pw = GameObject.FindObjectsOfType<LineManager>();
            foreach(LineManager p in pw)
            {
                Destroy(p.gameObject);
            }
        }
		
	}
}
