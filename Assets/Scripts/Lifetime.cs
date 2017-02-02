using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour
{
    [SerializeField] float m_lifespan;
    [SerializeField] bool m_drop = true;

    private void Awake()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        float timer = 0;

        while (timer< m_lifespan)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        if (m_drop)
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Collider>().enabled = true;
            timer = m_lifespan / 2;   
        }

        while (timer < m_lifespan && m_drop)
        {
            timer += Time.deltaTime;
            yield return null;
        }


        Destroy(gameObject);
    }
}
