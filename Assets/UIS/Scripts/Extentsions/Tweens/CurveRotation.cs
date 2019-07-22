using UnityEngine;

public class CurveRotation : BaseCurveAnim
{
    public Vector3 From;
    public Vector3 To;
    
    public void FixedUpdate()
    {
        Calculate();
    }

    private void Calculate()
    {
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(From), Quaternion.Euler(To), GraphValue);
    }
}
