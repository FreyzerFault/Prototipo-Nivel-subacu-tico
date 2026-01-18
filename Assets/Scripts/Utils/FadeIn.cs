using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class FadeIn : MonoBehaviour
    {
        [SerializeField] private TMP_Text loadingTxt; 
        private Image img;
        private Image Img => GetComponent<Image>();
    
        public float duration = 0.5f;
    
        public enum FadeType {Out, In}
    
        public FadeType fadeType;
        private bool IsIn => fadeType == FadeType.In;
        private bool IsOut => fadeType == FadeType.Out;

        public event Action OnFadeIn;
        public event Action OnFadeOut;

        public Color Color
        {
            get => Img.color;
            set => Img.color = value;
        }
    
        private float Alpha
        {
            get => Img.color.a;
            set
            {
                Img.color = new Color(Img.color.r, Img.color.g, Img.color.b, value);
                loadingTxt.alpha = value;
            }
        }


        private void Awake()
        {
            img = GetComponent<Image>();
            loadingTxt = GetComponentInChildren<TMP_Text>();
        }

        private void Start() => Reset();

        public void DoFade()
        {
            if (IsOut) DoFadeOut();
            else DoFadeIn();
        }

        public void DoFadeIn()
        {
            Reset();
            loadingTxt.DOFade(1, duration).Play();
            Img.DOFade(1, duration).OnComplete(() => OnFadeIn?.Invoke()).Play();
        }

        public void DoFadeOut()
        {
            Reset();
            loadingTxt.DOFade(0, duration).Play();
            Img.DOFade(0, duration).OnComplete(() => OnFadeOut?.Invoke()).Play();
        }

        public void Reset()
        {
            Alpha = IsIn ? 0 : 1;
        }
    }
}
