using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Data;

public class ConsecutiveMathGame : MonoBehaviour
{
	[SerializeField] TMP_Text mathQuestionText;
	[SerializeField] GameObject correctAnswerScreen;
	[SerializeField] GameObject wrongAnswerScreen;

	[SerializeField] string currentQuestion;

	[SerializeField, ReadOnlyInspector] double result;
	private void Awake()
	{
		currentQuestion = $"{Random.Range(2, 11)} + {Random.Range(2, 11)}";

		mathQuestionText.text = currentQuestion + " =";


		result = Evaluate(currentQuestion);
	}
	public void SetAnswer(double answer)
	{
		//if(answer == result)

	}
	void SetNewOperation()
	{

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
