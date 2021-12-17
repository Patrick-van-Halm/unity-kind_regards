using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.Events;

public class FillMotivationalTextsUI : MonoBehaviour
{
    public WebRequest GetMotivationalMessagesRequest;
    public GameObject MotivationalMessagesUIPrefab;
    public GameObject TargetToFill;
    public UnityEvent<MotivationalText> OnMotivationalTextSelected;

    void Start()
    {
        GetMotivationalMessagesRequest.Execute();
    }

    public void OnRequestFinished(UnityWebRequest request)
    {
        if (request.result != UnityWebRequest.Result.Success) return;

        List<MotivationalText> texts = JsonConvert.DeserializeObject<List<MotivationalText>>(request.downloadHandler.text);
        foreach(MotivationalText text in texts)
        {
            GameObject obj = Instantiate(MotivationalMessagesUIPrefab, TargetToFill.transform);
            var ui = obj.GetComponent<MotivationalTextUI>();
            ui.SetText(text.Text);
            ui.OnMotivationalTextSelect.AddListener(OnMotivationalTextSelect);
            obj.GetComponent<DataHolder>().Data = text;
        }

        var rect = TargetToFill.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, texts.Count * MotivationalMessagesUIPrefab.GetComponent<RectTransform>().sizeDelta.y);
    }

    private void OnMotivationalTextSelect(DataHolder data)
    {
        OnMotivationalTextSelected?.Invoke(data.Data as MotivationalText);
    }
}