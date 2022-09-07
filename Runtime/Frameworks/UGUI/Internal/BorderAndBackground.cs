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
        public RectTransform Border { get; private set; }
        public RectTransform BackgroundRoot { get; private set; }
        public RectTransform ShadowRoot { get; private set; }

        private UGUIComponent Component;
        private UGUIContext Context;
        private Action<RectTransform> SetContainer;
        internal RawImage BgImage;

        public RoundedBorderMaskImage RootGraphic;
        public Mask RootMask;

        public BasicBorderImage BorderGraphic;

        public List<BoxShadowImage> ShadowGraphics;
        public List<BackgroundImage> BackgroundGraphics;
        public List<BackgroundImage> MaskGraphics;
        public BackgroundImage LastMask => MaskGraphics == null || MaskGraphics.Count == 0 ? null : MaskGraphics[MaskGraphics.Count - 1];

        public RectTransform MaskRoot;

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
            
            var bg = context.CreateNativeObject("[BackgroundImage]", typeof(RectTransform), typeof(RawImage));
            
            cmp.RootGraphic = bg.GetComponent<RoundedBorderMaskImage>();
            cmp.RootGraphic.raycastTarget = false;

            cmp.Component = comp;
            cmp.Context = context;
            
            cmp.SetContainer = setContainer;
            
            var bgImage = bg.GetComponent<RawImage>();
            cmp.BgImage = bgImage;
            bgImage.color = Color.clear;

            cmp.Root = bg.transform as RectTransform;
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
            UpdateBgColor();

            SetBackground(bgColor, style.backgroundImage, style.backgroundPositionX, style.backgroundPositionY, style.backgroundSize, style.backgroundRepeatX, style.backgroundRepeatY);
        }

        public void UpdateLayout(YogaNode layout)
        {
            SetBorderSize(layout);
        }

        private void SetBorderSize(YogaNode layout)
        {
            var bidiLeft = layout.LayoutDirection == YogaDirection.LTR ? layout.BorderStartWidth : layout.BorderEndWidth;
            var bidiRight = layout.LayoutDirection == YogaDirection.RTL ? layout.BorderStartWidth : layout.BorderEndWidth;

            var borderLeft = GetFirstDefinedSize(bidiLeft, layout.BorderLeftWidth, layout.BorderWidth);
            var borderRight = GetFirstDefinedSize(bidiRight, layout.BorderRightWidth, layout.BorderWidth);
            var borderTop = GetFirstDefinedSize(layout.BorderTopWidth, layout.BorderWidth);
            var borderBottom = GetFirstDefinedSize(layout.BorderBottomWidth, layout.BorderWidth);


            var min = new Vector2(-borderLeft, -borderBottom);
            var max = new Vector2(borderRight, borderTop);

            Root.offsetMin = -min;
            Root.offsetMax = -max;

            Border.offsetMin = min;
            Border.offsetMax = max;

            BackgroundRoot.offsetMin = min;
            BackgroundRoot.offsetMax = max;

            RootGraphic.SetMaterialDirty();
        }

        private void SetBorderRadius(YogaValue2 tl, YogaValue2 tr, YogaValue2 br, YogaValue2 bl)
        {
            var v = new YogaValue2[4] { tl, tr, br, bl };

            RootGraphic.SetMaterialDirty();
        }

        private void SetBorderColor(Color top, Color right, Color bottom, Color left)
        {
        
        }

        private void SetBackground(
            Color color,
            ICssValueList<ImageDefinition> images,
            ICssValueList<YogaValue> positionsX,
            ICssValueList<YogaValue> positionsY,
            ICssValueList<BackgroundSize> sizes,
            ICssValueList<BackgroundRepeat> repeatXs,
            ICssValueList<BackgroundRepeat> repeatYs
        )
        {
            var validCount = images?.Count ?? 0;

            if (BackgroundGraphics == null)
            {
                if (validCount > 0) BackgroundGraphics = new List<BackgroundImage>();
                else return;
            }

            var diff = BackgroundGraphics.Count - validCount;

            if (diff > 0)
            {
                for (int i = diff - 1; i >= 0; i--)
                {
                    var sd = BackgroundGraphics[validCount + i];

                    BackgroundGraphics.RemoveAt(validCount + i);
                    DestroyImmediate(sd.gameObject);
                }
            }
            else if (diff < 0)
            {
                for (int i = -diff - 1; i >= 0; i--)
                {
                    CreateBackgroundImage();
                }
            }


            var len = BackgroundGraphics.Count;
            for (int i = 0; i < len; i++)
            {
                var sd = BackgroundGraphics[len - 1 - i];
                sd.SetBackgroundColorAndImage(color, images?.Get(i), blendMode);
                sd.BackgroundRepeatX = repeatXs.Get(i);
                sd.BackgroundRepeatY = repeatYs.Get(i);
                sd.BackgroundPosition = new YogaValue2(positionsX.Get(i), positionsY.Get(i));
                sd.BackgroundSize = sizes.Get(i);
                sd.SetMaterialDirty();
            }
        }

        private void SetBoxShadow(ICssValueList<BoxShadow> shadows)
        {
        
        }

        private void SetMask(
            ICssValueList<ImageDefinition> images,
            ICssValueList<YogaValue> positionsX,
            ICssValueList<YogaValue> positionsY,
            ICssValueList<BackgroundSize> sizes,
            ICssValueList<BackgroundRepeat> repeatXs,
            ICssValueList<BackgroundRepeat> repeatYs
        )
        {
        
        }

        private void CreateMask()
        {
        
        }

        private void DestroyLastMask()
        {
        
        }

        private void CreateShadow()
        {
        
        }

        private void CreateBackgroundImage()
        {
            var sd = Context.CreateNativeObject("[Background]", typeof(RectTransform), typeof(BackgroundImage));
            var img = sd.GetComponent<BackgroundImage>();
            img.color = Color.clear;
            img.Context = Context;
            BackgroundGraphics.Add(img);
            FullStretch(sd.transform as RectTransform, BackgroundRoot);
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
