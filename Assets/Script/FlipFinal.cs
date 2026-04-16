using System.Collections;
using UnityEngine;
 
public class PlayerController : MonoBehaviour {
    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;
 
    private void Update() {
        if (_isMoving) return;
 
        if (Input.GetKey(KeyCode.LeftArrow)) Assemble(Vector3.left);
        else if (Input.GetKey(KeyCode.RightArrow)) Assemble(Vector3.right);
        else if (Input.GetKey(KeyCode.UpArrow)) Assemble(Vector3.forward);
        else if (Input.GetKey(KeyCode.DownArrow)) Assemble(Vector3.back);
 
        void Assemble(Vector3 dir) {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
        //Debug.Log(transform.position);
Debug.Log(transform.up);

    }
 
    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;

        Vector3 pos = transform.position;

        pos.x = Mathf.Round(pos.x);
        pos.z = Mathf.Round(pos.z);

        transform.position = pos;

        for (var i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        _isMoving = false;
    }
}