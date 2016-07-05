using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;

public class FileManagerScript : MonoBehaviour {

    string[] paths;

    public int currentLevel;
    public int[] Items;

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        paths = new string[2];
        paths[0] = Application.persistentDataPath + @"/CurrentLevel.txt";
        paths[1] = Application.persistentDataPath + @"/Items.txt";

        currentLevel = 0;
        Items = new int[10];
        if (!filesExist())
        {
            createNewFiles();
        }
       
    }

    void Start()
    {
       
    }

    bool filesExist()
    {
        foreach (string path in paths)
        {
            if (!File.Exists(path))
            {
                return false;
            }
        }

        return true;
    }

    public void createNewFiles()
    {

        byte[] info;

        for (int i = 0; i < paths.Length; i++)
        {
            //Deleta os arquivos.
            if (File.Exists(paths[i]))
            {
                File.Delete(paths[i]);

            }

            FileStream fs = File.Create(paths[i]);

            switch (i)
            {
                case 0:
                    info = new UTF8Encoding(true).GetBytes("0" + Environment.NewLine);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                    Debug.Log("FileCreated");
                    Debug.Log(paths[0]);
                    break;
                case 1:
                    info = new UTF8Encoding(true).GetBytes("5" + Environment.NewLine + "3" + Environment.NewLine + "0" + Environment.NewLine + "0" + Environment.NewLine
                        + "1" + Environment.NewLine + "1" + Environment.NewLine + "1" + Environment.NewLine + "1" + Environment.NewLine + "1" + Environment.NewLine + "1" + Environment.NewLine);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                    break;
                default:
                    Debug.Log("Erro!!!");
                    break;
            }



        }

    }

    public void checkFiles()
    {
        bool fileExist = true;
        for (int i = 0; i < paths.Length; i++)
        {

            if (!File.Exists(paths[i]))
            {
                fileExist = false;

            }
        }
        //Se algum arquivo não existir.
        if (!fileExist)
        {
            //Chama o newGame.
            createNewFiles();
        }
    }

    public void readData()
    {

        string[] myLevel =  File.ReadAllLines(paths[0]);
        string[] myItems = File.ReadAllLines(paths[1]);

        

        for (int i = 0; i < myLevel.Length; i++)
        {
            currentLevel = int.Parse(myLevel[i].Trim());
        }

        for (int i = 0; i < myItems.Length; i++)
        {
            Items[i] = int.Parse(myItems[i].Trim());
        }

        foreach (int i in Items)
        {
            //Debug.Log(i);
        }

    }

    public void writeData(int [] myItems)
    {
        if (currentLevel < 2)
        {
            currentLevel++;
        }

        FileStream fs1 = File.OpenWrite(paths[0]);
        FileStream fs2 = File.OpenWrite(paths[1]);
       



        byte[] info1;
        byte[] info2;


        info1 = new UTF8Encoding(true).GetBytes(currentLevel.ToString() + Environment.NewLine);
        fs1.Write(info1, 0, info1.Length);

        info2 = new UTF8Encoding(true).GetBytes(myItems[0].ToString() + Environment.NewLine
           + myItems[1].ToString() + Environment.NewLine + myItems[2].ToString() + Environment.NewLine
           + myItems[3].ToString() + Environment.NewLine + myItems[4].ToString() + Environment.NewLine
           + myItems[5].ToString() + Environment.NewLine + myItems[6].ToString() + Environment.NewLine
           + myItems[7].ToString() + Environment.NewLine + myItems[8].ToString() + Environment.NewLine
           + myItems[9].ToString() + Environment.NewLine);
        // Add some information to the file.
       
        fs2.Write(info2, 0, info2.Length);




    }
}

