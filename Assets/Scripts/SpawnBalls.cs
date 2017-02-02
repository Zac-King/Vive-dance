using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField] GameObject m_BallPrefab;
    [SerializeField] GameObject m_storedPrefab1;
    [SerializeField] GameObject m_storedPrefab2;
    [SerializeField] GameObject m_storedPrefab3;

    private SteamVR_TrackedController thisController;
    private bool touchingball = false;

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
