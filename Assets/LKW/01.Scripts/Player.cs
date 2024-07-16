using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    Vector2 movement;

    [SerializeField] private float jumpPower;
    [SerializeField] private Transform _boxTrm;
    [SerializeField] private Vector2 _boxSize;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private GameObject _airEffect;

    private int _isGroundHash = Animator.StringToHash("IsGround");
    private int _yVelocityHash = Animator.StringToHash("YVelocity");
    public bool IsGround { get; private set; }
    private bool _canDoubleJump = false;

    public int PlayerHP { get; private set; } = 5;

    public UnityEvent OnHitEvent;

    public UnityEvent DeadEvent;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = transform.Find("Visual").GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
        CheckGround();
        _animator.SetBool(_isGroundHash, IsGround);
        _animator.SetFloat(_yVelocityHash, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump)
        {
            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.AddForce(Vector2.up * jumpPower * 1.1f, ForceMode2D.Impulse);
            StartCoroutine(AirEffectCoroutine());
            _canDoubleJump = false;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _canDoubleJump = true;
            return;
        }
    }

    private IEnumerator AirEffectCoroutine()
    {
        _airEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        _airEffect.SetActive(false);
    }

    private void CheckGround()
    {
        if (Physics2D.OverlapBox(_boxTrm.position, _boxSize, 0, _whatIsGround))
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        PlayerHP--;
        OnHitEvent?.Invoke();
        if (PlayerHP <= 0)
        {
            DeadEvent?.Invoke();
            return;
        }

    }



#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_boxTrm.position, _boxSize);
    }
#endif
}
