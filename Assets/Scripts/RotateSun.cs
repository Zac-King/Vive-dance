using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSun : MonoBehaviour
{
    [SerializeField] float m_speed;

	void FixedUpdate ()
    {
        transform.Rotate(transform.right * m_speed);
	}
}
