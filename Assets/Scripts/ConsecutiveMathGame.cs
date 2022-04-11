using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Data;

public class ConsecutiveMathGame : MonoBehaviour
{
	[SerializeField] TMP_Text mathQuestionText;

	// Current Question
	[SerializeField, ReadOnlyInspector] int firstNumber;
	[SerializeField, ReadOnlyInspector] string operation;
	[SerializeField, ReadOnlyInspector] int secondNumber;

	[SerializeField] string currentQuestion;

	[SerializeField] List<char> temp;

	[SerializeField, ReadOnlyInspector] double result;
	private void Awake()
	{
		currentQuestion = $"{Random.Range(2, 11)} + {Random.Range(2, 11)}";

		mathQuestionText.text = currentQuestion + " =";


		result = Evaluate(currentQuestion);
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
