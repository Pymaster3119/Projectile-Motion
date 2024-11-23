using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroll : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 rot;
    public float scale;
    public GameObject target;
    public GameObject camerago;
    public float zoom;
    public float zoom_scale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += new Vector3(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal")) * scale * Time.deltaTime;
        transform.rotation = Quaternion.Euler(rot);
        transform.position = target.transform.position;
        camerago.transform.localPosition = new Vector3(0, zoom/Mathf.Sqrt(2), -zoom/Mathf.Sqrt(2));
        if (Input.GetKey(KeyCode.Q))
        {
            zoom += zoom_scale * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            zoom -= zoom_scale * Time.deltaTime;
        }
    }
}
