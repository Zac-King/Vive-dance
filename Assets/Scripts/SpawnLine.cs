using UnityEngine;
using System.Collections;

public class SpawnLine : MonoBehaviour
{
    [SerializeField] GameObject m_nodePrefab;
    [SerializeField] GameObject m_camRig;
    [SerializeField] GameObject m_trail;
    private GameObject m_lineParent;
    private GameObject m_lastNode;  
    private SteamVR_TrackedController m_controller;
    private bool m_drawing = false;

    // Test //
    [SerializeField] GameObject m_lineManager;

    private void Start()
    {
        m_controller = GetComponent<SteamVR_TrackedController>();
    }

    private void Update()
    {
        if(m_controller.triggerPressed && !m_drawing)
        {
            m_drawing = true;
            //StartCoroutine(DrawLineSegment());
            StartCoroutine(DrawNewLine());
        }
    }

    private GameObject MakeNewNode(GameObject a_parent)
    {
        GameObject g = Instantiate<GameObject>(m_nodePrefab);
        g.transform.position = transform.position;
        g.transform.parent = a_parent.transform;
        g.GetComponent<LineRenderer>().SetPosition(0, g.transform.position);
        g.GetComponent<LineRenderer>().SetPosition(1, g.transform.position);

        return g;
    }

    IEnumerator DrawLineSegment()
    {
        GameObject segmentParent = new GameObject("LineSegment");
        segmentParent.transform.parent = m_camRig.transform;
        segmentParent.AddComponent<EmptyParent>();
        GameObject lastNode = null;

        while(m_controller.triggerPressed)
        {
            GameObject g = MakeNewNode(segmentParent);
            if (lastNode != null)
            {
                lastNode.GetComponent<LineRenderer>().SetPosition(1, g.transform.position);
                g.GetComponent<LineNode>().SetLastNode(lastNode);
            }
            lastNode = g;

            GameObject g2 = Instantiate<GameObject>(m_trail);
            g2.transform.position = transform.position;
            //g2.GetComponent<LineRenderer>().SetPosition(0, g.transform.position);
            //g2.GetComponent<LineRenderer>().SetPosition(1, g.transform.position);


            yield return null;
        }

        m_drawing = false;
    }

    IEnumerator DrawNewLine()
    {
        GameObject segmentParent = Instantiate<GameObject>(m_lineManager);
        segmentParent.transform.parent = m_camRig.transform;
        segmentParent.transform.localPosition = Vector3.zero;
        segmentParent.transform.localScale = Vector3.one;
        LineManager lm = segmentParent.GetComponent<LineManager>();

        while (m_controller.triggerPressed)
        {
            lm.AddLineNode(transform.localPosition - transform.parent.transform.localPosition);
            yield return null;
        }
        m_drawing = false;
    }
}