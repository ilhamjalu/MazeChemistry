using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContentManager : MonoBehaviour
{
    public DataManager[] dataManagers;
    [SerializeField] GameObject panelParent;
    [SerializeField] string nowPanel;
    [SerializeField] int indexContent = 1;
    [SerializeField] int indexPanel;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject prevButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("LENGHT : " + dataManagers[indexPanel].textContent.Length);
        if (CanNext())
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }

        if (CanPrev())
        {
            prevButton.SetActive(true);
        }
        else
        {
            prevButton.SetActive(false);
        }
    }

    bool CanNext()
    {
        int temp = dataManagers[indexPanel].textContent.Length;

        if (indexContent == temp)
        {
            return false;
        }

        return true;
    }

    bool CanPrev()
    {
        if (indexContent-1 <= 0)
        {
            return false;
        }

        return true;
    }

    public void ButtonShowPanel(string panelName)
    {
        nowPanel = panelName;
        panelParent.SetActive(true);

        Debug.Log(panelName);

        for(int i = 0; i < dataManagers.Length; i++)
        {
            if(dataManagers[i].title == panelName)
            {
                indexPanel = i;
                break;
            }
        }
        
        foreach(Transform temp in panelParent.transform.GetChild(2))
        {
            if (temp.name == panelName)
            {
                temp.gameObject.SetActive(true);
                Debug.Log("MASK");
            }
            else
            {
                temp.gameObject.SetActive(false);
            }
        }
    }

    public void NextContentButton()
    {
        for (int i = 0; i < dataManagers.Length; i++)
        {
            if (dataManagers[i].title == nowPanel)
            {
                for(int j = 0; j < dataManagers[i].textContent.Length; j++)
                {
                    if (dataManagers[i].textContent[j].activeInHierarchy)
                    {
                        indexContent += 1;

                        if (j + 1 == dataManagers[i].textContent.Length)
                        {
                            return;
                        }
                        else
                        {
                            dataManagers[i].textContent[j].gameObject.SetActive(false);
                            dataManagers[i].textContent[j + 1].gameObject.SetActive(true);
                            return;
                        }
                    }
                }
            }
        }
    }

    public void BackContentButton()
    {
        for (int i = 0; i < dataManagers.Length; i++)
        {
            if (dataManagers[i].title == nowPanel)
            {
                for(int j = 0; j < dataManagers[i].textContent.Length; j++)
                {
                    if (dataManagers[i].textContent[j].activeInHierarchy)
                    {
                        indexContent -= 1;

                        if (j - 1 < 0)
                        {
                            return;
                        }
                        else
                        {
                            dataManagers[i].textContent[j].gameObject.SetActive(false);
                            dataManagers[i].textContent[j - 1].gameObject.SetActive(true);
                            return;
                        }
                    }
                }
            }
        }
    }

    public void ButtonClosePanel()
    {
        panelParent.SetActive(false);
        indexContent = 1;
    }

    public void PlayButton()
    {
        if(PlayerPrefs.GetInt("Level") == 2)
        {
            SceneManager.LoadScene("Level_2 New");
        }
        else
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
