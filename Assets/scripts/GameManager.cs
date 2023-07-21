using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Transform ballPosition;
    Plane plane = new Plane(Vector3.forward,0);
    public Transform target;
    public float ballSpeed;
    private GameObject newBall;
    bool ballReady;
    void Start()
    {
        InitBall();
    }

    void Update()
    {


        Vector3 dir = target.position - ball.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            newBall.GetComponent<Animator>().enabled = false;
        }
        if (Input.GetMouseButtonUp(0)&& ballReady)
        {
            newBall.GetComponent<Rigidbody>().AddForce(dir * ballSpeed, ForceMode.Impulse);

            ballReady = false;
            Invoke(nameof(InitBall), 1);
        }

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            target.position = new Vector3(point.x, point.y,7.5f);
        }
    }
    void InitBall()
    {
        newBall = Instantiate(ball, ballPosition);
        ballReady = true;
    }
}
