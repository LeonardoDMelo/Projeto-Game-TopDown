using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isPaused;
    
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;

    private Rigidbody2D rig;
    private PlayerItems playerItems;


    private float inicialSpeed;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isWatering;


    private Vector2 _direction;

    [HideInInspector] public int handlingObj;


   
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool isRunning
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool isRolling
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }
    public bool isDigging
    {
        get { return _isDigging; }
        set { _isDigging = value; }
    }
    public bool isWatering
    {
        get { return _isWatering; }
        set { _isWatering = value; }
    }


    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        playerItems = GetComponent<PlayerItems>();

        inicialSpeed = speed;
    }



    private void Update()
    {
        if (!isPaused)
        {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                handlingObj = 0;
            }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 2;
        }

        OnInput();
        OnRun();
        OnRolling();
        OnCutting();
        OnDig();
        OnWatering();
            
        }

    }

    private void FixedUpdate()
    {
        if(!isPaused) 
        {
        OnMove();
        }
    }

    #region Movement


    void OnCutting()
    {
        if (handlingObj == 0)
        { 
            if(Input.GetMouseButtonDown(0))
            {
               _isCutting = true;
                speed = 0;

            }
            if(Input.GetMouseButtonUp(0))
            {
                _isCutting= false;
                speed = inicialSpeed;
            }
        }
    }
    void OnDig()
    {
        if (handlingObj == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _isDigging = true;
                speed = 0;

            }
            if (Input.GetMouseButtonUp(0))
            {
                _isDigging = false;
                speed = inicialSpeed;
            }
        }
    }


    void OnWatering()
    {
        if (handlingObj == 2 )
        {
            if (Input.GetMouseButtonDown(0) && playerItems.currentlWater > 0)
            {
                _isWatering = true;
                speed = 0;

            }
            if (Input.GetMouseButtonUp(0) || playerItems.currentlWater < 0)
            {
                _isWatering = false;
                speed = inicialSpeed;
            }

            if(isWatering)
            {
                playerItems.currentlWater -= 0.01f;
            }

        }
    }


    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void OnMove()
    {
        rig.MovePosition(rig.position +_direction *speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            speed = inicialSpeed;
            isRunning = false;
        }
    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _isRolling = true;
            speed += 5;
        }

        if(Input.GetMouseButtonUp(1))
        {
            _isRolling = false;
            speed = inicialSpeed;
        }

    }

    #endregion

}
