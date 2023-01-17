using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private GameObject _fireballPrefab;
    private Camera _mainCamera;

    private float _fireballSpeed = 50;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    public void SpellFireball()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Vector3 spawnPosition = hit.point;
            // spawnPosition.y += 1f;
            GameObject fireball = Instantiate(_fireballPrefab, transform.position, Quaternion.identity);
            Rigidbody fireballRigidbody = fireball.GetComponent<Rigidbody>();
            Vector3 fireballDirection = hit.point - transform.position;
            fireballRigidbody.velocity = fireballDirection.normalized * _fireballSpeed;
        }
    }
}
