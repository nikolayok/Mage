using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    private Camera _mainCamera;
    private Rigidbody _body;

    private int _speed = 10;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckForMouseClick();
    }

    private void CheckForMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
        else 
        {
            // Stop();
        }
    }

    private void Move()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (hit.transform.gameObject.tag != "Ground")
                    return;
                    
                Vector3 direction = (hit.point - transform.position).normalized;
                // Vector3 adjustedDirection = new Vector3(direction.x, direction.y + 0.5f, direction.z).normalized;
                _body.velocity = direction * _speed;
            }
        }
    }

    private void Stop()
    {
        _body.velocity = Vector3.zero;
    }
}
