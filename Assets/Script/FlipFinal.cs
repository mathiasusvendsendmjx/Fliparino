using System.Collections;
using UnityEngine;
 
public class PlayerController : MonoBehaviour {
    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;
 
    private void Update() {
        if (_isMoving) return;
 
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Assemble(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.RightArrow)) Assemble(Vector3.right);
        else if (Input.GetKeyDown(KeyCode.UpArrow)) Assemble(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.DownArrow)) Assemble(Vector3.back);
 
        void Assemble(Vector3 dir) {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
        //Debug.Log(transform.position);
        //Debug.Log(transform.up);

    }
 
private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
    _isMoving = true;

    for (var i = 0; i < 90 / _rollSpeed; i++) {
        transform.RotateAround(anchor, axis, _rollSpeed);
        yield return new WaitForSeconds(0.01f);
    }

// snap EFTER rotation
Vector3 pos = transform.position;
pos.x = Mathf.Round(pos.x);
pos.y = Mathf.Round(pos.y * 2) / 2;
pos.z = Mathf.Round(pos.z);
transform.position = pos;

// 🔥 FIX ROTATION HER
Vector3 rot = transform.eulerAngles;
rot.x = Mathf.Round(rot.x / 90) * 90;
rot.y = Mathf.Round(rot.y / 90) * 90;
rot.z = Mathf.Round(rot.z / 90) * 90;
transform.eulerAngles = rot;

// lille pause
yield return new WaitForSeconds(0.02f);

_isMoving = false;
}
}