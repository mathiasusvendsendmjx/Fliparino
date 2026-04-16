using UnityEngine;

public class ColorCollider : MonoBehaviour
{
    private bool _hasChecked = false;
    private Collider _currentPlatform = null;

    void OnTriggerEnter(Collider other)
    {
        if (_hasChecked) return;
        if (other.gameObject.layer != LayerMask.NameToLayer("Platform")) return;

        _hasChecked = true;
        _currentPlatform = other;

        if (other.CompareTag(gameObject.tag))
        {
            Debug.Log("WIN ✅");
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("WRONG ❌");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == _currentPlatform)
        {
            _hasChecked = false;
            _currentPlatform = null;
        }
    }
}