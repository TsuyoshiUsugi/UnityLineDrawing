using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer _renderer;
    Camera _camera;
    Vector2 _mousePos = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out _renderer);
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        _mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0)) SetLinePos(_mousePos);
    }

    void SetLinePos(Vector2 pos)
    {
        _renderer.positionCount++;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }
}
