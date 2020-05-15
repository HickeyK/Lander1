using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    public float maxLandingSpeed = 0.1f;
    public float maxLandingAngle = 0.1f;
    public LayerMask groundLayer;
    public Camera mainCamera;
    public bool isCrashed;

    private GameObject lander;
    private Rigidbody2D landerRb;
    private bool IsZoomed = false;
    private int score;

    private Text textScore;


    void Start()
    {
        lander = GameObject.Find("Lander");
        landerRb = lander.GetComponent<Rigidbody2D>();
        isCrashed = false;
        textScore = GameObject.Find("Canvas/txtScore").GetComponent<Text>();

    }

    void Update()
    {
        //IsNearGround();
        CheckForZoom();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (!isCrashed)
        {

            if (landerRb.velocity.magnitude > maxLandingSpeed | Mathf.Abs(landerRb.transform.rotation.z) > maxLandingAngle)
            {
                isCrashed = true;
            }
            else
            {
                score = 1000;
            }

            Debug.Log("IsCrashed " + isCrashed.ToString() + " Velocity " + landerRb.velocity.magnitude.ToString() + " Angle" + landerRb.transform.rotation.z.ToString());
            textScore.text = score.ToString();


        }
    }


    //bool IsNearGround()
    //{
    //    Vector2 position = landerRb.transform.position;
    //    Vector2 direction = Vector2.down;
    //    float distance = 0.1f;

    //    Debug.DrawRay(position, new Vector2(0, -0.1f), Color.green);
    //    RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

    //    if (hit.collider != null)
    //    {
    //        if (landerRb.velocity.magnitude > maxLandingSpeed | Mathf.Abs(landerRb.transform.rotation.z) > maxLandingAngle)
    //            Debug.Log("You Crashed: " + landerRb.velocity.magnitude.ToString());
    //        else
    //            Debug.Log("You Landed:" + landerRb.velocity.magnitude.ToString());
    //    }

    //    return false;
    //}

    void ZoomIn(bool action)
    {
        if (action)
        {
            mainCamera.transform.position = new Vector3(landerRb.transform.position.x, landerRb.transform.position.y, mainCamera.transform.position.z);
            mainCamera.orthographicSize = 3;
            IsZoomed = true;
        }
        else
        {
            mainCamera.orthographicSize = 5;
            IsZoomed = false;
        }

    }

    void CheckForZoom()
    {
        Vector2 position = landerRb.transform.position;

        float distance = 2f;
        Vector2 directionDown = Vector2.down * distance;
        Vector2 directionRight45 = (Vector2.down + Vector2.right).normalized * distance;
        Vector2 directionLeft45 = (Vector2.down + Vector2.left).normalized * distance; ;

        //Debug.DrawRay(position, new Vector2(0, -0.1f), Color.green);

        Debug.DrawRay(position, directionDown, Color.green);
        Debug.DrawRay(position, directionLeft45, Color.green);
        Debug.DrawRay(position, directionRight45, Color.green);

        RaycastHit2D hitDown = Physics2D.Raycast(position, directionDown, distance, groundLayer);
        RaycastHit2D hitRight45 = Physics2D.Raycast(position, directionRight45, distance, groundLayer);
        RaycastHit2D hitLeft45 = Physics2D.Raycast(position, directionLeft45, distance, groundLayer);

        if (hitDown.collider != null | hitRight45.collider != null | hitLeft45.collider != null)
        {
            if (!IsZoomed)
                ZoomIn(true);
        }
        else
        {
            if (IsZoomed)
                ZoomIn(false);
        }

    }


}
