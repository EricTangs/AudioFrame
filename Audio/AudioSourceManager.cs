using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager 
{


    List<AudioSource> allSources;


    GameObject ower;

    public AudioSourceManager(GameObject tmpOwer)
    {

        ower = tmpOwer;

        Initial();


    }


    public void Initial()
    {


        allSources = new List<AudioSource>();

        for (int i = 0; i < 5; i++)
        {

          AudioSource  tmpSources=   ower.AddComponent<AudioSource>();

          allSources.Add(tmpSources);
            
        }

        Debug.Log(allSources.Count);

        FreeAudioSource();


    }

    public void StopPlayingAudio(string clipName)
    {

        for (int i = 0; i < allSources.Count; i++)
        {

            if (allSources[i].isPlaying)
            {
                if (allSources[i].clip.name.Equals(clipName))
                {
                    allSources[i].Stop();
                }
            }
            
        }
          

    }



    public AudioSource GetFreeAudioSource()
    {

        for (int i = 0; i < allSources.Count; i++)
        {

            if (!allSources[i].isPlaying)

                return allSources[i];
            
        }


        AudioSource tmpSources = ower.AddComponent<AudioSource>();

        allSources.Add(tmpSources);

        return tmpSources;
    }


    public void FreeAudioSource2()
    {

        int tmpCount=0;
        for (int i = 0; i < allSources.Count; i++)
        {

            AudioSource tmpSournce = allSources[i];

            Debug.Log("i=="+i.ToString());

            if (!tmpSournce.isPlaying)
            {
                tmpCount++;

                Debug.Log("tmpCount=="+tmpCount);

                if (tmpCount > 1)
                {
                    Debug.Log("tmpCount 222==" + tmpCount);
                    allSources.Remove(tmpSournce);
                }

            }
        }

        Debug.Log(allSources.Count);
    }
    public void FreeAudioSource()
    {

        List<AudioSource> indexList = new List<AudioSource>();

  

        for (int i = 0; i < allSources.Count; i++)
        {

            if (!allSources[i].isPlaying)
            {

                indexList.Add(allSources[i]);

            }
            
        }

        if (indexList.Count > 2)
        {

            for (int i = 2; i < indexList.Count; i++)
            {

                allSources.Remove(indexList[i]);
                
            }

        }
        Debug.Log(allSources.Count);
        indexList.Clear();

       
    }



}
