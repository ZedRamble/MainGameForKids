using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetValueFuncs
{
    private int _debugReset;
    
    public CardData QuestionRandom(List<CardData> _questionsUsed, List<CardData> forQuestionCardData, TMP_Text questionText, FadeInEffect fadeInEffect)
    {
        CardData questionData;
        bool cardDataCheck = false;
        _debugReset = 0;
        do
        {
            int k = Random.Range(0, forQuestionCardData.Count-1);
            questionData = forQuestionCardData[k];
            cardDataCheck = CheckTwoValue(questionData, _questionsUsed);
            _debugReset++;
            
            if (_debugReset > 500)
                cardDataCheck = false;
            if (!cardDataCheck)
            {
                _questionsUsed.Add(questionData);
                questionText.text = $"Find {questionData.Identifier}";
                fadeInEffect.SetFadeValueText(questionText, Color.clear, Color.black, 1/2.3f);
            }
        } while (cardDataCheck);

        return questionData;
    }
    
    public void SetToImage(SpriteRenderer[] images,List<CardData> cardDatasA, List<CardData> cardDatasQ)
    {
        foreach (SpriteRenderer image in images)
        {
            CardData cardData = RandomChoise(cardDatasA, cardDatasQ);
            image.sprite = cardData.Sprite;
            image.sprite.name = cardData.Identifier;
        }
    }
    
    private CardData RandomChoise(List<CardData> cardDatasA, List<CardData> cardDatasQ)
    {
        int k = Random.Range(0, cardDatasA.Count-1);
        CardData cardData = cardDatasA[k];
        cardDatasQ.Add(cardData);
        cardDatasA.Remove(cardData);
        return cardData;
    }
    
    public void BounceEffectTurnOn(GameObject[] gameObjects)
    {
        foreach (GameObject gm in gameObjects)
            gm.GetComponent<BounceEffect>().TurnOnBounceEffect();
    }
    
    public void TurnOnAndOF(GameObject[] gameObjects, bool dothis)
    {
        foreach (GameObject gm in gameObjects)
            gm.SetActive(dothis);
    }
    
    public bool CheckTwoValue(CardData cardData, List<CardData> usedQuestion)
    {
        foreach (CardData ques in usedQuestion)
        { 
            if (ques.Identifier == cardData.Identifier)
                return true;
        }
        return false;
    }
}
