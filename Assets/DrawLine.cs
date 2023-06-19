using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DrawLine : MonoBehaviour
{
    int _posCount = 0;
    Camera _camera;
    LineRenderer _renderer;
    Vector2 _mousePos = Vector2.zero;
    Vector2 _prePos = Vector2.zero;


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
        if (Input.GetMouseButtonUp(0))
        {
            SetLine();
            _posCount = 0;
        }
    }

    /// <summary>
    /// 線を引く
    /// </summary>
    /// <param name="pos"></param>
    void LineDraw(Vector2 pos)
    {
        if (_prePos == pos) return;

        _posCount++;
        _renderer.positionCount = _posCount;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
        _prePos = pos;
    }

    /// <summary>
    /// 現在引かれているラインの情報を新しいオブジェクトにコピーして写す
    /// これで一度引かれたラインを画面上に残す
    /// </summary>
    void SetLine()
    {
        //コピー先の準備
        var newObj = new GameObject();
        newObj.AddComponent<LineRenderer>();
        newObj.TryGetComponent(out LineRenderer newObjRenderer);
        newObjRenderer.positionCount = _posCount;
        newObjRenderer.material = _renderer.material;
        newObjRenderer.numCornerVertices = _renderer.numCornerVertices;
        newObjRenderer.numCapVertices = _renderer.numCapVertices;
        newObjRenderer.widthCurve = _renderer.widthCurve;


        var positions = new List<Vector3>();

        for (int i = 0; i < _renderer.positionCount; i++)
        {
            positions.Add(_renderer.GetPosition(i));
        }

        for (int i = 0; i < positions.Count; i++)
        {
            newObjRenderer.SetPosition(i, positions[i]);
        }

        //リセット処理
        _renderer.positionCount = 0;
    }
}
