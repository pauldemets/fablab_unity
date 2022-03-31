using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle_movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _playerRB;
    [SerializeField]
    private float _verticalMovementForce = 100f;
    [SerializeField]
    private float _horizontalMovementForce = 100f;
    [SerializeField]
    private Animator _playerAnimator;

    private PlayerState _currentState;

    public PlayerState CurrentState
    {
        get { return _currentState; }
        set
        {
            _currentState = value;
            _playerAnimator.SetInteger("PlayerState", (int)_currentState);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //On traite d?sormais ? part le mouvement vertical (en partie g?r? par le moteur physique)
        float horizontalMovement = 0;
        float verticalMovement = 0;

        #region Inputs verticaux
        //Plus besoin de normaliser, on pourrait utiliser une direction ? 1 ou -1 en tant que multiplicateur,
        //mais c'est plus rapide de directement d?terminer le mouvement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalMovement += _verticalMovementForce;
            CurrentState = PlayerState.Runing_Top;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement -= _horizontalMovementForce;
            CurrentState = PlayerState.Running_Left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement += _horizontalMovementForce;
            CurrentState = PlayerState.Running_Right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalMovement -= _verticalMovementForce;
            CurrentState = PlayerState.Running_Down;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            verticalMovement = 0;
            horizontalMovement = 0;
            CurrentState = PlayerState.Idle;
        }

        #endregion

        //D?finir directement le y de la v?locit? override ce que Unity calcule avec la gravit?.
        //_playerRB.velocity = movement * _movementForce;

        Vector2 newVelocity = new Vector2(horizontalMovement, verticalMovement);

        //Debug.Log($"{_playerRB.velocity.y}");
        _playerRB.velocity = newVelocity;

    }

    public enum PlayerState
    {
        Idle,
        Running_Right,
        Runing_Top,
        Running_Down,
        Running_Left
    }

}
