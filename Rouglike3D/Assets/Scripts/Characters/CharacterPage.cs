using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharacterPage : MonoBehaviour
{
    public string characterName;
    public Sprite characterImage;
    public int strength;
    public int defence;
    public int magic;

    public GameObject GreenBox;
    public GameObject GrayBox;

    public GameObject strenghtEmpty;
    public GameObject defenceEmpty;
    public GameObject magicEmpty;

    public Image Image;
    public TextMeshProUGUI Name;

    public void Start()
    {
        ShowStatistic();

    }

    public void Update()
    {
        Image.sprite = characterImage;
        Name.text = characterName;
        
    }





    public void ShowStatistic()
    {
        for (int i = 0; i < strength; i++)
        {
            GameObject newBox = (GameObject)GameObject.Instantiate(GreenBox, strenghtEmpty.transform);
            newBox.transform.SetParent(strenghtEmpty.transform);
            newBox.transform.position = newBox.transform.position + new Vector3(30 * i, 0, 0);
        }

        for (int i = strength; i < 10; i++)
        {
            GameObject newBox = (GameObject)GameObject.Instantiate(GrayBox, strenghtEmpty.transform);
            newBox.transform.SetParent(strenghtEmpty.transform);
            newBox.transform.position = newBox.transform.position + new Vector3(30 * i, 0, 0);
        }

        for (int i = 0; i < defence; i++)
        {
            GameObject newBox = (GameObject)GameObject.Instantiate(GreenBox, defenceEmpty.transform);
            newBox.transform.SetParent(defenceEmpty.transform);
            newBox.transform.position = newBox.transform.position + new Vector3(30 * i, 0, 0);
        }

        for (int i = defence; i < 10; i++)
        {
            GameObject newBox = (GameObject)GameObject.Instantiate(GrayBox, defenceEmpty.transform);
            newBox.transform.SetParent(defenceEmpty.transform);
            newBox.transform.position = newBox.transform.position + new Vector3(30 * i, 0, 0);
        }

        for (int i = 0; i < magic; i++)
        {
            GameObject newBox = (GameObject)GameObject.Instantiate(GreenBox, magicEmpty.transform);
            newBox.transform.SetParent(magicEmpty.transform);
            newBox.transform.position = newBox.transform.position + new Vector3(30 * i, 0, 0);
        }

        for (int i = magic; i < 10; i++)
        {
            GameObject newBox = (GameObject)GameObject.Instantiate(GrayBox, magicEmpty.transform);
            newBox.transform.SetParent(magicEmpty.transform);
            newBox.transform.position = newBox.transform.position + new Vector3(30 * i, 0, 0);
        }

    }
}



#if UNITY_EDITOR
[CustomEditor(typeof(CharacterPage))]
public class CharacterPageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CharacterPage characterPage = (CharacterPage)target;
        if (characterPage == null) return;
        GUILayout.Label("Name of character");
        characterPage.characterName = EditorGUILayout.TextField(characterPage.characterName);

        EditorGUILayout.Separator();

        //STATS
        GUILayout.Label("Stats");
        characterPage.strength = EditorGUILayout.IntSlider("Strength", characterPage.strength, 0, 10);
        characterPage.defence = EditorGUILayout.IntSlider("Defence", characterPage.defence, 0, 10);
        characterPage.magic = EditorGUILayout.IntSlider("Magic", characterPage.magic, 0, 10);

        EditorGUILayout.Separator();
        GUILayout.Label("Inspector");
        base.OnInspectorGUI();
    }
}

#endif