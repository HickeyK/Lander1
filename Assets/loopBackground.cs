using UnityEngine;

public class loopBackground : MonoBehaviour
{

    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;


    // This code to create an endless background was based on the tutorial below
    // https://pressstart.vip/tutorials/2019/04/15/93/endless-2d-background.html


    public void activate()
    {

        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        levels[1] = GameObject.Find("StarQuad");

        foreach(GameObject o in levels)
        {
            loadChildObjects(o);
        }

    }


    void loadChildObjects(GameObject o)
    {
        float objectWidth;
        if (o.tag == "Stars")
           objectWidth = o.GetComponent<MeshRenderer>().bounds.size.x;
        else
           objectWidth = o.GetComponent<LineRenderer>().bounds.size.x;

        int childsNeeded = (int) Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(o) as GameObject;


        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(o.transform);
            c.transform.position = new Vector3(objectWidth * i, o.transform.position.y, o.transform.position.z);
            c.name = o.name + i;
        }
        Destroy(clone);
        if (o.tag == "Stars")
           Destroy(o.GetComponent<MeshRenderer>());
        else
           Destroy(o.GetComponent<LineRenderer>());
    }


    void LateUpdate()
    {

        foreach (GameObject o in levels)
        {
            repositionChildObject(o);
        }
    }

    void repositionChildObject(GameObject o)
    {
        Transform[] children = o.GetComponentsInChildren<Transform>();

        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfWidth;
            if (o.tag == "Stars")
               halfWidth = lastChild.GetComponent<MeshRenderer>().bounds.extents.x;
            else
                halfWidth = lastChild.GetComponent<LineRenderer>().bounds.extents.x;


            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
        }
    }
}
