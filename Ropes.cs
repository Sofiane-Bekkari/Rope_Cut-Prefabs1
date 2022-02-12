using UnityEngine;

public class Ropes : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linksPrefabs;
    public GameObject fruitPrefabs; // ADD ON TEST
    public Weight weight; // GET WEIGHT SCRIPT
    public int links = 7;
    // Start is called before the first frame update
    void Start()
    {
        // GENERATE ROPE
        GenerateRope();
    }

    // GENERATE ROPE
    void GenerateRope()
    {
        Rigidbody2D previouseRb = hook; // FIRST RIGIDBODY  
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linksPrefabs, transform); // GENERATE PREFABS
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>(); // GET HINGE JOINT
            joint.connectedBody = previouseRb; // CONNECT BODIES

            // CHECK IF NOT THE LAST ITEM
            if (i < links - 1)
            {
                previouseRb = link.GetComponent<Rigidbody2D>(); // GET RIGIDBODY FOR THAT ITEM
            } else
            {
                /* 
                 ALL ADDESITIONAL SCRIPT FOR NEEDS FEATURES
                //GameObject fruit = Instantiate(fruitPrefabs, transform); // ADD ON TEST
                //HingeJoint2D jointFruit = fruit.GetComponent<HingeJoint2D>();
                //jointFruit.connectedBody = previouseRb;

                */
                //Debug.Log("CONNECT THE FRUIT HERE!");
                weight.ConnectRope(link.GetComponent<Rigidbody2D>()); // CONNECT LAST LINK TO THE WEIGHT
            }
        }
    }  
}
