using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin, xMax, yMin, yMax;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void SetUpMoveBounderies()
    {
        Camera worldCamera = Camera.main;

        xMin = worldCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        xMax = worldCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = worldCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        yMax = worldCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}
