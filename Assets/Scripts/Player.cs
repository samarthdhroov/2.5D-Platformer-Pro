using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;

    private int _speed = 5;

    private float _gravity = 1.5f;

    private int _jumpHeight = 50;

    private float _CacheYVelocity;

    private bool _jumped;

    private int _playerCoins;

    private UIManager _UIManager;

    private int _lives = 3;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        if(GameObject.Find("Canvas").GetComponent<UIManager>() != null)
        {
            _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

            _UIManager.updateLivesText(_lives);
        }
    }

    void Update()
    {

        float _horizontalInput = Input.GetAxis("Horizontal");

        Vector3 _direction = new Vector3(_horizontalInput, 0, 0);

        Vector3 _velocity = _direction * _speed;


        if (_characterController.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumped = true;
                _CacheYVelocity = _jumpHeight;
            }
            
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_jumped == true)
                {
                    _CacheYVelocity += _jumpHeight + 1;
                    _jumped = false;
                }
            }

            _CacheYVelocity -= _gravity;
        }

        _velocity.y = _CacheYVelocity;

        _characterController.Move(_velocity * Time.deltaTime);

        
    }

    public void updatePlayerCoins()
    {
        _playerCoins++;
        _UIManager.updateCoinScoreDisplay(_playerCoins);

    }

    public void reduceLives()
    {
        _lives--;
        _UIManager.updateLivesText(_lives);

        if (_lives < 1)
        {
            SceneManager.LoadScene(0); 
        }
       
    }

}
