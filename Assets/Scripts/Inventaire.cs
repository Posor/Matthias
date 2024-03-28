using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<ItemData> content = new List<ItemData>();           //Création  d'une liste de type ItemData afin de pouvoir stocker

    [SerializeField]
    public Transform inventorySlotsParents;

    [SerializeField]
    private Sprite emptySlotVisual;

    [SerializeField]
    private GameObject inventoryPanel;                              

    const int INVENTORYSIZE = 8;                                    //Taille maximum de l'inventaire

    [Header("Action Panel References")]

    [SerializeField]
    private GameObject actionPanel;

    [SerializeField]
    private GameObject useItemButton;

    [SerializeField]
    private GameObject dropItemButton;

    [SerializeField]
    private GameObject readItemButton;

    [SerializeField]
    private Transform dropPoint;

    private ItemData itemCurrentlySelected;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    public void RefreshContent()                                                                 //Fonction permettant d'actualiser les images dans l'inventaire
    {
        for (int i = 0; i < inventorySlotsParents.childCount; i++)
        {
            Slot currentSlot = inventorySlotsParents.GetChild(i).GetComponent<Slot>();
            currentSlot.item = null;
            currentSlot.itemVisual.sprite = emptySlotVisual;
        }

        for (int i = 0; i < content.Count; i++)                                                  //On peuple le visuel des slots selon le contenu réel de l'inventaire
        {
            Slot currentSlot = inventorySlotsParents.GetChild(i).GetComponent<Slot>();
            currentSlot.item = content[i];
            currentSlot.itemVisual.sprite = content[i].visual;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))                             //Si l'on appuit sur I
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);   //L'inventaire prend l'état opposé de celui auquelle il est actuellement
        }

    }

    public bool IsFull()
    {
        return INVENTORYSIZE == content.Count;                      //si taille inventaire max = taille actuel alors l'inventaire est plein
    }

    public void OpenActionPanel(ItemData item, Vector3 slotPosition)
    {
        itemCurrentlySelected = item;                               

        if (item == null)                                           //Si il n'y a pas d'objet dans l'inventaire
        {
            actionPanel.SetActive(false);
            return;                                                 //Alors quitte la fonction OpenActionPanel
        }

        switch (item.itemType)                                      //Selon le type de notre item
        {
            case ItemType.Decor:                                    //Dans le cas ou l'item est juste du décor
                readItemButton.SetActive(false);                    //Désactiver le bouton 
                useItemButton.SetActive(false);
                break;
            case ItemType.Enigme:
                readItemButton.SetActive(false);
                break;
        }
        actionPanel.transform.position = slotPosition;
        actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        actionPanel.SetActive(false);
        itemCurrentlySelected = null;
    }

    public void DropActionButton()
    {
        GameObject instantiatedItem = Instantiate(itemCurrentlySelected.prefab);
        instantiatedItem.transform.position = dropPoint.position;
        content.Remove(itemCurrentlySelected);
        RefreshContent();
        CloseActionPanel();

    }
}

