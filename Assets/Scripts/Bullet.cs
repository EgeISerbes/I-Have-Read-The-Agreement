using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _velocity = 10f;
    [SerializeField] private float _life_time = 3f;
    private float _timer = 0f;
    private Transform _directionTR;
    

    public void Update()
    {
        _timer += Time.deltaTime;
        if(_timer>=_life_time)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position += transform.up * _velocity * Time.deltaTime;         
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Foreground") || collision.gameObject.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Antivirus"))
        {
            var antivirus = collision.gameObject.GetComponent<AntiVirus>();
            antivirus.GetHurt();
        }
    }

}
