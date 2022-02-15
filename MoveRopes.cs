using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRopes : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedMove = 5f;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        // SCREEN BOUND
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speedMove * Time.deltaTime);

        if (transform.position.x < -14) // TEST
        {
            Destroy(this.gameObject);
            //Debug.Log("SCREEN X: " + screenBounds.x);
            //Debug.Log("POSITION X: " + transform.position.x);
        }
        
    }
}
