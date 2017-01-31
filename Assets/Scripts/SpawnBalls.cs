using UnityEngine;
using System.Collections;

public class SpawnBalls : MonoBehaviour
{
    [SerializeField]
    GameObject m_BouncyBallPrefab;
    SteamVR_TrackedController thisController;
    private bool touchingball = false;

    private void Start()
    {
        thisController = GetComponent<SteamVR_TrackedController>();
    }

    void Update ()
    {
	    if(thisController.triggerPressed && !touchingball)
        {
            GameObject g = Instantiate(m_BouncyBallPrefab);
            g.transform.position = transform.position;

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
