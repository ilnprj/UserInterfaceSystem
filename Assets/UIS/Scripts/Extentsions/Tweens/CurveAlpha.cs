// ----------------------------------------------------------------------------
// The MIT License
// UserInterfaceSystem https://gitlab.com/ilnprj/
// Copyright (c) 2019 ilnprj <Grigoriy Fedorenko>
// ----------------------------------------------------------------------------

namespace UIS.Extensions.Animations
{
    using UnityEngine;
    using UnityEngine.UI;

    public class CurveAlpha : BaseCurveAnim
    {
        public float From;
        public float To = 1.0f;
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
            if (!image)
            {
                Destroy(this);
            }
        }

        public void FixedUpdate()
        {
            Calculate();
        }

        public void Calculate()
        {
            var color = image.color;
            color.a = Mathf.Lerp(From, To, GraphValue);
            image.color = color;
        }
    }

}
