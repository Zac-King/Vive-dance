using UnityEngine;
using System.Collections;

public class SpawnLine : MonoBehaviour
{
    [SerializeField] GameObject m_nodePrefab;

    private GameObject m_lineParent;
    private GameObject m_lastNode;  
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
            yield return null;
        }

        m_drawing = false;
    }

}