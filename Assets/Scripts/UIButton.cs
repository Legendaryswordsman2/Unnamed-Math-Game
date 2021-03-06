using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

enum AnimationMode { None, ScaleWithPunch}
public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField] bool interactable = true;
	[Tooltip("The image component this script will utilize")]
	[SerializeField] Image targetGraphic;
	[Tooltip("The sprite of the iamge when the mouse is hovering over it")]
	[SerializeField] Sprite highlightedSprite;
	[Tooltip("The sprite of the image when the button is pressed (Leave blank to use default sprite)")]
	[SerializeField] Sprite pressedSprite;

	[Space]

	[SerializeField] AnimationMode animationMode = AnimationMode.None;

	[Space]

	[SerializeField] UnityEvent onClick;

	bool mouseIsOverImage = false;

	// Private
	Sprite defaultSprite;
	private void Awake()
	{
		defaultSprite = targetGraphic.sprite;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		mouseIsOverImage = true;

		if (!interactable) return;

		if (highlightedSprite == null)
			targetGraphic.sprite = defaultSprite;
		else
			targetGraphic.sprite = highlightedSprite;

		if(animationMode == AnimationMode.ScaleWithPunch)
		{
			LeanTween.cancel(gameObject);

			transform.localScale = Vector3.one;

			LeanTween.scale(gameObject, Vector3.one * 1.1f, 0.5f)
				.setEasePunch()
				.setIgnoreTimeScale(true);
		}


	}
	public void OnPointerExit(PointerEventData eventData)
	{
		mouseIsOverImage = false;

		if(interactable)
		targetGraphic.sprite = defaultSprite;
	}
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!interactable) return;

		if (pressedSprite != null)
			targetGraphic.sprite = pressedSprite;
		else
			targetGraphic.sprite = defaultSprite;

		onClick.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (!interactable) return;

		if (mouseIsOverImage)
			targetGraphic.sprite = highlightedSprite;
		else
			targetGraphic.sprite = defaultSprite;
	}

	private void OnDisable()
	{
		mouseIsOverImage = false;
	}

	private void OnValidate()
	{
		if (targetGraphic == null)
			targetGraphic = GetComponent<Image>();
	}
}
