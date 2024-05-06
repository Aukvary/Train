using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;

    private Transform _target;

    public float BulletSpeed => _bulletSpeed;

    public void Shoot(Vector3 position, float time, Transform target)
    {
        var bullet = Instantiate(this, position + Vector3.up, Quaternion.identity);
        Destroy(bullet.gameObject, time);
        bullet._target = target;
    }

    private void Update()
    {
        if (_target == null)
            return;
        transform.position = Vector3.Lerp(transform.position, _target.position, _bulletSpeed * Time.deltaTime);
    }
}