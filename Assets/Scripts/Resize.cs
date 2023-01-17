using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
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

    public void DoResize()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if ( ! DoNeedToResizeThis(hit))
                return;

            Vector3 objectSize = hit.transform.localScale;

            DestroyIfSmall(hit, objectSize);
                
            hit.transform.localScale = new Vector3(objectSize.x / 1.5f, objectSize.y / 1.5f, objectSize.z / 1.5f);
        }
    }

    void DestroyIfSmall(RaycastHit hit, Vector3 objectSize)
    {
        if (objectSize.x < 0.5f || objectSize.y < 0.5f || objectSize.z < 0.5f)
            Destroy(hit.transform.gameObject);
    }

    bool DoNeedToResizeThis(RaycastHit hit)
    {
        if (hit.transform.transform.gameObject.tag == "Object")
            return true;
        else 
            return false;
    }
}
