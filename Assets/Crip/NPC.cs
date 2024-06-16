using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NPC : MonoBehaviour,IInteracctable
{
    // Start is called before the first frame update
    [SerializeField] private SpriteRenderer _interactSprite;
    private Transform _playerTransform;
    private const float INTERRACT_DISTANCE = 5f;
    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && IsWithinInteractDistance())
        {
            Interact();
        }
        if(_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(false);
        }
        else if(!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(true);
        }
    }
    public abstract void Interact();
    private bool IsWithinInteractDistance()
    {
        if(Vector2.Distance(_playerTransform.position,transform.position)< INTERRACT_DISTANCE)
        {
            return true;
        }else
        {
            return false;
        }
    }
}
