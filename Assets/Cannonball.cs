using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float pitch;
    public float yaw;
    public float startvelocity;
    public bool launched = false;
    public Vector3 endpoint;
    public float arrowheadlength;
    public float arrowheadangle;
    public float timer;
    public Vector3 velocity;
    public LineRenderer lineRenderer;
    void FixedUpdate()
    {
        if (!launched)
        {
            drawArrows();
        }
        else
        {
            launchBall();
        }
    }

    void launchBall()
    {
        float x = velocity.x * timer + 500;
        float z = velocity.z * timer + 500;
        float y = 100 + (velocity.y * timer) - (4.9f * timer * timer);

        transform.position = new Vector3(x,y,z);
        timer += 0.02f;

        if (y <= 0)
        {
            launched = false;
        }
        transform.Rotate(0.1f,0.1f,0.1f);
    }

    void drawArrows()
    {
        transform.position = new Vector3(500,100, 500);
        transform.rotation = Quaternion.Euler(new Vector3 (yaw, pitch));
        endpoint = (transform.forward * startvelocity) + transform.position;
        velocity = transform.forward * startvelocity;
        timer = 0f;

        Vector3 direction = endpoint - transform.position;
        Vector3 right = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 + arrowheadangle, 0) * Vector3.forward;
        Vector3 left = Quaternion.LookRotation(direction) * Quaternion.Euler(0, 180 - arrowheadangle, 0) * Vector3.forward;

        lineRenderer.positionCount = 5;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endpoint);
        lineRenderer.SetPosition(2, endpoint + right * arrowheadlength);
        lineRenderer.SetPosition(3, endpoint);
        lineRenderer.SetPosition(4, endpoint + left * arrowheadlength);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Terrain")
        {
            launched = false;
        }
    }
}
