using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Data;
using System;

public class ConsecutiveMathGame : MonoBehaviour
{
	[SerializeField] TMP_Text mathQuestionText;
	[SerializeField] GameObject correctAnswerScreen;
	[SerializeField] GameObject wrongAnswerScreen;
	[SerializeField] TMP_InputField answerText;

	[SerializeField] string currentQuestion;

	[SerializeField, ReadOnlyInspector] double result;
	private void Awake()
	{
		currentQuestion = $"{UnityEngine.Random.Range(2, 11)} + {UnityEngine.Random.Range(2, 11)}";

		mathQuestionText.text = currentQuestion + " =";

		result = Evaluate(currentQuestion);
	}
	public void SetAnswer(string answer)
	{
		if (answer == "") return;

		if (answer != Convert.ToString(result))
		{
			GameManager.instance.ChangeScene("Title");
			return;
		}
		correctAnswerScreen.SetActive(true);
		SetNewOperation();

	}
	void SetNewOperation()
	{
		currentQuestion = UnityEngine.Random.Range(1, 21) + " " + GetRandomOperation() + " " + UnityEngine.Random.Range(1, 21);

		mathQuestionText.text = currentQuestion + " =";

		result = Evaluate(currentQuestion);

		answerText.text = "";
	}

	string GetRandomOperation()
	{
		return "+";
	}
	public static double Evaluate(string expression)
	{
		DataTable table = new DataTable();
		table.Columns.Add("expression", typeof(string), expression);
		DataRow row = table.NewRow();
		table.Rows.Add(row);
		return double.Parse((string)row["expression"]);
	}
}
