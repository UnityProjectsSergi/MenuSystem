using System;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class MyButton : MonoBehaviour,ISelectHandler,IPointerClickHandler,ISelectable
{
    // Start is called before the first frame update
    [Serializable]
    /// <summary>
    /// Function definition for a button click event.
    /// </summary>
    public class ButtonClickedEvent : UnityEvent {}

    // Event delegates triggered on click.
    [FormerlySerializedAs("onClick")]
    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("sssssss");
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Selection");
        GetComponent<Image>().color = Color.red;
    }

    public bool IsSelectable()
    {
        throw new NotImplementedException();
    }

    public bool HitTest(Vector2 localPoint)
    {
        throw new NotImplementedException();
    }

    public bool Overlaps(Rect rectangle)
    {
        throw new NotImplementedException();
    }

    public void Select(VisualElement selectionContainer, bool additive)
    {
        Debug.Log("sssssssssssssssssssssd");
    }

    public void Unselect(VisualElement selectionContainer)
    {
        throw new NotImplementedException();
    }

    public bool IsSelected(VisualElement selectionContainer)
    {
        throw new NotImplementedException();
    }
}
