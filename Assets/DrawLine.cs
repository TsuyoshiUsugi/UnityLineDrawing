using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    int _posCount = 0;
    Camera _camera;
    LineRenderer _renderer;
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

        if (Input.GetMouseButton(0)) LineDraw(_mousePos);
        if (Input.GetMouseButtonUp(0)) _posCount = 0;
    }

    /// <summary>
    /// 線を引く
    /// </summary>
    /// <param name="pos"></param>
    void LineDraw(Vector2 pos)
    {
        _posCount++;
        _renderer.positionCount = _posCount;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    /// <summary>
    /// 現在引かれているラインの情報を新しいオブジェクトにコピーして写す
    /// これで一度引かれたラインを画面上に残す
    /// </summary>
    void SetLine()
    {

    }
}
