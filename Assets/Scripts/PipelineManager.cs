using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineManager : MonoBehaviour {

    public GameObject template;
    List<Pipeline> pipelines = new List<Pipeline>();

    Coroutine runner = null;
    public void Init()
    {
        for (int i = 0; i < pipelines.Count; ++i)
        {
            Destroy(pipelines[i].gameObject);
        }
        pipelines.Clear();
    }

    public void StartRun()
    {
        runner = StartCoroutine(GeneratePipelines());
    
    }

    public void Stop()
    {
        StopCoroutine(runner);
        for(int i = 0;i<pipelines.Count;++i)
        {
            pipelines[i].enabled = false;
        }
    }

    IEnumerator GeneratePipelines()
    {
        for(int i = 0;i<3; ++i)
        {
            if(pipelines.Count<3)
                CreatePipeline();
            else
            {
                pipelines[i].Init();
                pipelines[i].enabled = true;
            }
            yield return new WaitForSeconds(2f);
        }
    }

    void CreatePipeline()
    {
        if (pipelines.Count < 3)
        {
            GameObject obj = Instantiate(template, this.transform);
            pipelines.Add(obj.GetComponent<Pipeline>());
        }
    }
}
