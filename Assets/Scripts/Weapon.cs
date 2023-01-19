using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _rate_of_fire_by_Seconds;
    private float _timer = 0f;
    [SerializeField] private List<GameObject> _bulletRef_List;
    [SerializeField] private Transform _bulletStartTR;
    private bool _canFire = true;
    private float _gap_by_each_bullet = 0f;

   public void Init()
    {
        _gap_by_each_bullet = 1 / _rate_of_fire_by_Seconds;
    }
    public void Fire()
    {
        if (_canFire)
        {
           var targetBullet = PickBullets();
            _canFire = false;
            var bullet = Instantiate(targetBullet, _bulletStartTR.position, _bulletStartTR.rotation);
            
        }

    }
    // Update is called once per frame
    void Update()
    {
        _bulletStartTR.up = transform.up;
        _timer += Time.deltaTime;
        if(_timer>_gap_by_each_bullet)
        {
            _timer = 0;
            _canFire = true;
        }
    }
    GameObject PickBullets()
    {
        var randomNumber = Random.Range(0, _bulletRef_List.Count);
        return _bulletRef_List[randomNumber];
    }

}
