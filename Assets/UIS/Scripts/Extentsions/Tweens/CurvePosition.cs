// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.Animations
{
    using UnityEngine;
    public class CurvePosition : BaseCurveAnim
    {
        public Vector3 From = new Vector3(0, 0, 0);
        public Vector3 To = new Vector3(1, 1, 1);

        public new void CalculateCurve()
        {
            transform.localPosition = Vector3.Lerp(From, To, GraphValue);
        }

        public new void Update()
        {
            CalculateCurve();
        }
    }
}
