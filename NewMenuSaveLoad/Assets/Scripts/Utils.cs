using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using System.Reflection;

namespace Assets.Scripts.Utils
{
    public static class Utils
    {
        public static string MakeString(string[] strgn)

        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in strgn)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
        public static bool NamespaceExists(string desiredNamespace)
        {
            
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach(Type type in assembly.GetTypes())
                {
                    if (type.Namespace == desiredNamespace)
                        return true;
                }
            }
            return false;
        }
    }
    public class FadeEffect
    {

        public static System.Collections.IEnumerator FadeCanvas(CanvasGroup canvas, float startAlpha, float endAlpha, float duration,float delay=0)
        {
            // keep track of when the fading started, when it should finish, and how long it has been running&lt;/p&gt; &lt;p&gt;&a
            var startTime = Time.time;
            Debug.Log(Time.time);
            var endTime = Time.time + duration;
            var elapsedTime = 0f;
            //yield return new WaitForSeconds(delay);
            // set the canvas to the start alpha – this ensures that the canvas is ‘reset’ if you fade it multiple times
            canvas.alpha = startAlpha;
            // loop repeatedly until the previously calculated end time
            while (Time.time <= endTime)
            {
                elapsedTime = Time.time - startTime; // update the elapsed time
                var percentage = 1 / (duration / elapsedTime); // calculate how far along the timeline we are
                if (startAlpha > endAlpha) // if we are fading out/down 
                {
                    canvas.alpha = startAlpha - percentage; // calculate the new alpha
                }
                else // if we are fading in/up
                {
                    canvas.alpha = startAlpha + percentage; // calculate the new alpha
                }

                yield return new WaitForEndOfFrame(); // wait for the next frame before continuing the loop
            }
            canvas.alpha = endAlpha; // force the alpha to the end alpha before finishing – this is here to mitigate any rounding errors, e.g. leaving the alpha at 0.01 instead of 0
        }
        public static System.Collections.IEnumerator FadeCanvas2(CanvasGroup cg, float start,float end, float lerpTime=0.5f)
        {
            float _timeStartLerping = Time.time;
            float timeSinceStarted = Time.time - _timeStartLerping;
            float pecentageComplete = timeSinceStarted / lerpTime;
            while (true)
            {
                 timeSinceStarted = Time.time - _timeStartLerping;
                pecentageComplete =timeSinceStarted / lerpTime;
                float currentValue = Mathf.Lerp(start, end, pecentageComplete);
                cg.alpha = currentValue;
                if (pecentageComplete >= 1.0)
                    break; 
                else
                yield return new WaitForEndOfFrame();

            }
            Debug.Log("done");
        }
        public static System.Collections.IEnumerator FadeCanvas2(CanvasGroup cg, float start, float end, System.Action callback, float lerpTime = 0.5f)
        {
            float _timeStartLerping = Time.time;
            float timeSinceStarted = Time.time - _timeStartLerping;
            float pecentageComplete = timeSinceStarted / lerpTime;
            while (true)
            {
                timeSinceStarted = Time.time - _timeStartLerping;
                pecentageComplete = timeSinceStarted / lerpTime;
                float currentValue = Mathf.Lerp(start, end, pecentageComplete);
                cg.alpha = currentValue;
                if (pecentageComplete >= 1.0)
                    break;
                else
                    yield return new WaitForSeconds(1);

            }
            callback();
            Debug.Log("done");
        }
        public static void FadeIn(Animator animator,System.Action action)
        {
            animator.SetBool("Fade", false);
            if (isPlaying(animator, "FadeOut"))
                action();
        }
        private static bool isPlaying(Animator anim, string state)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName(state) && anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
                return true;
            return false;
        }
    }
   public static class IMG2Sprite 
    {


        // This script loads a PNG or JPEG image from disk and returns it as a Sprite
        // Drop it on any GameObject/Camera in your scene (singleton implementation)
        //
        // Usage from any other script:
        // MySprite = IMG2Sprite.instance.LoadNewSprite(FilePath, [PixelsPerUnit (optional)])



        public static Sprite LoadNewSprite(string FilePath, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
        {
            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
            Texture2D SpriteTexture = LoadTexture(FilePath);
            Sprite NewSprite = Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);

            return NewSprite;
        }

        private static Texture2D LoadTexture(string FilePath)
        {

            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails

            Texture2D Tex2D;
            byte[] FileData;

            if (File.Exists(FilePath))
            {
                FileData = File.ReadAllBytes(FilePath);
                Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
                if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                    return Tex2D;                 // If data = readable -> return texture
            }
            return null;                     // Return null if load failed
        }
    }
    public static class ListExtensions
    {
        public static void Replace<T>(this List<T> list, Predicate<T> oldItemSelector, T newItem)
        {
            //check for different situations here and throw exception
            //if list contains multiple items that match the predicate
            //or check for nullability of list and etc ...
            var oldItemIndex = list.FindIndex(oldItemSelector);
            list[oldItemIndex] = newItem;
        }
    }
    /*public static bool ParseStringToEnum<T>(string s, out T enumValue) where T: struct, IComparable, IFormattable, IConvertible {
    foreach (T enumCandidate in System.Enum.GetValues(typeof(T))) {
        if (s == enumCandidate.ToString()) {
            enumValue = enumCandidate;
            return true;
        }
    }
     
    enumValue = default(T);
     
    return false;
    }*/

}
namespace System.Collections.Generic
{
    public static class Extensions
    {
        public static int Replace<T>(this IList<T> source, T oldValue, T newValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var index = source.IndexOf(oldValue);
            if (index != -1)
                source[index] = newValue;
            return index;
        }

        public static void ReplaceAll<T>(this IList<T> source, T oldValue, T newValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            int index = -1;
            do
            {
                index = source.IndexOf(oldValue);
                if (index != -1)
                    source[index] = newValue;
            } while (index != -1);
        }


        public static IEnumerable<T> Replace<T>(this IEnumerable<T> source, T oldValue, T newValue)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            return source.Select(x => EqualityComparer<T>.Default.Equals(x, oldValue) ? newValue : x);
        }
    }
}