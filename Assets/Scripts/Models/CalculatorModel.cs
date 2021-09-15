using System;
using UnityEngine;
using UnityEngine.Events;

namespace Models
{
    [Serializable]
    public class CalculatorModel
    {
        public string FirstOperand
        {
            get => _firstOperand;
            set
            {
                _firstOperand = value;
                PlayerPrefs.SetString("FirstOperand", value);
                PlayerPrefs.Save();
                ValuesChanged();
            }
        }

        public string SecondOperand
        {
            get => _secondOperand;
            set
            {
                _secondOperand = value;
                PlayerPrefs.SetString("SecondOperand", value);
                PlayerPrefs.Save();
                ValuesChanged();
            }
        }

        public string OperationString
        {
            get
            {
                if (_operation == OperationType.Division) return "/";
                if (_operation == OperationType.Multiplication) return "*";
                if (_operation == OperationType.Subtraction) return "-";
                if (_operation == OperationType.Addition) return "+";
                return "";
            }
        }

        public OperationType Operation
        {
            get => _operation;
            set
            {
                _operation = value;
                PlayerPrefs.SetString("Operation", value.ToString());
                PlayerPrefs.Save();
                ValuesChanged();
            }
        }

        public enum OperationType
        {
            Null = 0,
            Division = 1,
            Multiplication = 2,
            Subtraction = 3,
            Addition = 4
        }

        public OnValuesChanged onValuesChanged = new OnValuesChanged();

        private int _minValue = 0;
        private int _maxValue = int.MaxValue;

        private string _firstOperand = "";
        private string _secondOperand = "";

        private OperationType _operation = OperationType.Null;

        public void ValidateOperation(string operation)
        {
            switch (operation.ToLower())
            {
                case "division":
                    if (_firstOperand != "" && _operation == OperationType.Null)
                        Operation = OperationType.Division;
                    break;
                case "multiplication":
                    if (_firstOperand != "" && _operation == OperationType.Null)
                        Operation = OperationType.Multiplication;
                    break;
                case "subtraction":
                    if (_firstOperand != "" && _operation == OperationType.Null)
                        Operation = OperationType.Subtraction;
                    break;
                case "addition":
                    if (_firstOperand != "" && _operation == OperationType.Null)
                        Operation = OperationType.Addition;
                    break;
                case "equals":
                    if (_firstOperand != "" && _secondOperand != "" && _operation != OperationType.Null)
                    {
                        if (!float.TryParse(_firstOperand, out var firstOperand)) return;
                        if (!float.TryParse(_secondOperand, out var secondOperand)) return;

                        if (_operation == OperationType.Division)
                            FirstOperand = "" + (firstOperand / secondOperand);
                        if (_operation == OperationType.Multiplication)
                            FirstOperand = "" + (firstOperand * secondOperand);
                        if (_operation == OperationType.Subtraction)
                            FirstOperand = "" + (firstOperand - secondOperand);
                        if (_operation == OperationType.Addition)
                            FirstOperand = "" + (firstOperand + secondOperand);

                        SecondOperand = "";
                        Operation = OperationType.Null;

                        ValuesChanged();
                    }

                    break;
            }
        }

        public void ValidateOperand(string operand)
        {
            if (_operation == OperationType.Null)
            {
                string result = FirstOperand + operand;
                if (float.TryParse(result, out var value) && value >= _minValue && value <= _maxValue)
                    FirstOperand += operand;
            }
            else
            {
                string result = SecondOperand + operand;
                if (float.TryParse(result, out var value) && value >= _minValue && value <= _maxValue)
                    SecondOperand += operand;
            }
        }

        public void ValuesChanged() => onValuesChanged?.Invoke();
    }

    public class OnValuesChanged : UnityEvent
    {
    }
}