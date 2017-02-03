using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour
{
    //test
    [SerializeField] CountNodes m_nodeCount;

    private SteamVR_TrackedController thisController;
    private bool touchingball = false;

    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] GameObject m_storedPrefab1;
    [SerializeField] GameObject m_storedPrefab2;
    [SerializeField] GameObject m_storedPrefab3;
    [SerializeField] GameObject m_storedPrefab4;
    [SerializeField] GameObject m_storedPrefab5;
    [SerializeField] GameObject m_storedPrefab6;

    private void Start()
    {
        thisController = GetComponent<SteamVR_TrackedController>();
    }

    void Update ()
    {
	    if(thisController.triggerPressed && !touchingball)
        {
            GameObject g = Instantiate(m_BallPrefab);
            g.transform.position = transform.position;
            m_nodeCount.AddNode();
        }
	}

    public void ChangeSpawnObject(int index)
    {
        switch(index)
        {
            case 1:
                m_BallPrefab = m_storedPrefab1;
                break;
            case 2:
                m_BallPrefab = m_storedPrefab2;
                break;
            case 3:
                m_BallPrefab = m_storedPrefab3;
                break;
            case 4:
                m_BallPrefab = m_storedPrefab4;
                break;
            case 5:
                m_BallPrefab = m_storedPrefab5;
                break;
            case 6:
                m_BallPrefab = m_storedPrefab6;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        touchingball = true;
    }

    private void OnTriggerExit(Collider other)
    {
        touchingball = false;
    }
}
