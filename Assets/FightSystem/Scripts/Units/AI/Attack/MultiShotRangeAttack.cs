using System.Collections;
using UnityEngine;

public class MultiShotRangeAttack : RangeAttack
{
    protected override void Attack()
    {
        Bullet.Shoot(transform.position, CalculateTime(Target.position), Target);
        StartCoroutine(Shoot(Target.position));
        ShootToAnotherTargets();
    }

    private IEnumerable ShootToAnotherTargets()
    {
        for (int i = 0; i < 360; i++)
        {
            Ray ray = new Ray(Target.position, CalculatePosition(i));

            RaycastHit hit;

            if (!Physics.Raycast(ray, out hit))
                continue;
            var unit = hit.transform.GetComponent<UnitStats>();

            if (unit == null)
                continue;

            Bullet.Shoot(transform.position, CalculateTime(unit.transform.position), unit.transform);
            StartCoroutine(Shoot(transform.position));
            SetBuff(unit);
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    private Vector3 CalculatePosition(float angle)
            => new Vector3
            (transform.position.x + Mathf.Sin(angle),
            (transform.position + Vector3.up).y,
            transform.position.z + Mathf.Cos(angle));
}