using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Camera _mainCamera;
    private GameObject _player;
    private Rigidbody _body;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _body = _player.GetComponent<Rigidbody>();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Teleportation()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            _body.velocity = Vector3.zero;
            _player.transform.position = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);
        }
    }
}
