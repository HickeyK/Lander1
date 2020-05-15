using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDraw : MonoBehaviour
{

    public GameObject linePrefab;
    public GameObject currentLine;
    public GameObject myCamera;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;


    private List<Vector2> linePointList;


    // Start is called before the first frame update
    void Start()
    {
        linePointList = new List<Vector2>();

        CreateLineFromArray();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) ) //&& fingerPositions.Count == 0)
        {
            CreateLine();
        }

        if (Input.GetMouseButton(0) && linePointList.Count > 0)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePosition, linePointList[linePointList.Count - 1]) > 0.1f)
            {
                ExtendLine(mousePosition);
            }

        }


        if (Input.GetMouseButtonDown(2))
        {
            foreach (var p in linePointList)
            {
                Debug.Log("x= " + p.x.ToString() +" y= " + p.y.ToString());
            }
        }
    }


    void ExtendLine(Vector2 newPoint)
    {
        linePointList.Add(newPoint);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPoint);
        edgeCollider.points = linePointList.ToArray();

    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        currentLine.layer = 2;
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        linePointList.Clear();

        linePointList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        linePointList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        lineRenderer.SetPosition(0, linePointList[0]);
        lineRenderer.SetPosition(1, linePointList[1]);

        edgeCollider.points = linePointList.ToArray();
    }


    void CreateLineFromArray()
    {

        //linePointList.Add(new Vector2(-9f, -3.8f));
        //linePointList.Add(new Vector2(-8f, -3.8f));
        //linePointList.Add(new Vector2(-7f, -2.0f));
        //linePointList.Add(new Vector2(-6f, -2.0f));
        //linePointList.Add(new Vector2(-5f, -3.8f));
        //linePointList.Add(new Vector2(-4f, -3.8f));
        //linePointList.Add(new Vector2(-3f, -2.0f));
        //linePointList.Add(new Vector2(-2f, -2.0f));
        //linePointList.Add(new Vector2(-1f, -3.8f));
        //linePointList.Add(new Vector2(0f, -3.8f));
        //linePointList.Add(new Vector2(1f, -2.0f));
        //linePointList.Add(new Vector2(2f, -2.0f));
        //linePointList.Add(new Vector2(3f, -3.8f));
        //linePointList.Add(new Vector2(4f, -3.8f));
        //linePointList.Add(new Vector2(5f, -2.0f));
        //linePointList.Add(new Vector2(6f, -2.0f));
        //linePointList.Add(new Vector2(7f, -3.8f));
        //linePointList.Add(new Vector2(8f, -3.8f));
        //linePointList.Add(new Vector2(9f, -3.8f));

        linePointList.Add(new Vector2(-7.83333333333333f, -1.66666666666667f));
        linePointList.Add(new Vector2(-7.777f, -1.96233333333333f));
        linePointList.Add(new Vector2(-7.759f, -2.12833333333333f));
        linePointList.Add(new Vector2(-7.71166666666667f, -2.303f));
        linePointList.Add(new Vector2(-7.528f, -2.404f));
        linePointList.Add(new Vector2(-7.48366666666667f, -2.60233333333333f));
        linePointList.Add(new Vector2(-7.42733333333333f, -2.709f));
        linePointList.Add(new Vector2(-7.30866666666667f, -2.804f));
        linePointList.Add(new Vector2(-7.18133333333333f, -2.804f));
        linePointList.Add(new Vector2(-7.054f, -2.68233333333333f));
        linePointList.Add(new Vector2(-6.965f, -2.53733333333333f));
        linePointList.Add(new Vector2(-6.83766666666667f, -2.392f));
        linePointList.Add(new Vector2(-6.719f, -2.28533333333333f));
        linePointList.Add(new Vector2(-6.60366666666667f, -2.13733333333333f));
        linePointList.Add(new Vector2(-6.524f, -2.035f));
        linePointList.Add(new Vector2(-6.40533333333333f, -1.96066666666667f));
        linePointList.Add(new Vector2(-6.281f, -1.81266666666667f));
        linePointList.Add(new Vector2(-6.15066666666667f, -1.78f));
        linePointList.Add(new Vector2(-6.05266666666667f, -1.706f));
        linePointList.Add(new Vector2(-5.91633333333333f, -1.706f));
        linePointList.Add(new Vector2(-5.85433333333333f, -1.7f));
        linePointList.Add(new Vector2(-5.703f, -1.718f));
        linePointList.Add(new Vector2(-5.702f, -1.81566666666667f));
        linePointList.Add(new Vector2(-5.67633333333333f, -1.90766666666667f));
        linePointList.Add(new Vector2(-5.59066666666667f, -2.01433333333333f));
        linePointList.Add(new Vector2(-5.56066666666667f, -2.103f));
        linePointList.Add(new Vector2(-5.47433333333333f, -2.19766666666667f));
        linePointList.Add(new Vector2(-5.44833333333333f, -2.30733333333333f));
        linePointList.Add(new Vector2(-5.35933333333333f, -2.405f));
        linePointList.Add(new Vector2(-5.235f, -2.405f));
        linePointList.Add(new Vector2(-5.17866666666667f, -2.257f));
        linePointList.Add(new Vector2(-5.078f, -2.16233333333333f));
        linePointList.Add(new Vector2(-4.97433333333333f, -2.20366666666667f));
        linePointList.Add(new Vector2(-4.89133333333333f, -2.30133333333333f));
        linePointList.Add(new Vector2(-4.83333333333333f, -2.5f));
        linePointList.Add(new Vector2(-4.675f, -2.61266666666667f));
        linePointList.Add(new Vector2(-4.56233333333333f, -3.18433333333333f));
        linePointList.Add(new Vector2(-4.56833333333333f, -3.31466666666667f));
        linePointList.Add(new Vector2(-4.444f, -3.40666666666667f));
        linePointList.Add(new Vector2(-4.20666666666667f, -3.40666666666667f));
        linePointList.Add(new Vector2(-3.811f, -3.00066666666667f));
        linePointList.Add(new Vector2(-3.75466666666667f, -2.9f));
        linePointList.Add(new Vector2(-3.63633333333333f, -2.85566666666667f));
        linePointList.Add(new Vector2(-3.527f, -2.40066666666667f));
        linePointList.Add(new Vector2(-3.394f, -2.35033333333333f));
        linePointList.Add(new Vector2(-3.143f, -2.02533333333333f));
        linePointList.Add(new Vector2(-3.01266666666667f, -1.709f));
        linePointList.Add(new Vector2(-2.729f, -1.298f));
        linePointList.Add(new Vector2(-2.60766666666667f, -1.298f));
        linePointList.Add(new Vector2(-2.48966666666667f, -1.18866666666667f));
        linePointList.Add(new Vector2(-2.265f, -0.902f));
        linePointList.Add(new Vector2(-2.14966666666667f, -0.446666666666667f));
        linePointList.Add(new Vector2(-2.123f, -0.000333333333333297f));
        linePointList.Add(new Vector2(-2.03433333333333f, 0.236f));
        linePointList.Add(new Vector2(-1.922f, 0.301333333333333f));
        linePointList.Add(new Vector2(-1.83333333333333f, 0.5f));
        linePointList.Add(new Vector2(-1.69433333333333f, 0.5f));
        linePointList.Add(new Vector2(-1.665f, 0.395666666666667f));
        linePointList.Add(new Vector2(-1.54966666666667f, 0.395666666666667f));
        linePointList.Add(new Vector2(-1.51433333333333f, 0.286333333333333f));
        linePointList.Add(new Vector2(-1.44333333333333f, 0.286333333333333f));
        linePointList.Add(new Vector2(-1.29266666666667f, 0.153333333333334f));
        linePointList.Add(new Vector2(-1.23033333333333f, -0.0566666666666666f));
        linePointList.Add(new Vector2(-1.056f, -0.157f));
        linePointList.Add(new Vector2(-0.893333333333333f, -0.603333333333333f));
        linePointList.Add(new Vector2(-0.657f, -0.707f));
        linePointList.Add(new Vector2(-0.642333333333333f, -0.807333333333333f));
        linePointList.Add(new Vector2(-0.435333333333333f, -1.112f));
        linePointList.Add(new Vector2(-0.32f, -1.112f));
        linePointList.Add(new Vector2(-0.299333333333333f, -1.41033333333333f));
        linePointList.Add(new Vector2(-0.210666666666667f, -1.68533333333333f));
        linePointList.Add(new Vector2(-0.207666666666666f, -1.79766666666667f));
        linePointList.Add(new Vector2(-0.0983333333333332f, -1.79766666666667f));
        linePointList.Add(new Vector2(-0.0626666666666669f, -1.904f));
        linePointList.Add(new Vector2(0f, -2f));
        linePointList.Add(new Vector2(0.0936666666666666f, -2.244f));
        linePointList.Add(new Vector2(0.256333333333333f, -2.40666666666667f));
        linePointList.Add(new Vector2(0.283f, -2.76133333333333f));
        linePointList.Add(new Vector2(0.333333333333333f, -3f));
        linePointList.Add(new Vector2(0.362666666666667f, -3.13066666666667f));
        linePointList.Add(new Vector2(0.478f, -3.311f));
        linePointList.Add(new Vector2(0.593333333333333f, -3.311f));
        linePointList.Add(new Vector2(0.666666666666667f, -3.55033333333333f));
        linePointList.Add(new Vector2(0.933333333333334f, -3.79866666666667f));
        linePointList.Add(new Vector2(1.84066666666667f, -3.79866666666667f));
        linePointList.Add(new Vector2(1.90266666666667f, -3.49433333333333f));
        linePointList.Add(new Vector2(2.04166666666667f, -3.27833333333333f));
        linePointList.Add(new Vector2(2.07433333333333f, -3.101f));
        linePointList.Add(new Vector2(2.14533333333333f, -3.101f));
        linePointList.Add(new Vector2(2.21333333333333f, -2.89433333333333f));
        linePointList.Add(new Vector2(2.40833333333333f, -2.699f));
        linePointList.Add(new Vector2(2.53833333333333f, -2.67833333333333f));
        linePointList.Add(new Vector2(2.63566666666667f, -2.60166666666667f));
        linePointList.Add(new Vector2(2.769f, -2.60166666666667f));
        linePointList.Add(new Vector2(2.93433333333333f, -3.039f));
        linePointList.Add(new Vector2(2.95233333333333f, -3.15733333333333f));
        linePointList.Add(new Vector2(3.218f, -3.40266666666667f));
        linePointList.Add(new Vector2(3.27733333333333f, -3.60066666666667f));
        linePointList.Add(new Vector2(3.45466666666667f, -3.704f));
        linePointList.Add(new Vector2(3.91866666666667f, -3.722f));
        linePointList.Add(new Vector2(4.14633333333333f, -3.79866666666667f));
        linePointList.Add(new Vector2(4.59266666666667f, -3.79866666666667f));
        linePointList.Add(new Vector2(4.711f, -3.42933333333333f));
        linePointList.Add(new Vector2(4.711f, -3.107f));
        linePointList.Add(new Vector2(4.832f, -3.107f));
        linePointList.Add(new Vector2(4.88833333333333f, -2.89733333333333f));
        linePointList.Add(new Vector2(5.05366666666667f, -2.72f));
        linePointList.Add(new Vector2(5.09533333333333f, -2.569f));
        linePointList.Add(new Vector2(5.16666666666667f, -2.5f));
        linePointList.Add(new Vector2(5.28433333333333f, -2.5f));
        linePointList.Add(new Vector2(5.39066666666667f, -2.049f));
        linePointList.Add(new Vector2(5.5f, -2f));
        linePointList.Add(new Vector2(5.62433333333333f, -2.09333333333333f));
        linePointList.Add(new Vector2(5.846f, -2.09333333333333f));
        linePointList.Add(new Vector2(5.96733333333333f, -2.00166666666667f));
        linePointList.Add(new Vector2(6.02333333333333f, -1.73866666666667f));
        linePointList.Add(new Vector2(6.08533333333333f, -1.54033333333333f));
        linePointList.Add(new Vector2(6.20366666666667f, -1.496f));
        linePointList.Add(new Vector2(6.23333333333333f, -1.40166666666667f));
        linePointList.Add(new Vector2(6.42233333333333f, -1.20333333333333f));
        linePointList.Add(new Vector2(6.56433333333333f, -1.20333333333333f));
        linePointList.Add(new Vector2(6.579f, -1.28933333333333f));
        linePointList.Add(new Vector2(6.709f, -1.28933333333333f));
        linePointList.Add(new Vector2(6.721f, -1.39866666666667f));
        linePointList.Add(new Vector2(6.721f, -1.66666666666667f));


        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        lineRenderer.renderingLayerMask = 0;

        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        int i = 0;
        foreach (var p in linePointList)
        {
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i++, p);
        }

        edgeCollider.points = linePointList.ToArray();

        myCamera.GetComponent<loopBackground>().levels[0] = currentLine;
        myCamera.GetComponent<loopBackground>().activate();

    }

}
