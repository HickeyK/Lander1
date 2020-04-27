using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D lander;
    public long dryMass = 1000;
    public long fuelLoad = 1000;
    public long thrust = 2500;
    public double gravity = 5d;
    public double verticalSpeed = 0d;
    private DateTime lastTime;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        lander.mass = dryMass + fuelLoad;
        lastTime = DateTime.Now;

        gravity = gravity * -1;
        Debug.Log(gravity);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DateTime currentTime = DateTime.Now;

        // Time since last frame in milliseconds
        double elapsedTime = (currentTime - lastTime).TotalMilliseconds;
        lastTime = currentTime;

        if (Input.GetKey(KeyCode.UpArrow) & fuelLoad > 0)
        {
            fuelLoad -= 2;
            lander.mass = dryMass + fuelLoad;

            // f = ma => a = f/m

            double force = thrust + ((dryMass + fuelLoad) * gravity);

            double a = force / (dryMass + fuelLoad);
            Debug.Log("Accleration : " + a.ToString());

            verticalSpeed = verticalSpeed + (a * (elapsedTime / 1000d));
            lander.velocity = new Vector2(0.0f, (float)verticalSpeed);

        }
        else
        {
            // v = u + at

            verticalSpeed = verticalSpeed + (gravity * (elapsedTime / 1000d));
            //Debug.Log("Vert Speed: " + verticalSpeed.ToString());
            lander.velocity = new Vector2(0.0f, (float)verticalSpeed);
        }
    }
}
