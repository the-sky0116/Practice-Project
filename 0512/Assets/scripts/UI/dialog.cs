using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    bool isInside;


    public TextAsset textFile;
    public int index;
    public float textSpeed;


    public GameObject TalkSprite;

    bool textFinished;

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);
    }
    void Start()
    {
        GetTextFormFile(textFile);
    }
    private void OnEnable()
    {
        dialogText.text = textList[index];
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)&&isInside&&index==textList.Count)
        {
            dialogBox.SetActive(true);
           
            
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            dialogText.text = textList[index];
            index++;
            if (index > 7)
            {
                dialogBox.SetActive(false);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D")
        {
            isInside = true;
            
            Debug.Log("In");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        isInside = false;
        Debug.Log("Exit");
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var LineDate = file.text.Split('\n') ;

        foreach(var Line in LineDate)
        {
            textList.Add(Line);
        }
    }
    IEnumerator SetTextUI()
    {
        for (int i = 0; i < textList[index].Length; i++)
        {
            dialogText.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
