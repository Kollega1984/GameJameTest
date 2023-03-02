using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Ray _ray;
    private Plane _plane;
    void Start()
    {
        _plane = new Plane(-Vector3.up, Vector3.zero);
    }
    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _plane.Raycast(_ray, out float hit);
        {
            Vector3 pointMouse = _ray.GetPoint(hit);
            Vector3 toTargetXZ = new Vector3(pointMouse.x, 0, pointMouse.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(toTargetXZ), Time.deltaTime * moveSpeed);       
        }    
    }
}
