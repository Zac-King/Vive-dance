using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class LineManager : MonoBehaviour
{
    [SerializeField] List<Vector3> m_line = new List<Vector3>();
    [SerializeField] int m_maxLineSize = 0;
    private LineRenderer m_lineRend;

    private void Awake()
    {
        m_lineRend = GetComponent<LineRenderer>();
    }

    public void AddLineNode(Vector3 a_pos)
    {
        if (m_line.Count > m_maxLineSize)
            m_line.RemoveAt(0);

        m_line.Add(a_pos);

        UpdateLine();
    }

    private void UpdateLine()
    {

        print(m_lineRend.enabled);

        m_lineRend.numPositions = m_line.Count;
        m_lineRend.SetPositions(m_line.ToArray());
    }
}
