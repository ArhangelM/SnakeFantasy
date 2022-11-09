using System;
using System.Collections;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    
    private Transform _playerModelTransform;
    private CharacterProperties _properties;
    private FixedJoystick _fixedJoystick;
    private Rigidbody2D _rb;
    
    private float speedMultiplier = 10f;
    
    public float Horizontal = 0f;
    public float Vertical = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _properties = GetComponent<CharacterProperties>();
        _playerModelTransform = GetComponent<Transform>();
        StartCoroutine("CharacterStay");
        _fixedJoystick = GameObject.FindGameObjectWithTag("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Horizontal = _fixedJoystick.Horizontal;
        Vertical = Input.GetAxis("Vertical");
        Vertical = _fixedJoystick.Vertical;
        _playerModelTransform.localScale = new Vector3(_properties.Mass / 10.0f, _properties.Mass / 10.0f, 0);
    }
    
    void FixedUpdate()
    {
        Debug.Log(Horizontal.ToString() + " " + Vertical.ToString());
        _rb.velocity = new Vector2(Horizontal * _speed * speedMultiplier * Time.fixedDeltaTime, Vertical * _speed * speedMultiplier * Time.fixedDeltaTime);
    }

    private IEnumerator CharacterStay()
    {
        for (;;)
        {
            if (Horizontal == 0 && Vertical == 0 && _properties.Mass > 1)
                _properties.Mass -= 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
