using System;
using UnityEngine;
namespace Ralenski
{
    public class LerpBehaviour : MonoBehaviour
    {
        [Range(0, 10)]
        public float sliderVal;

        [TextArea, SerializeField] private string Note;
        public SphereCollider throwableObjCollider;
        public LerpOBJ lerpOBJ;
        public TimeOBJ timeOBJ;

        [Serializable]
        public struct TimeOBJ
        {
            private float _value;
            public float Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = _value >= Max ? Max : value; //is _value greater than max ? yes => return Max otherwise return the _value
                }
            }
            public float Max { get; set; }
        }
        [Serializable]
        public struct LerpOBJ
        {
            public float Beginning
            {
                get;
                set;
            }

            public float Ending
            {
                get;
                set;
            }

            public float Interprolant
            {
                get;
                set;
            }
            [SerializeField]
            private float _result;
            public float Result
            {
                get
                {
                    _result = Beginning + ((Ending - Beginning) * Interprolant);
                    return _result;
                }
            }
        }
        // Use this for initialization
        void Start()
        {

            timeOBJ = new TimeOBJ
            {
                Max = 10,
                Value = sliderVal
            };
            lerpOBJ = new LerpOBJ
            {
                Beginning = 0,
                Ending = timeOBJ.Max,
                Interprolant = timeOBJ.Value //set the ending of the lerp object
            };

            throwableObjCollider = GetComponent<SphereCollider>();//add a collider and store the reference
            throwableObjCollider.radius = lerpOBJ.Result;//set the radius of the sphere collider
        }
        public bool expand = true;
        // Update is called once per frame
        void Update()
        {
            if (expand)
            {
                timeOBJ.Value += Time.deltaTime;//update the timer
                sliderVal = timeOBJ.Value;//set the slider to the time objects value
                lerpOBJ.Interprolant = sliderVal / timeOBJ.Max; //set the interprolant to the sliders value
                throwableObjCollider.radius = lerpOBJ.Result;//set the result to be the lerp result
                if(throwableObjCollider.radius >= 10f)
                {
                    throwableObjCollider.radius = .8f;
                    expand = false;
                }
            }
            else
            {
                sliderVal = 0;
                timeOBJ = new TimeOBJ
                {
                    Max = 10,
                    Value = sliderVal
                };
                lerpOBJ = new LerpOBJ
                {
                    Beginning = 0,
                    Ending = timeOBJ.Max,
                    Interprolant = timeOBJ.Value //set the ending of the lerp object
                };
            }
        }
    }
}