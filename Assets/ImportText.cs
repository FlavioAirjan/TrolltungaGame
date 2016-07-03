using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ImportText : MonoBehaviour
{


    bool coroutineIsRunning = false;

    public int limiteCaracteresPorLinha = 30;
    private int currentLine;
    List<string> list;

    [HideInInspector]
    public string[] text;

    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {
        currentLine = 0;
        list = arrumaTamanhoFrases(text, limiteCaracteresPorLinha);
        coroutine = AnimateText(list[currentLine]);
    }

    // Update is called once per frame
    void Update()
    {

        //Se tiver texto.
        if (text.Length > 0)
        {


            if (currentLine == 0)
            {
                //Debug.Log("Entrou");
                StartCoroutine(coroutine);
                //gameObject.GetComponent<Text>().text = list[currentLine];
                currentLine++;
                //Debug.Log("Passou!");
            }

            if (Input.GetKeyDown(KeyCode.G) || !coroutineIsRunning)
            {
                if (currentLine >= list.Count)
                {
                    text = null;
                    currentLine = 0;
                    gameObject.transform.parent.gameObject.SetActive(false);

                }
                else
                {
                    StopCoroutine(coroutine);
                    coroutine = AnimateText(list[currentLine]);
                    StartCoroutine(coroutine);

                    //gameObject.GetComponent<Text>().text = list[currentLine];
                    currentLine++;
                }
            }





        }

    }

    IEnumerator AnimateText(string strComplete)
    {
        coroutineIsRunning = true;

        int i = 0;

        gameObject.GetComponent<Text>().text = "";

        while (i < strComplete.Length)
        {
            gameObject.GetComponent<Text>().text += strComplete[i++];
            yield return new WaitForSeconds(0.05F);
        }


        if (i == strComplete.Length)
        {

            yield return new WaitForSeconds(1.0F);
            coroutineIsRunning = false;
        }
        else
        {
            coroutineIsRunning = false;
        }
    }

    //Essa função ajeita as frases para caber direito no dialogBox.
    List<string> arrumaTamanhoFrases(string[] texts, int limitPerLine)
    {

        List<string> list = new List<string>();

        int currentText = 0;
        string text = texts[currentText];

        int countChar = 0;

        string buffer = "";

        int numOfLines = 0;
        bool endOfText = false;



        //Percorre a frase toda.
        for (int i = 0; i < text.Length; i++)
        {

            //Toda vez que o quadro estiver todo preenchido.
            if (numOfLines == 3 || endOfText)
            {

                text.Substring(i, 1);

                if (buffer != "" && buffer != "\n")
                {
                    list.Add(buffer);
                    //gameObject.GetComponent<Text>().text = buffer;

                }
                ////Debug.Log(buffer);
                buffer = "";

                numOfLines = 0;
                countChar = 0;

                if (!endOfText)
                {
                    i--;
                }
                else
                {

                    //Pega o indice do próximo texto.
                    currentText++;
                    //Se o texto exisitir.

                    if (currentText < texts.Length)
                    {
                        text = texts[currentText];
                        ////Debug.Log(text);
                        endOfText = false;
                        i = -1;
                    }
                }

            }
            else
            {

                if (countChar == limitPerLine || text.Substring(i, 1) == "\n")
                {

                    numOfLines++;
                    countChar = 0;
                    if (text.Substring(i, 1) != "\n")
                    {
                        countChar++;
                        buffer += text.Substring(i, 1);
                    }
                }


                if (numOfLines < 3)
                {
                    countChar++;
                    buffer += text.Substring(i, 1);
                }

                if (i == text.Length - 1)
                {
                    endOfText = true;
                    i--;
                }

            }

        }





        return list;
    }
}
