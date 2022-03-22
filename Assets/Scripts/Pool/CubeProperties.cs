using UnityEngine;

public class CubeProperties : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed;
    private Transform _playerTransform;
    private float _maxDistance;

    private void Update()
    {
        CubeMove();
    }

    public void CubeDisable()
    {
        this.gameObject.SetActive(false);
    }

    public void CubeSetUp(Vector3 direction, float speed, float maxDistance, Transform playerTansform)
    {
        this._direction = direction;
        this._speed = speed;
        this._maxDistance = maxDistance;
        this._playerTransform = playerTansform;
        this.transform.position = playerTansform.position;
    }

    public void CubeMove()
    {
        this.transform.Translate(this._direction * Time.deltaTime * this._speed);

        float currentDistance = Vector3.Distance(this.transform.position, this._playerTransform.position);
        if (currentDistance > _maxDistance)
            CubeDisable();
    }
}
