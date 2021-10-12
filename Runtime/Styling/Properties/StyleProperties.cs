using System;
using System.Collections.Generic;
using ReactUnity.Converters;
using ReactUnity.Styling.Animations;
using ReactUnity.Styling.Computed;
using ReactUnity.Types;
using TMPro;
using UnityEngine;
using NavigationMode = UnityEngine.UI.Navigation.Mode;

namespace ReactUnity.Styling
{
    public static class StyleProperties
    {
        public static readonly StyleProperty<float> opacity = new StyleProperty<float>("opacity", 1f, true, converter: AllConverters.PercentageConverter);
        public static readonly StyleProperty<int> zIndex = new StyleProperty<int>("zIndex", 0, false);
        public static readonly StyleProperty<bool> visibility = new StyleProperty<bool>("visibility", true, converter: new BoolConverter(new string[] { "visible" }, new string[] { "hidden" }));
        public static readonly StyleProperty<PositionType> position = new StyleProperty<PositionType>("position", PositionType.Relative);
        public static readonly StyleProperty<CursorList> cursor = new StyleProperty<CursorList>("cursor", null, false);
        public static readonly StyleProperty<PointerEvents> pointerEvents = new StyleProperty<PointerEvents>("pointerEvents", PointerEvents.Auto);
        public static readonly StyleProperty<ImageReference> maskImage = new StyleProperty<ImageReference>("maskImage", ImageReference.None);
        public static readonly StyleProperty<float> borderTopLeftRadius = new StyleProperty<float>("borderTopLeftRadius", 0f, true, converter: AllConverters.LengthConverter);
        public static readonly StyleProperty<float> borderTopRightRadius = new StyleProperty<float>("borderTopRightRadius", 0f, true, converter: AllConverters.LengthConverter);
        public static readonly StyleProperty<float> borderBottomLeftRadius = new StyleProperty<float>("borderBottomLeftRadius", 0f, true, converter: AllConverters.LengthConverter);
        public static readonly StyleProperty<float> borderBottomRightRadius = new StyleProperty<float>("borderBottomRightRadius", 0f, true, converter: AllConverters.LengthConverter);
        public static readonly StyleProperty<Color> borderLeftColor = new StyleProperty<Color>("borderLeftColor", Color.black, true);
        public static readonly StyleProperty<Color> borderRightColor = new StyleProperty<Color>("borderRightColor", Color.black, true);
        public static readonly StyleProperty<Color> borderTopColor = new StyleProperty<Color>("borderTopColor", Color.black, true);
        public static readonly StyleProperty<Color> borderBottomColor = new StyleProperty<Color>("borderBottomColor", Color.black, true);
        public static readonly StyleProperty<YogaValue2> transformOrigin = new StyleProperty<YogaValue2>("transformOrigin", YogaValue2.Center, true);
        public static readonly StyleProperty<YogaValue2> translate = new StyleProperty<YogaValue2>("translate", YogaValue2.Zero, true);
        public static readonly StyleProperty<Vector2> scale = new StyleProperty<Vector2>("scale", Vector2.one, true);
        public static readonly StyleProperty<Vector3> rotate = new StyleProperty<Vector3>("rotate", Vector3.zero, true, converter: AllConverters.RotateConverter);
        public static readonly StyleProperty<FontReference> fontFamily = new StyleProperty<FontReference>("fontFamily", FontReference.None, false, true);
        public static readonly StyleProperty<Color> color = new StyleProperty<Color>("color", ComputedCurrentColor.Instance, true, false);
        public static readonly StyleProperty<FontWeight> fontWeight = new StyleProperty<FontWeight>("fontWeight", FontWeight.Regular, false, true);
        public static readonly StyleProperty<FontStyles> fontStyle = new StyleProperty<FontStyles>("fontStyle", FontStyles.Normal, false, true);
        public static readonly StyleProperty<float> fontSize = new StyleProperty<float>("fontSize", ComputedFontSize.Default, true, false, AllConverters.LengthConverter);
        public static readonly StyleProperty<float> lineHeight = new StyleProperty<float>("lineHeight", ComputedFontSize.Default, true, true, AllConverters.LengthConverter);
        public static readonly StyleProperty<float> letterSpacing = new StyleProperty<float>("letterSpacing", 0f, true, true, AllConverters.LengthConverter);
        public static readonly StyleProperty<float> wordSpacing = new StyleProperty<float>("wordSpacing", 0f, true, true, AllConverters.LengthConverter);
        public static readonly StyleProperty<TextAlignmentOptions> textAlign = new StyleProperty<TextAlignmentOptions>("textAlign", TextAlignmentOptions.TopLeft, false, true);
        public static readonly StyleProperty<TextOverflowModes> textOverflow = new StyleProperty<TextOverflowModes>("textOverflow", TextOverflowModes.Overflow, false, true);
        public static readonly StyleProperty<bool> textWrap = new StyleProperty<bool>("textWrap", true, inherited: true, converter: new BoolConverter(new string[] { "wrap", "normal" }, new string[] { "nowrap" }));
        public static readonly StyleProperty<int> maxLines = new StyleProperty<int>("maxLines", (int) short.MaxValue, true, true);
        public static readonly StyleProperty<float> textStrokeWidth = new StyleProperty<float>("textStrokeWidth", 0f, true, true);
        public static readonly StyleProperty<Color> textStrokeColor = new StyleProperty<Color>("textStrokeColor", ComputedCurrentColor.Instance, true, true);
        public static readonly StyleProperty<string> content = new StyleProperty<string>("content", null, false);
        public static readonly StyleProperty<Appearance> appearance = new StyleProperty<Appearance>("appearance", Appearance.None);
        public static readonly StyleProperty<NavigationMode> navigation = new StyleProperty<NavigationMode>("navigation", NavigationMode.Automatic);
        public static readonly StyleProperty<float> stateDuration = new StyleProperty<float>("stateDuration", 0f, true, false, AllConverters.DurationConverter);
        public static readonly StyleProperty<ObjectFit> objectFit = new StyleProperty<ObjectFit>("objectFit", ObjectFit.Fill);
        public static readonly StyleProperty<YogaValue2> objectPosition = new StyleProperty<YogaValue2>("objectPosition", YogaValue2.Center, true);

        public static readonly ValueListStyleProperty<BoxShadow> boxShadow = new ValueListStyleProperty<BoxShadow>("boxShadow", BoxShadow.Default, true);

        public static readonly StyleProperty<Color> backgroundColor = new StyleProperty<Color>("backgroundColor", new Color(0, 0, 0, 0), true);
        public static readonly ValueListStyleProperty<ImageDefinition> backgroundImage = new ValueListStyleProperty<ImageDefinition>("backgroundImage");
        public static readonly ValueListStyleProperty<YogaValue2> backgroundPosition = new ValueListStyleProperty<YogaValue2>("backgroundPosition");
        public static readonly ValueListStyleProperty<YogaValue2> backgroundSize = new ValueListStyleProperty<YogaValue2>("backgroundSize");
        public static readonly StyleProperty<BackgroundBlendMode> backgroundBlendMode = new StyleProperty<BackgroundBlendMode>("backgroundBlendMode", BackgroundBlendMode.Normal);

        public static readonly ValueListStyleProperty<TransitionProperty> transitionProperty = new ValueListStyleProperty<TransitionProperty>("transitionProperty");
        public static readonly ValueListStyleProperty<float> transitionDuration = new ValueListStyleProperty<float>("transitionDuration");
        public static readonly ValueListStyleProperty<TimingFunction> transitionTimingFunction = new ValueListStyleProperty<TimingFunction>("transitionTimingFunction", TimingFunctions.Default);
        public static readonly ValueListStyleProperty<float> transitionDelay = new ValueListStyleProperty<float>("transitionDelay");
        public static readonly ValueListStyleProperty<AnimationPlayState> transitionPlayState = new ValueListStyleProperty<AnimationPlayState>("transitionPlayState");

        public static readonly StyleProperty<float> motionDuration = new StyleProperty<float>("motionDuration", 0f, false);
        public static readonly StyleProperty<TimingFunction> motionTimingFunction = new StyleProperty<TimingFunction>("motionTimingFunction", TimingFunctions.Default, false);
        public static readonly StyleProperty<float> motionDelay = new StyleProperty<float>("motionDelay", 0f, false);

        public static readonly ValueListStyleProperty<float> animationDelay = new ValueListStyleProperty<float>("animationDelay");
        public static readonly ValueListStyleProperty<AnimationDirection> animationDirection = new ValueListStyleProperty<AnimationDirection>("animationDirection");
        public static readonly ValueListStyleProperty<float> animationDuration = new ValueListStyleProperty<float>("animationDuration");
        public static readonly ValueListStyleProperty<AnimationFillMode> animationFillMode = new ValueListStyleProperty<AnimationFillMode>("animationFillMode");
        public static readonly ValueListStyleProperty<int> animationIterationCount = new ValueListStyleProperty<int>("animationIterationCount", 1, baseConverter: AllConverters.IterationCountConverter);
        public static readonly ValueListStyleProperty<string> animationName = new ValueListStyleProperty<string>("animationName");
        public static readonly ValueListStyleProperty<AnimationPlayState> animationPlayState = new ValueListStyleProperty<AnimationPlayState>("animationPlayState");
        public static readonly ValueListStyleProperty<TimingFunction> animationTimingFunction = new ValueListStyleProperty<TimingFunction>("animationTimingFunction", TimingFunctions.Default);

        public static readonly ValueListStyleProperty<AudioReference> audioClip = new ValueListStyleProperty<AudioReference>("audioClip");
        public static readonly ValueListStyleProperty<int> audioIterationCount = new ValueListStyleProperty<int>("audioIterationCount", 1);
        public static readonly ValueListStyleProperty<float> audioDelay = new ValueListStyleProperty<float>("audioDelay");

        public static readonly Dictionary<string, IStyleProperty> PropertyMap = new Dictionary<string, IStyleProperty>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "opacity", opacity },
            { "zIndex", zIndex },
            { "visibility", visibility },
            { "position", position },
            { "cursor", cursor },
            { "pointerEvents", pointerEvents },
            { "maskImage", maskImage },
            { "borderTopLeftRadius", borderTopLeftRadius },
            { "borderTopRightRadius", borderTopRightRadius },
            { "borderBottomLeftRadius", borderBottomLeftRadius },
            { "borderBottomRightRadius", borderBottomRightRadius },
            { "borderLeftColor", borderLeftColor },
            { "borderRightColor", borderRightColor },
            { "borderTopColor", borderTopColor },
            { "borderBottomColor", borderBottomColor },
            { "boxShadow", boxShadow },
            { "transformOrigin", transformOrigin },
            { "translate", translate },
            { "scale", scale },
            { "rotate", rotate },
            { "fontFamily", fontFamily },
            { "color", color },
            { "fontWeight", fontWeight },
            { "fontStyle", fontStyle },
            { "fontSize", fontSize },
            { "lineHeight", lineHeight },
            { "letterSpacing", letterSpacing },
            { "wordSpacing", wordSpacing },
            { "textAlign", textAlign },
            { "textOverflow", textOverflow },
            { "textWrap", textWrap },
            { "maxLines", maxLines },
            { "lineClamp", maxLines },
            { "textStrokeWidth", textStrokeWidth },
            { "textStrokeColor", textStrokeColor },
            { "content", content },
            { "appearance", appearance },
            { "navigation", navigation },
            { "stateDuration", stateDuration },
            { "objectFit", objectFit },
            { "objectPosition", objectPosition },

            { "backgroundColor", backgroundColor },
            { "backgroundImage", backgroundImage },
            { "backgroundPosition", backgroundPosition },
            { "backgroundSize", backgroundSize },
            { "backgroundBlendMode", backgroundBlendMode },

            { "transitionProperty", transitionProperty },
            { "transitionDuration", transitionDuration },
            { "transitionTimingFunction", transitionTimingFunction },
            { "transitionDelay", transitionDelay },
            { "transitionPlayState", transitionPlayState },

            { "transition-property", transitionProperty },
            { "transition-duration", transitionDuration },
            { "transition-timing-function", transitionTimingFunction },
            { "transition-delay", transitionDelay },
            { "transition-play-state", transitionPlayState },

            { "motionDuration", motionDuration },
            { "motionTimingFunction", motionTimingFunction },
            { "motionDelay", motionDelay },

            { "motion-duration", motionDuration },
            { "motion-timing-function", motionTimingFunction },
            { "motion-delay", motionDelay },

            { "animationDelay", animationDelay },
            { "animationDirection", animationDirection },
            { "animationDuration", animationDuration },
            { "animationFillMode", animationFillMode },
            { "animationIterationCount", animationIterationCount },
            { "animationName", animationName },
            { "animationPlayState", animationPlayState },
            { "animationTimingFunction", animationTimingFunction },

            { "animation-delay", animationDelay },
            { "animation-direction", animationDirection },
            { "animation-duration", animationDuration },
            { "animation-fill-mode", animationFillMode },
            { "animation-iteration-count", animationIterationCount },
            { "animation-name", animationName },
            { "animation-play-state", animationPlayState },
            { "animation-timing-function", animationTimingFunction },

            { "audioClip", audioClip },
            { "audioDelay", audioDelay },
            { "audioIterationCount", audioIterationCount },

            { "audio-clip", audioClip },
            { "audio-delay", audioDelay },
            { "audio-iteration-count", audioIterationCount },

            { "z-index", zIndex },
            { "pointer-events", pointerEvents },
            { "background-color", backgroundColor },
            { "background-image", backgroundImage },
            { "background-position", backgroundPosition },
            { "background-size", backgroundSize },
            { "background-blend-mode", backgroundBlendMode },
            { "mask-image", maskImage },
            { "border-top-left-radius", borderTopLeftRadius },
            { "border-top-right-radius", borderTopRightRadius },
            { "border-bottom-left-radius", borderBottomLeftRadius },
            { "border-bottom-right-radius", borderBottomRightRadius },
            { "border-left-color", borderLeftColor },
            { "border-right-color", borderRightColor },
            { "border-top-color", borderTopColor },
            { "border-bottom-color", borderBottomColor },
            { "box-shadow", boxShadow },
            { "transform-origin", transformOrigin },
            { "font-family", fontFamily },
            { "font-weight", fontWeight },
            { "font-style", fontStyle },
            { "text-decoration", fontStyle },
            { "font-size", fontSize },
            { "line-height", lineHeight },
            { "letter-spacing", letterSpacing },
            { "word-spacing", wordSpacing },
            { "text-align", textAlign },
            { "text-overflow", textOverflow },
            { "text-wrap", textWrap },
            { "max-lines", maxLines },
            { "line-clamp", maxLines },
            { "text-stroke-color", textStrokeColor },
            { "text-stroke-width", textStrokeWidth },
            { "white-space", textWrap },
            { "object-fit", objectFit },
            { "object-position", objectPosition },
            { "state-duration", stateDuration },
        };
    }
}
