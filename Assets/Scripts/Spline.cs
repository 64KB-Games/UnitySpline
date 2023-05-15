using UnityEngine;

public class Spline : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;
    [SerializeField] private Transform pointAb;
    [SerializeField] private Transform pointBc;
    [SerializeField] private Transform pointCd;
    [SerializeField] private Transform pointAbBc;
    [SerializeField] private Transform pointBcCd;
    [SerializeField] private Transform pointAbCd;
    private float _interpolateAmount;

    private void Update()
    {
        _interpolateAmount = (_interpolateAmount + Time.deltaTime) % 1f;
        
        /*
        pointAb.position = Vector3.Lerp(pointA.position, pointB.position, _interpolateAmount);
        pointBc.position = Vector3.Lerp(pointB.position, pointC.position, _interpolateAmount);
        pointCd.position = Vector3.Lerp(pointC.position, pointD.position, _interpolateAmount);
        
        pointAbBc.position = Vector3.Lerp(pointAb.position, pointBc.position, _interpolateAmount);
        pointBcCd.position = Vector3.Lerp(pointBc.position, pointCd.position, _interpolateAmount);
        
        pointAbCd.position = Vector3.Lerp(pointAbBc.position, pointBcCd.position, _interpolateAmount);
        */

        pointAbCd.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position,
            _interpolateAmount);
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        var ab = Vector3.Lerp(a, b, t);
        var bc = Vector3.Lerp(b, c, t);

        return Vector3.Lerp(ab, bc, _interpolateAmount);
    }

    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        var abBc = QuadraticLerp(a, b, c, t);
        var bcCd = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(abBc, bcCd, _interpolateAmount);
    }
}
