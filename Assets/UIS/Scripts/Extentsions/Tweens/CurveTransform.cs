// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.Animations
{
    using UnityEngine;

    public class CurveTransform : BaseCurveAnim
    {
        public Transform From;
        public Transform To;

        public void FixedUpdate()
        {
            Calculate();
        }

        private void Calculate()
        {
            transform.localPosition = Vector3.Lerp(From.localPosition, To.localPosition, GraphValue);
            transform.localScale = Vector3.Lerp(From.localScale, To.localScale, GraphValue);
            transform.rotation = Quaternion.Slerp(From.rotation, To.rotation, GraphValue);
        }
    }
}
