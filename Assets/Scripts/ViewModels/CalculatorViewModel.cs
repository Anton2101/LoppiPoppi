using Models;
using UnityEngine;
using Views;

namespace ViewModels
{
    public class CalculatorViewModel : MonoBehaviour
    {
        [SerializeField] private CalculatorView calculatorView;

        private CalculatorModel _calculatorModel;

        private void Start()
        {
            _calculatorModel = new CalculatorModel();
            _calculatorModel.onValuesChanged.AddListener(ChangeResult);

            if (PlayerPrefs.HasKey("FirstOperand"))
                _calculatorModel.ValidateOperand(PlayerPrefs.GetString("FirstOperand"));
            if (PlayerPrefs.HasKey("Operation"))
                _calculatorModel.ValidateOperation(PlayerPrefs.GetString("Operation"));
            if (PlayerPrefs.HasKey("SecondOperand"))
                _calculatorModel.ValidateOperand(PlayerPrefs.GetString("SecondOperand"));
        }

        public void ButtonClicked(string button)
        {
            switch (button)
            {
                case "division":
                case "multiplication":
                case "subtraction":
                case "addition":
                case "equals":
                    _calculatorModel.ValidateOperation(button);
                    break;
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    _calculatorModel.ValidateOperand(button);
                    break;
            }
        }

        private void ChangeResult()
        {
            string display = _calculatorModel.FirstOperand + " " + _calculatorModel.OperationString + " " +
                             _calculatorModel.SecondOperand;
            calculatorView.RenderResult(display);
        }
    }
}