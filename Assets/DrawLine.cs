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
    /// ��������
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
    /// ���݈�����Ă��郉�C���̏���V�����I�u�W�F�N�g�ɃR�s�[���Ďʂ�
    /// ����ň�x�����ꂽ���C������ʏ�Ɏc��
    /// </summary>
    void SetLine()
    {
        //�R�s�[��̏���
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

        //���Z�b�g����
        _renderer.positionCount = 0;
    }
}
