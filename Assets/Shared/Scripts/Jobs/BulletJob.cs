using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Burst;

[BurstCompile]
public struct BulletJob : IJob
{
    private float _ySpeed;
    private float _xSpeed;
    private float _deltaTime;
    private Vector2 _position;
    private Quaternion _rotation;

    private NativeArray<Vector2> _positionResult;

    public BulletJob(float ySpeed, float xSpeed, float deltaTime, Vector2 position, Quaternion rotation, NativeArray<Vector2> positionResult)
    {
        _ySpeed = ySpeed;
        _xSpeed = xSpeed;
        _deltaTime = deltaTime;
        _position = position;
        _rotation = rotation;
        _positionResult = positionResult;
    }
    
    public void Execute()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        Vector2 newPosition = (_rotation * Vector2.up * this._ySpeed * _deltaTime) + (_rotation * Vector2.right * this._xSpeed * _deltaTime);
        _position =  _position + newPosition;
        _positionResult[0] = _position;
    }
}