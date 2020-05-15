using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject lander;
    public Vector2 offset;
    private Vector2 threshold;
    public float speed = 3;
    private Rigidbody2D landerRb;


    // This code to scroll the camera was based on this tutorial
    // https://pressstart.vip/tutorials/2019/11/29/105/mario-2d-camera.html


    void Start()
    {
        lander = GameObject.Find("Lander");
        landerRb = lander.GetComponent<Rigidbody2D>();
        threshold = calcThreshold();
    }


    void FixedUpdate()
    {
        Vector2 follow = lander.transform.position;
        float xDiff = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDiff = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        Vector3 newPos = transform.position;
        if (Mathf.Abs(xDiff) >= threshold.x)
        {
            newPos.x = follow.x;
        }

        //Debug.Log("xDif: " + xDiff.ToString() + ", yDiff: " + yDiff.ToString());
        //Debug.Log("threshold.y: " + threshold.y.ToString());

        if (Mathf.Abs(yDiff) > threshold.y & follow.y > -3f)  // was -2 trying -3
        {
            newPos.y = follow.y;
        }


        float moveSpeed;
        if (landerRb.velocity.magnitude > speed)
            moveSpeed = landerRb.velocity.magnitude;
        else
            moveSpeed = speed;

        transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);

    }

    private Vector3 calcThreshold()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x = t.x - offset.x;
        t.y = t.y - offset.y;
        return t;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 boder = calcThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(boder.x * 2 , boder.y * 2 , 1));
    }

}
