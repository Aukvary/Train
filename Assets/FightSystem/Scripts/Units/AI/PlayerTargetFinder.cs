using UnityEngine;

public class PlayerTargetFinder : TargetFinder
{
    private Transform _train;
    private (Transform forward, Transform back) _boxes;

    public void SetTargets(Transform train, (Transform forward, Transform back) boxes)
    {
        _train = train;
        _boxes = boxes;
    }

    protected override void FindTarget()
    {
        if (FindUnit())
            return;

        if (_boxes.back == null && _boxes.forward == null)
        {
            CurrentTarget = _train;
            return;
        }

        if (_boxes.back == null)
        {
            CurrentTarget = _boxes.forward;
            return;
        }
        if (_boxes.forward == null)
        {
            CurrentTarget = _boxes.back;
            return;
        }

        float distaceForward = Vector3.Distance(transform.position, _boxes.forward.position);
        float distaceBack = Vector3.Distance(transform.position, _boxes.back.position);
        if (distaceBack > distaceForward)
            CurrentTarget = _boxes.forward;
        else
            CurrentTarget = _boxes.back;
    }
}