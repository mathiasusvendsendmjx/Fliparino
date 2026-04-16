using UnityEngine;

public class Side : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
{
    if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
    {
        if (other.CompareTag(gameObject.tag))
        {
            Debug.Log("WIN ✅");
        }
        else
        {
            Debug.Log("WRONG ❌");
        }
    }
}
}