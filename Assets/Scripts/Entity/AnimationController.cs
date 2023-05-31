using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Transform _body;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void Animate(Vector2 direction)
    {
        if (direction.x != 0 || direction.y != 0)
        {
            _animator.speed = direction.magnitude;
            _animator.SetBool("Walk", true);
            _animator.SetBool("Idle", false);
        }
        else
        {
            _animator.speed = 1f;
            _animator.SetBool("Walk", false);
            _animator.SetBool("Idle", true);
        }

        flip(direction.x);
        
        void flip(float x)
        {
            if (x == 0)
            {
                return;
            }

            if (x > 0)
            {
                _body.localScale = new Vector3(1, 1, 1);
            }

            if (x < 0)
            {
                _body.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    
}
