using UnityEngine;

public class CuterPoint : MonoBehaviour
{
    private void Update()
    {
        // CUTE ROPE
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); // HIT RAYCAST TO THE CHECK

            // CHECK IF HITING SOMETHING
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Link") // IF TAG MATCH
                {
                    Destroy(hit.collider.gameObject); // DESTROY THAT GAME OBJECT
                    Destroy(hit.transform.parent.gameObject, 3f); // DESTROY HIS PARENT GAME OBJECT AFTER 3S
                }
            }
        }
        
    }

}
