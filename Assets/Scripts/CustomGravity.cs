using UnityEngine;
using System.Collections;

[RequireComponent(typeof (Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    private Rigidbody m_rigidBod;

    [SerializeField] float m_gravityMod = 0;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        m_rigidBod = GetComponent<Rigidbody>(); // store object's rigidbody
        m_rigidBod.useGravity = false;
    }

    /// <summary>
    /// 
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 f = new Vector3(0, -9.8f, 0) * m_gravityMod;    // our custom gravity force
        m_rigidBod.AddForce(f);     // then that force is added to the objects rigidbody
    }
}
