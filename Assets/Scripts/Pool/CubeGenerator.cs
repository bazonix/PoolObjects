using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    private int _poolCount = 0;
    private bool _autoExpand = true;
    [SerializeField] private CubeProperties _bulletPrefab;
    private PoolMonobehavior<CubeProperties> pool;
    [Space(5)]
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _distance = 10f;
    [Min(0.01f)]
    [SerializeField] private float _rate = 1.0f;
    private float _nextCheck;

    private void Start()
    {
        this.pool = new PoolMonobehavior<CubeProperties>(this._bulletPrefab, this._poolCount, this.transform);
        this.pool.autoExpand = this._autoExpand;
    }

    private void Update()
    {
        if (Time.time > _nextCheck)
        {
            CreateBullet();
            _nextCheck = Time.time + _rate;
        }
    }

    private GameObject CreateBullet()
    {
        var bullet = this.pool.GetFreeElement();
        bullet.GetComponent<CubeProperties>().CubeSetUp(this.transform.forward, this._speed, this._distance, this.transform);
        return bullet.gameObject;
    }
}
