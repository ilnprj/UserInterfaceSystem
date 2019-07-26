// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.Animations
{
    using UnityEngine;

    public class CurveScale : BaseCurveAnim
    {
        public Vector3 From = new Vector3(0, 0, 0);
        public Vector3 To = new Vector3(1, 1, 1);

        public override void Start()
        {
            base.Start();
            transform.localScale = From;
        }

        public new void CalculateCurve()
        {
            transform.localScale = To * GraphValue;
        }

        public new void Update()
        {
            CalculateCurve();
        }
    }

}
