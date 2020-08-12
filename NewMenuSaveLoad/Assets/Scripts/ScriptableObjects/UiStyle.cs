
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum TypeUI{Color, Sprite,Animation}
    [CreateAssetMenu(fileName = "UiStyle", menuName = "UIStyle", order = 0)]
    public class UiStyle : ScriptableObject
    {
        public TypeUI typeUi;
        public Color TitleBoxBGColor;
        public Color ContentBoxBGColor;
        public Color ButtonBGColor;
        [FormerlySerializedAs("colors")]
        [SerializeField]
        public Selectable selectable;
        
        public Color TextColor;


    }

