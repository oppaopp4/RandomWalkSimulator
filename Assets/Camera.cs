using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField, Range(0.1f, 100.0f)]
    private float _positionStep;

    private Transform _camTransform;

    private float def_pos_x;

    void Start()
    {
        _camTransform = this.gameObject.transform;
        def_pos_x = 0f;
    }

    void Update()
    {
        CameraPositionKeyControl();
    }

    private void CameraPositionKeyControl()
    {
        Vector3 campos = _camTransform.position;

        if (Input.GetKey(KeyCode.D)) { campos += _camTransform.right * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.A)) { campos -= _camTransform.right * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.W)) { campos += _camTransform.up * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.S)) { campos -= _camTransform.up * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.Z)) { campos += _camTransform.forward * Time.deltaTime * _positionStep; }
        if (Input.GetKey(KeyCode.X)) { campos -= _camTransform.forward * Time.deltaTime * _positionStep; }

        _camTransform.position = campos;

        if (Input.GetKey(KeyCode.C)) { ResetPos(); }
    }
    public void SetDefPosX(float x)
    {
        def_pos_x = x;
        ResetPos();
    }
    public void ResetPos()
    {
        Vector3 campos = _camTransform.position;

        campos = new Vector3(def_pos_x, 0f, -10f);

        _camTransform.position = campos;
    }
}
