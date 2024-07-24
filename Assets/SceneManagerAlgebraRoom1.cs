using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerAlgebraRoom1 : MonoBehaviour
{
    [SerializeField] private List<BoxTriggerAlgebraRoom1> boxesTrigger;

    private void Awake() {
        Debug.Log(EvaluateExpression("10 - 5 * 1"));
    }

    private void Update()
    {
        CheckExpression();
    }
    private bool IsAnyBoxesTargetNull()
    {
        foreach (var box in boxesTrigger)
        {
            if(box.target == null) return true;

        }
        return false;
    }
    private bool isAllCorrectBoxes()
    {
        foreach (var box in boxesTrigger)
        {
            if(!box.isCorrect) return false;
        }
        return true;
    }
    private string GetExpressionText()
    {
        var finalText = "";
        foreach(var box in boxesTrigger)
        {
            TextMeshProUGUI textPro = box.target.GetComponentInChildren<TextMeshProUGUI>();
            if (textPro != null)
            {
                finalText += textPro.text;
            }
            else
            {
                Debug.Log("Error");
            }
        }
        Debug.Log(finalText);
        return finalText;
    }
    private void CheckExpression()
    {
        if(IsAnyBoxesTargetNull()) return;
        if(!isAllCorrectBoxes()) return;
        var textExpression = GetExpressionText();

        var listParts = textExpression.Split("=");
        if (listParts.Length == 2)
        {
            var leftNumber = EvaluateExpression(listParts[0]);
            var rightNumber = EvaluateExpression(listParts[1]);
            if (leftNumber == rightNumber)
            {
                Debug.Log("yes");
            }
        }


    }
    private double EvaluateExpression(string expression)
    {
        string rpn = InfixToRPN(expression);
        return EvaluateRPN(rpn);
    }

    private string InfixToRPN(string infix)
    {
        Stack<char> operators = new Stack<char>();
        Queue<string> output = new Queue<string>();
        int i = 0;

        while (i < infix.Length)
        {
            if (char.IsDigit(infix[i]))
            {
                string number = "";
                while (i < infix.Length && char.IsDigit(infix[i]))
                {
                    number += infix[i];
                    i++;
                }
                output.Enqueue(number);
            }
            else if ("+-*/".Contains(infix[i]))
            {
                while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(infix[i]))
                {
                    output.Enqueue(operators.Pop().ToString());
                }
                operators.Push(infix[i]);
                i++;
            }
            else
            {
                i++;
            }
        }

        while (operators.Count > 0)
        {
            output.Enqueue(operators.Pop().ToString());
        }

        return string.Join(" ", output);
    }

    private int Precedence(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }

    private double EvaluateRPN(string rpn)
    {
        Stack<double> stack = new Stack<double>();
        string[] tokens = rpn.Split(' ');

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else if ("+-*/".Contains(token))
            {
                double b = stack.Pop();
                double a = stack.Pop();
                switch (token)
                {
                    case "+":
                        stack.Push(a + b);
                        break;
                    case "-":
                        stack.Push(a - b);
                        break;
                    case "*":
                        stack.Push(a * b);
                        break;
                    case "/":
                        stack.Push(a / b);
                        break;
                }
            }
        }

        return stack.Pop();
    }
}
