using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDraw : MonoBehaviour
{

    public GameObject linePrefab;
    private GameObject currentLine;

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

        linePointList.Add(new Vector2(-9f, -3.8f));
        linePointList.Add(new Vector2(-8f, -3.8f));
        linePointList.Add(new Vector2(-7f, -2.0f));
        linePointList.Add(new Vector2(-6f, -2.0f));
        linePointList.Add(new Vector2(-5f, -3.8f));
        linePointList.Add(new Vector2(-4f, -3.8f));
        linePointList.Add(new Vector2(-3f, -2.0f));
        linePointList.Add(new Vector2(-2f, -2.0f));
        linePointList.Add(new Vector2(-1f, -3.8f));
        linePointList.Add(new Vector2(0f, -3.8f));
        linePointList.Add(new Vector2(1f, -2.0f));
        linePointList.Add(new Vector2(2f, -2.0f));
        linePointList.Add(new Vector2(3f, -3.8f));
        linePointList.Add(new Vector2(4f, -3.8f));
        linePointList.Add(new Vector2(5f, -2.0f));
        linePointList.Add(new Vector2(6f, -2.0f));
        linePointList.Add(new Vector2(7f, -3.8f));
        linePointList.Add(new Vector2(8f, -3.8f));
        linePointList.Add(new Vector2(9f, -3.8f));

        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        int i = 0;
        foreach (var p in linePointList)
        {
            lineRenderer.positionCount = i + 1;
            lineRenderer.SetPosition(i++, p);
        }

        edgeCollider.points = linePointList.ToArray();

    }

}
