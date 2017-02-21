using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour
{
    [SerializeField] float m_lifespan;
    [SerializeField] bool m_drop = true;
    [SerializeField] private bool m_deflate;
    [SerializeField] private float m_rate;

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
            if (GetComponent<LineRenderer>() != null)
                GetComponent<LineRenderer>().enabled = false;
        }

        while (timer < m_lifespan && m_drop)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        //FindObjectOfType<CountNodes>().RemoveNode();
        if (!m_deflate)
            Destroy(gameObject);
        else
            StartCoroutine(Deflate());
    }

    public IEnumerator Deflate()
    {
        float scale = transform.localScale.x;
        //LineNode ln = GetComponent<LineNode>();

        while (scale > 0)
        {
            scale -= m_rate * Time.deltaTime;
            transform.localScale = (Vector3.one * scale);

            //ln.UpdateWidth();
            yield return null;
        }
        Destroy(gameObject);
    }
}
