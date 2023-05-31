using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D.IK;

public class ArmRotation : MonoBehaviour
{
    [Header("IK")]
    [SerializeField] private IKManager2D _ikManager2D;
    [SerializeField] private Transform _weaponSolver;
    [SerializeField] private Transform _hand;

    private Vector2 _direction;
    
    public void SetRotation(Vector2 targetPosition)
    {
        if (targetPosition != Vector2.zero)
        {
            _ikManager2D.weight = 1f;
            _weaponSolver.position = targetPosition;
        }
        else
        {
            _ikManager2D.weight = 0f;
        }

        _direction = targetPosition - (Vector2)_hand.position;
    }

    public Vector2 GetDirection()
    {
        
        return _direction.normalized;
    }
}
