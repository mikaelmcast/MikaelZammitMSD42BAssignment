using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin, xMax, yMin, yMax;
    float test = 5f;

    [SerializeField] float PlayerMovingSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovingSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        this.transform.position = new Vector2(newXpos, transform.position.y);
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
