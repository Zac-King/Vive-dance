using UnityEngine;
using System.Collections;

public class RandomScale : MonoBehaviour
{
    [SerializeField] float m_min = 0;
    [SerializeField] float m_max = 0;
	// Use this for initialization
	void Start ()
    {
        float rs = Random.Range(m_min, m_max);

        transform.localScale = Vector3.one * rs;
	}
	
}
