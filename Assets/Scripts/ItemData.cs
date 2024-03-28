using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New item")]

public class ItemData : ScriptableObject        //Instance d'objet (non physique)
{
    public string name;                         //Nom de l'objet
    public string description;
    public Sprite visual;                       //Son image 2D
    public GameObject prefab;                   //Son image 3D dans le jeu

    public ItemType itemType;
}

public enum ItemType                            //Fonction permettant de lister les différents types d'objet
{
    Decor,
    Enigme,
    LireEnigme,

}

