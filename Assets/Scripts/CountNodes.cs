using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountNodes : MonoBehaviour
{
    int m_nodeCount = 0;
    [SerializeField] Text m_displayText;

    public void AddNode()
    {
        m_nodeCount += 1;
        UpdateDisplay();
    }

    public void RemoveNode()
    {
        m_nodeCount -= 1;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        m_displayText.text = m_nodeCount.ToString(); 
    }
}
