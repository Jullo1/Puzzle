using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    GameManager _game;
    AudioSource _audioS;
    Vector3 _offset;
    bool _clicked;

    void OnMouseDown()
    {
        if (!_clicked)
            _offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        if (!_clicked)
            transform.position = GetMouseWorldPos() + _offset;
    }

    Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Awake()
    {
        _audioS = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<AudioSource>();
        _game = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    void Start()
    {
        _clicked = false;
    }

    void Update()
    {
        if (!_clicked)
            if (transform.position.x < 0.1f && transform.position.x > -0.1f)
                if (transform.position.y < 0.1f && transform.position.y > -0.1f)
                    Clicked();
    }

    void Clicked()
    {
        if (!_clicked)
        {
            _clicked = true;
            _audioS.Play();
            transform.position = Vector3.zero;
            _game.finishCount++;
            BoxCollider2D bCollider = GetComponent<BoxCollider2D>();
            Destroy(bCollider);
        }
    }
}
