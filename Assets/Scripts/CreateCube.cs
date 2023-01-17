using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    public void DoCreateCube()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 spawnPosition = hit.point;
            spawnPosition.y += 1f;
            GameObject spawnedCube = Instantiate(_cubePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
