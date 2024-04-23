using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool isPaused;
    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float initialSpeed;
    private PlayerItems playerItems;
    private Rigidbody2D rig;
    private bool _isRunning;
    private bool _isRolling;
    private bool _isCutting;
    private bool _isDigging;
    private bool _isGetWater;
    private bool _isWatering;
    private bool _isFishing;
    private Vector2 _direction;
    [HideInInspector] public int handlingObj = 1;
    

    public Vector2 direction//propriedade
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public bool IsRunning//propriedade
    {
        get { return _isRunning; }
        set { _isRunning = value; }
    }
    public bool IsRolling//propriedade
    {
        get { return _isRolling; }
        set { _isRolling = value; }
    }
    public bool IsCutting { get => _isCutting; set => _isCutting = value; }
    public bool IsDigging {get => _isDigging; set => _isDigging = value;}
    public bool IsGetWater {get => _isGetWater; set => _isGetWater = value;}
    public bool IsWatering {get => _isWatering; set => _isWatering = value;}
    public bool IsFishing {get => _isFishing; set => _isFishing = value;}

    private void Start()
    {
        playerItems = GetComponent<PlayerItems>();
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
        handlingObj = 1;
    }

    private void Update()
    {
        if(!isPaused)
        {
            ChangeTools();
            OnInput();
            OnRun();
            OnRolling();
            switch (handlingObj) 
            { 
                case 1: OnCutting(); 
                break; 
                case 2: OnDig(); 
                break; 
                case 3: 
                    OnGetWater(); 
                    OnWatering(); 
                break; 
            }
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
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
            _isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            _isRunning = false;
        }
    }

    void OnRolling()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            _isRolling = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _isRolling = false;
        }
    }

    #endregion
    
    void OnCutting()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isCutting = true;
            speed = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _isCutting = false;
            speed = initialSpeed;
        }
    }

    void OnDig()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _isDigging = true;
            speed = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            _isDigging = false;
            speed = initialSpeed;
        }
    }

    void OnGetWater()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _isGetWater = true;
            speed = 0f;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _isGetWater = false;
            speed = initialSpeed;
        }
    }

    void OnWatering()
    {
        if(_isWatering && playerItems.WaterAmount > 0)
        {
            playerItems.WaterAmount -= 0.05f;
        }
        if (Input.GetKeyDown(KeyCode.Q) && playerItems.WaterAmount > 0)
        {
            _isWatering = true;
            speed = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.Q) || playerItems.WaterAmount <= 0)
        {
            _isWatering = false;
            speed = initialSpeed;
        }
    }

    void ChangeTools()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 3;
        }
    }
}
