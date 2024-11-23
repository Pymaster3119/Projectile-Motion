using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class uimanager : MonoBehaviour
{
    public Cannonball ball;
    public TMPro.TextMeshProUGUI firebuttontext;
    public Slider pitch;
    public Slider yaw;
    public Slider speed;
    void Update()
    {
        ball.pitch = -pitch.value;
        ball.yaw = -yaw.value;
        ball.startvelocity = speed.value;
        if (!ball.launched)
        {
            firebuttontext.text = "Fire!";
        }
        else
        {
            
            firebuttontext.text = "Stop";
        }

    }
    public void Fire()
    {
        if (ball.launched)
        {
            ball.launched = false;
        }
        else
        {
            ball.launched = true;
        }
    }
}
