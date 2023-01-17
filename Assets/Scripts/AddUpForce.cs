using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddUpForce : MonoBehaviour
{
    private Camera _mainCamera;
    private int _force = 500;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void DoAddUpForce()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject target = hit.transform.gameObject;
            if (target.tag != "Object")
                return;
            
            target.GetComponent<Rigidbody>().AddForce(Vector3.up * _force);
        }
    }
}
