using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour
{
    [SerializeField] float m_lifespan;

    private void Awake()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        float timer = 0;
        while(timer< m_lifespan)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().enabled = true;
        timer = m_lifespan /2;
        while (timer < m_lifespan)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        //timer = 0;
        //float scale = 1;
        //while(scale > 0)
        //{
        //    scale -= Time.deltaTime;
        //    transform.localScale = new Vector3(1,1,1) * scale;
        //    yield return null;
        //}
        Destroy(gameObject);
    }
}
