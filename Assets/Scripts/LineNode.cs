using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class LineNode : MonoBehaviour
{
    private GameObject m_lastNode;
    private LineRenderer m_linerend = new LineRenderer();

    public void SetLastNode(GameObject a_lastNode)
    {
        m_lastNode = a_lastNode;
    }

    private void Start()
    {
        m_linerend = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (m_lastNode == null)
            return;

        m_linerend.SetPosition(0, m_lastNode.transform.position);
        m_linerend.SetPosition(1, transform.position);
        m_linerend.SetWidth(m_lastNode.transform.localScale.x, transform.localScale.x);
    }
}
