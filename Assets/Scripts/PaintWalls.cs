using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWalls : MonoBehaviour
{
    SteamVR_TrackedController m_controller;
    [SerializeField] GameObject m_lineParent;
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
        GameObject segmentParent = Instantiate<GameObject>(m_lineParent);
        segmentParent.transform.localScale = Vector3.one;
        LineManager lm = segmentParent.GetComponent<LineManager>();

        while (m_controller.triggerPressed)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                lm.AddLineNode(hit.point);
            }
            yield return null;
        }
        m_painting = false;
    }
}
