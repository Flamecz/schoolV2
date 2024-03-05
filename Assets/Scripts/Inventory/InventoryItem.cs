using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject sloted;
    public Unit item;
    public Image image;
    public Text countText;

    private float lastClickTime;
    private float doubleClickTimeThreshold = 0.5f;

    [HideInInspector]public int count = 1;
    [HideInInspector]public Transform parentAfterDrag;

    private void Start()
    {
        InitialiseItem(item);
    }

    public void InitialiseItem(Unit newItem)
    {
        item = newItem;
        image.sprite = newItem.sprite;
        RefreshCount();
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool textActive = count > 0;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

        if (Input.GetMouseButtonUp(1))
        {
            // Check if there's a valid item under the dragged item using PointerEventData
            InventoryItem hoveredItem = eventData.pointerEnter?.GetComponent<InventoryItem>();

            if (hoveredItem != null && hoveredItem != this)
            {
                FindObjectOfType<InvenotoryManagement>().mergeItems(item, count, hoveredItem);
                Destroy(gameObject);  // Destroy the dragged item
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - lastClickTime < doubleClickTimeThreshold)
            {
                OnDoubleClick();
            }
            lastClickTime = Time.time;
        }
    }

    void OnDoubleClick()
    {

        lastClickTime = Time.time;

        if (count > 1)
        {
            int split = Mathf.FloorToInt(count / 2f);

            // Ensure the item you're clicking is the one you want to split
            InventoryItem clickedItem = GetComponent<InventoryItem>();

            if (clickedItem != null)
            {
                FindObjectOfType<InvenotoryManagement>().splitItems(item, split);
                count -= split;
                RefreshCount();
            }
        }
    }
}
