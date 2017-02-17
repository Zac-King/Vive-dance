using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayPause : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] Text displayText;

    public void PlayorPauseAnimation()
    {
        anim.enabled = !anim.enabled;

        if (anim.enabled)
            displayText.text = "Pause";
        else
            displayText.text = "Play";
    }
}
