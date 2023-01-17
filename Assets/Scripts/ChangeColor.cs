using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Camera _mainCamera;
    private List<Color> _colors;

    void Start()
    {
        SetupColors();
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void SetupColors()
    {
        _colors = new List<Color>();
        _colors.Add(Color.red);
        _colors.Add(Color.green);
        _colors.Add(Color.yellow);
        _colors.Add(Color.blue);
        _colors.Add(Color.black);
        _colors.Add(Color.gray);
        _colors.Add(Color.white);
    }

    public Color RandomColor()
    {
        return _colors[Random.Range(0, _colors.Count)];
    }

    public void DoChangeColor()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject.tag != "Object")
                return;
                
            MeshRenderer mesh = hit.transform.gameObject.GetComponent<MeshRenderer>();
            mesh.material.color = RandomColor();
        }
    }
}
