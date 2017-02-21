using UnityEngine;
using System.Collections;

[RequireComponent (typeof(LineRenderer))]
public class LineNode : MonoBehaviour
{
    private GameObject m_lastNode;
    private LineRenderer m_linerend = new LineRenderer();

    private void Start()
    {
        m_linerend = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        //if (m_lastNode != null)
        //{
        //    m_linerend.enabled = true;
        //    m_linerend.SetPosition(0, m_lastNode.transform.position);
        //    m_linerend.SetPosition(1, transform.position);

        //    m_linerend.startWidth = m_lastNode.transform.localScale.x;
        //    m_linerend.endWidth = transform.localScale.x;
        //}
        //else
        //{
        //    m_linerend.enabled = false;
        //}

    }

    public void SetLastNode(GameObject a_lastNode)
    {
        m_lastNode = a_lastNode;
    }

    public void UpdateWidth()
    {
        if (m_lastNode == null)
        {
            m_linerend.enabled = false;
            return;
        }

        m_linerend.startWidth = m_lastNode.transform.localScale.x;
        m_linerend.endWidth = transform.localScale.x;
    }
}
