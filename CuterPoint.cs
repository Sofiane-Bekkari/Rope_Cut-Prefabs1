using UnityEngine;

public class CuterPoint : MonoBehaviour
{
    public Rigidbody2D[] links;
    public Ropes ropesScript;

    private void Start()
    {
        ropesScript = GameObject.Find("Ropes").GetComponent<Ropes>();
    }
    private void Update()
    {
        // CUTE ROPE
        if (Input.GetMouseButton(0))
        {
            ropesScript.cutOneOfLink = false; // PASS IT FALSE
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); // HIT RAYCAST TO THE CHECK

            // CHECK IF HITING SOMETHING
            if (hit.collider != null)
            {
                
                if (hit.collider.tag == "Link") // IF TAG MATCH
                {
                    // ENABLE TRAIL
                    ropesScript.cutOneOfLink = true; // PASS IT TRUE
                    Destroy(hit.collider.gameObject);
                    Debug.Log("DOWN!!!");
                        //Destroy(hit.collider.gameObject); // DESTROY THAT GAME OBJECT
                   
                    //Destroy(gameObject, 3f); // DESTROY HIS PARENT GAME OBJECT AFTER 3S                    Debug.Log("KILL ROPE WAD CUT >>>>>");
                }
            }
        }
        
    }

}
