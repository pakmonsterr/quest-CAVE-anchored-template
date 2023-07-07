using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction.Input;
using UnityEngine.Assertions;

namespace Oculus.Interaction.Samples
{
    public class palm_menu : MonoBehaviour
    {
        public TMP_Text debug_text;
        
        [SerializeField, Interface(typeof(IHmd))]
        private UnityEngine.Object _hmd;
        private IHmd Hmd { get; set; }

        [SerializeField]
        private ActiveStateSelector _pose;

        protected virtual void Awake()
        {
            Hmd = _hmd as IHmd;
        }

        protected virtual void Start()
        {
            this.AssertField(Hmd, nameof(Hmd));
            _pose.WhenSelected += () => palmUp();
            _pose.WhenUnselected += () => palmDown();
        }
        
        private void palmUp()
        {
            debug_text.text = "palm up";
        }

        private void palmDown()
        {
            debug_text.text = "palm down";
        }
    }
}
