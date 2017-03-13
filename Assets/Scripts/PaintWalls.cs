using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWalls : MonoBehaviour
{
    SteamVR_TrackedController m_controller;
    [SerializeField] GameObject m_lineParent;
    [SerializeField] float m_nodeSegmentMax = 4;
    bool m_painting = false;

    private void Awake()
    {
        m_controller = GetComponent<SteamVR_TrackedController>();
    }

    private void Update()
    {
        if (m_controller.triggerPressed && !m_painting)
        {
            m_painting = true;
            StartCoroutine(PaintWallLine());
        } 
    }

    IEnumerator PaintWallLine()
    {
        while (m_controller.triggerPressed)
        {
            GameObject segmentParent = Instantiate<GameObject>(m_lineParent);
            segmentParent.transform.localScale = Vector3.one;
            LineManager lm = segmentParent.GetComponent<LineManager>();
            Vector3 lastpoint = Vector3.zero;

            bool continueline = true;
            bool firstHit = true;
            RaycastHit hit;
            while (continueline && m_controller.triggerPressed)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, 25f) && (Vector3.Distance(hit.point, lastpoint) <= m_nodeSegmentMax || firstHit))
                {
                    lm.AddLineNode(hit.point);
                    lastpoint = hit.point;
                    firstHit = false;
                }
                
                else
                    continueline = false;

                yield return null;
            }


                yield return null;
        }
        m_painting = false;
    }
}
