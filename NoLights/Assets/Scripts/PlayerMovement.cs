using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float tileDistance;
    [SerializeField]
    private float movementDelay;

    private Transform myTransform;

    private Rigidbody2D rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myTransform = transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Walking());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }

    private IEnumerator Walking()
    {
        WaitForSeconds delay = new WaitForSeconds(movementDelay);        

        while (true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = Vector3.zero;

            if (moveHorizontal < 0)
                movement.x = -tileDistance;
            else if (moveHorizontal > 0)
                movement.x = tileDistance;
            else if (moveVertical > 0)
                movement.y = tileDistance;
            else if (moveVertical < 0)
                movement.y = -tileDistance;

            rb.MovePosition(movement + transform.position);

            yield return delay;
        }
    }
}
