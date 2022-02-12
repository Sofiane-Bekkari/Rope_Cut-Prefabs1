using UnityEngine;

public class Weight : MonoBehaviour
{
    public float distenceFromWeightEnd = 0.6f; // DISTENCE END
    public float distenceFromWeightUp = 1f; // DISTENCE UP FRONT
    public float distenceFromWeightLeftRight = 0.1f; // DISTENCE LEFT / RIGHT
    // WEIGHT METHOD
    public void ConnectRope(Rigidbody2D endRb) // LINKS AS PARAMETER
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>(); // ADD HINGE JOINT 2D COMPONENT
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRb;
        joint.anchor = new Vector2(-distenceFromWeightLeftRight, distenceFromWeightUp); // ADJESTMENT ANCHOR
        joint.connectedAnchor = new Vector2(0f, -distenceFromWeightEnd);
        joint.useLimits = true; // ON TEST
       
    }
}
