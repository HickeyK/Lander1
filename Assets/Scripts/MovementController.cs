
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D lander;
    public long dryMass;
    public long fuelLoad;
    public long thrust;
    public Animator animator;
    public int coordinateConversionFactor;

    public double verticalSpeed = 0d;



    private DateTime lastTime;

    private Text textAltitude;
    private Text textVSpeed;



    // Start is called before the first frame update
    void Start()
    {

        lander.mass = dryMass + fuelLoad;
        lastTime = DateTime.Now;

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Debug.Log(camDistance);
        Vector2 bottomCorner = Camera.main.ViewportToScreenPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToScreenPoint(new Vector3(1, 1, camDistance));

        Debug.Log(bottomCorner.x);
        Debug.Log(topCorner.x);
        Debug.Log(bottomCorner.y);
        Debug.Log(topCorner.y);


        textAltitude = GameObject.Find("Canvas/txtAltitude").GetComponent<Text>();
        textVSpeed = GameObject.Find("Canvas/txtHSpeed").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DateTime currentTime = DateTime.Now;

        // Time since last frame in milliseconds
        double elapsedTime = (currentTime - lastTime).TotalMilliseconds;
        lastTime = currentTime;

        if (lander.transform.position.x < -9)
        {
            var newPos = lander.transform.position;
            newPos.x = 9;
            lander.transform.position = newPos;
        }
        else if (lander.transform.position.x > 9)
        {
            var newPos = lander.transform.position;
            newPos.x = -9;
            lander.transform.position = newPos;
        }



        if (Input.GetKey(KeyCode.UpArrow) & fuelLoad > 0)
        {
            fuelLoad -= 2;
            lander.mass = dryMass + fuelLoad;

            animator.SetBool("IsThrusting", true);
            lander.AddForce(transform.up * thrust, ForceMode2D.Force);

        }
        else
        {
            animator.SetBool("IsThrusting", false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            lander.rotation = lander.rotation - 1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            lander.rotation = lander.rotation + 1f;
        }


        textAltitude.text = ToMoonCoordinates(lander.transform.position.y);
        textVSpeed.text = ToMoonCoordinates(lander.velocity.y * -1);

    }


    string ToMoonCoordinates(float value)
    {
        return String.Format("{0:0}", value * coordinateConversionFactor);
    }
}
