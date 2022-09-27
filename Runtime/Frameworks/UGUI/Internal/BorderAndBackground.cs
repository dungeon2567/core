using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Yoga;
using ReactUnity.Styling;
using ReactUnity.Types;
using UnityEngine;
using UnityEngine.UI;

namespace ReactUnity.UGUI.Internal
{
    public class BorderAndBackground : MonoBehaviour
    {
        public RectTransform Root { get; private set; }
        public RectTransform BackgroundRoot { get; private set; }

        private UGUIContext Context;
        internal RawImage BgImage;

        public RoundedBorderMaskImage RootGraphic;

        public List<BackgroundImage> BackgroundGraphics;
        public BackgroundImage LastMask => null;

        private BackgroundBlendMode blendMode;
        public BackgroundBlendMode BlendMode
        {
            set
            {
                blendMode = value;
                UpdateBgColor();
            }
        }

        private Color bgColor;
        public Color BgColor
        {
            get => bgColor;
            set
            {
                bgColor = value;
                UpdateBgColor();
            }
        }

        private PointerEvents pointerEvents;
        public PointerEvents PointerEvents
        {
            set
            {
                pointerEvents = value;
                UpdateBgColor();
            }
        }


        public static BorderAndBackground Create(GameObject go, UGUIComponent comp, Action<RectTransform> setContainer)
        {
            var cmp = go.GetComponent<BorderAndBackground>();
            if (!cmp) cmp = go.AddComponent<BorderAndBackground>();

            var context = comp.Context;
            var bg = go;
            var root = bg;


            cmp.Context = context;

            var bgImage = go.AddComponent<RawImage>();
            cmp.BgImage = bgImage;
            bgImage.color = Color.clear;

            cmp.Root = root.transform as RectTransform;
            cmp.BackgroundRoot = bg.transform as RectTransform;

            FullStretch(cmp.Root, cmp.transform as RectTransform);
            cmp.Root.SetAsFirstSibling();

            return cmp;
        }

        private void UpdateBgColor()
        {
            var bg = BgImage;
            var hasColor = blendMode == BackgroundBlendMode.Normal || blendMode == BackgroundBlendMode.Color;
            var hasTarget = bgColor.a > 0 || pointerEvents == PointerEvents.All;
            bg.color = hasColor ? bgColor : Color.clear;
            bg.raycastTarget = hasTarget;
            bg.enabled = hasColor || hasTarget;
        }

        public void UpdateStyle(NodeStyle style)
        {
            blendMode = style.backgroundBlendMode;
            bgColor = style.backgroundColor;
            pointerEvents = style.pointerEvents;
        }

        public void UpdateLayout(YogaNode layout)
        {

        }

        static void FullStretch(RectTransform child, RectTransform parent)
        {
            child.transform.SetParent(parent, false);
            child.anchorMin = new Vector2(0, 0);
            child.anchorMax = new Vector2(1, 1);
            child.anchoredPosition = Vector2.zero;
            child.pivot = new Vector2(0.5f, 0.5f);
            child.sizeDelta = Vector2.zero;
        }

        private float GetFirstDefinedSize(params float[] fallbacks)
        {
            for (int i = 0; i < fallbacks.Length; i++)
            {
                var f = fallbacks[i];

                if (!float.IsNaN(f)) return f;
            }

            return 0;
        }
    }
}
