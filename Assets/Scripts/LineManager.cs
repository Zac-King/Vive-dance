using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class LineManager : MonoBehaviour
{
    [SerializeField] List<Vector3> m_line = new List<Vector3>();
    [SerializeField] int m_maxLineSize = 0;
    [SerializeField] float m_delayToLetGo = 0;
    [SerializeField] bool m_letGo = true;

    private float m_timer;
    private LineRenderer m_lineRend;

    private void Awake()
    {
        m_lineRend = GetComponent<LineRenderer>();
        m_timer = m_delayToLetGo;

        if (m_letGo)
            StartCoroutine(LetGoLine());
    }

    public void AddLineNode(Vector3 a_pos)
    {
        if (m_line.Count > m_maxLineSize)
            m_line.RemoveAt(0);

        m_line.Add(a_pos);
        UpdateLine();

        m_timer = m_delayToLetGo;
    }

    private void UpdateLine()
    {
        m_lineRend.numPositions = m_line.Count;
        m_lineRend.SetPositions(m_line.ToArray());
    }

    IEnumerator LetGoLine()
    {
        print("LetGo Hit");
        while(m_timer > 0)
        {
            m_timer -= Time.deltaTime;
            yield return null;
        }

        transform.parent = null;
    }
}
