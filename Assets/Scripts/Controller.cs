using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)){
            _animator.SetTrigger("Jump");
        }
    }

    private void Move()
    {
        float inputDir = Input.GetAxis("Horizontal");

        if (inputDir < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        _animator.SetFloat("MoveSpeed", Mathf.Abs(inputDir));

        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + inputDir, transform.position.y), Time.deltaTime * _moveSpeed);
    }
}
