using UnityEngine;
using System.Collections;

public class SpawnLine : MonoBehaviour
{
    [SerializeField]
    GameObject m_nodePrefab;
    private GameObject m_lineParent;
    private SteamVR_TrackedController m_controller;
    private bool m_drawing = false;

    private void Start()
    {
        m_controller = GetComponent<SteamVR_TrackedController>();
    }

    private void Update()
    {
        if(m_controller.triggerPressed && !m_drawing)
        {
            m_drawing = true;
            StartCoroutine(DrawLineSegment());
        }
    }


    IEnumerator DrawLineSegment()
    {
        GameObject segmentParent = Instantiate<GameObject>(new GameObject("Line Segmnet"));
        GameObject lastNode = null;

        while(m_controller.triggerPressed)
        {
            GameObject g = Instantiate<GameObject>(m_nodePrefab);
            g.transform.position = transform.position;
            g.transform.parent = segmentParent.transform;
            g.GetComponent<LineRenderer>().SetPosition(0, g.transform.position);
            g.GetComponent<LineRenderer>().SetPosition(1, g.transform.position);
            if (lastNode != null)
            {
                //lastNode.GetComponent<LineRenderer>().SetPositions(new Vector3[]{lastNode.transform.position, g.transform.position });
                lastNode.GetComponent<LineRenderer>().SetPosition(1, g.transform.position);
            }
            lastNode = g;
            yield return null;
        }

        m_drawing = true;
    }

}
