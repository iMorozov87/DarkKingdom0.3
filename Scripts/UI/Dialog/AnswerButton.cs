using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _answerText;
    [SerializeField] private Button _answerButton;

    private Answer _currentAnswer;

    public Answer CurrentAnswer => _currentAnswer;

    public event UnityAction<AnswerButton> AnswerButtonClicked;

    private void OnEnable()
    { 
        _answerButton.onClick.AddListener(OnClickAnswerButton);
    }

    private void OnDisable()
    {
        _answerButton.onClick.RemoveListener(OnClickAnswerButton);
    }

    public void SetAnswer(Answer answer)
    {
        _currentAnswer = answer;
        _answerText.text = answer.Text;
    }    

    private void OnClickAnswerButton()
    {
        AnswerButtonClicked?.Invoke(this);        
    }
}
