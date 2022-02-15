using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ropes : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linksPrefabs;
    public GameObject fruitPrefabs; // ADD ON TEST
    public float distenceFromFruitEnd = 0.6f; // DISTENCE END
    public float distenceFromFruittUp = 1f; // DISTENCE UP FRONT
    public float distenceFromFruitLeftRight = 0.1f; // DISTENCE LEFT / RIGHT
    public Weight weight; // GET WEIGHT SCRIPT
    public int links = 7;
    private int count;
    public bool cutOneOfLink = false; // TRY TO GET IT WHEN CUT LINK *TEST*
     // Start is called before the first frame update
    void Start()
    {
        
        // GENERATE ROPE
        GenerateRope();
    }
    // UPDATE
   

    // COROUTINE FUNCTION 
    IEnumerator instantaitFruit(Rigidbody2D prRb)
    {
        // wait amount of second
        yield return new WaitForSeconds(0.5f);

        // ALL ADDESITIONAL SCRIPT FOR NEEDS FEATURES
        GameObject fruit = Instantiate(fruitPrefabs, transform); // ADD ON TEST
        HingeJoint2D jointFruit = fruit.GetComponent<HingeJoint2D>();
        TrailRenderer trialFruit = fruit.GetComponent<TrailRenderer>(); // GET TRAIL COMPONENT
        Rigidbody2D fruitRb = fruit.GetComponent<Rigidbody2D>();

        // TEST ADD WEIGHT
        fruitRb.mass = 5; // try to add mass
        jointFruit.connectedBody = prRb;
        jointFruit.anchor = new Vector2(-distenceFromFruitLeftRight, distenceFromFruittUp); // ADJESTMENT ANCHOR
        jointFruit.connectedAnchor = new Vector2(0f, -distenceFromFruitEnd);
        fruit.transform.localScale = new Vector2(1f, 1f); // SCALE IT
        
    }


    // GENERATE ROPE
    void GenerateRope()
    {
        Rigidbody2D previouseRb = hook; // FIRST RIGIDBODY
        GameObject link; // FIRST RIGIDBODY
        count = 0; // SET COUNT 0
        for (int i = 0; i < links; i++)
        {
            link = Instantiate(linksPrefabs, transform); // GENERATE PREFABS
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>(); // GET HINGE JOINT
            joint.connectedBody = previouseRb; // CONNECT BODIES

            // CHECK IF NOT THE LAST ITEM
            if (i < links - 1)
            {
                previouseRb = link.GetComponent<Rigidbody2D>(); // GET RIGIDBODY FOR THAT ITEM
                Debug.Log("GOT NORMAL!");
            }
            else
            {
                StartCoroutine(instantaitFruit(previouseRb)); // THIS IS INSANE 
                //weight.ConnectRope(link.GetComponent<Rigidbody2D>()); // CONNECT LAST LINK TO THE WEIGHT
                Debug.Log("CONNECT THE FRUIT HERE!" + link);
            }
        }
        
        if (previouseRb)
        {

        }
    }

    private void Update()
    {
        // CHECK IF ONE OF THE LINKS WAS CUT TO ADD TRIAL RENDERERE
        if (cutOneOfLink)
        {
            //trialFruit.enabled = true; // ENABLE IT
        }
        //else
            //trialFruit.enabled = false; // ENABLE IT
    }

}
