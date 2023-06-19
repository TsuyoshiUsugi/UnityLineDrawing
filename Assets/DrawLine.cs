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
        _posCount++;
        _renderer.positionCount = _posCount;
        _renderer.SetPosition(_renderer.positionCount - 1, pos);
    }

    /// <summary>
    /// ���݈�����Ă��郉�C���̏���V�����I�u�W�F�N�g�ɃR�s�[���Ďʂ�
    /// ����ň�x�����ꂽ���C������ʏ�Ɏc��
    /// </summary>
    void SetLine()
    {
        //�R�s�[����
        var obj = new GameObject();
        obj.AddComponent<LineRenderer>();
        obj.TryGetComponent(out LineRenderer rend);
        rend.positionCount = _posCount;

        for (int i = 0; i < _renderer.positionCount; i++)
        {
            _renderer.SetPosition(i, _renderer.GetPosition(i));
        }

        //���Z�b�g����
        _renderer.positionCount = 0;
    }
}
