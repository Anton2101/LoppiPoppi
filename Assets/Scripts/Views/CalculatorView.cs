using UnityEngine;
using UnityEngine.UI;
using ViewModels;

namespace Views
{
    public class CalculatorView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button number0;
        [SerializeField] private Button number1;
        [SerializeField] private Button number2;
        [SerializeField] private Button number3;
        [SerializeField] private Button number4;
        [SerializeField] private Button number5;
        [SerializeField] private Button number6;
        [SerializeField] private Button number7;
        [SerializeField] private Button number8;
        [SerializeField] private Button number9;
        [SerializeField] private Button division;
        [SerializeField] private Button multiplication;
        [SerializeField] private Button subtraction;
        [SerializeField] private Button addition;
        [SerializeField] private Button equals;

        [Header("Result Field")]
        [SerializeField] private Text resultField;

        [Header("View Model")]
        [SerializeField] private CalculatorViewModel calculatorViewModel;

        private void OnEnable()
        {
            if (calculatorViewModel)
            {
                if (number0) number0.onClick.AddListener(() => calculatorViewModel.ButtonClicked("0"));
                if (number1) number1.onClick.AddListener(() => calculatorViewModel.ButtonClicked("1"));
                if (number2) number2.onClick.AddListener(() => calculatorViewModel.ButtonClicked("2"));
                if (number3) number3.onClick.AddListener(() => calculatorViewModel.ButtonClicked("3"));
                if (number4) number4.onClick.AddListener(() => calculatorViewModel.ButtonClicked("4"));
                if (number5) number5.onClick.AddListener(() => calculatorViewModel.ButtonClicked("5"));
                if (number6) number6.onClick.AddListener(() => calculatorViewModel.ButtonClicked("6"));
                if (number7) number7.onClick.AddListener(() => calculatorViewModel.ButtonClicked("7"));
                if (number8) number8.onClick.AddListener(() => calculatorViewModel.ButtonClicked("8"));
                if (number9) number9.onClick.AddListener(() => calculatorViewModel.ButtonClicked("9"));

                if (division) division.onClick.AddListener(() => calculatorViewModel.ButtonClicked("division"));
                if (multiplication)
                    multiplication.onClick.AddListener(() => calculatorViewModel.ButtonClicked("multiplication"));
                if (subtraction)
                    subtraction.onClick.AddListener(() => calculatorViewModel.ButtonClicked("subtraction"));
                if (addition) addition.onClick.AddListener(() => calculatorViewModel.ButtonClicked("addition"));
                if (equals) equals.onClick.AddListener(() => calculatorViewModel.ButtonClicked("equals"));
            }
        }

        private void OnDisable()
        {
            if (number0) number0.onClick.RemoveAllListeners();
            if (number1) number1.onClick.RemoveAllListeners();
            if (number2) number2.onClick.RemoveAllListeners();
            if (number3) number3.onClick.RemoveAllListeners();
            if (number4) number4.onClick.RemoveAllListeners();
            if (number5) number5.onClick.RemoveAllListeners();
            if (number6) number6.onClick.RemoveAllListeners();
            if (number7) number7.onClick.RemoveAllListeners();
            if (number8) number8.onClick.RemoveAllListeners();
            if (number9) number9.onClick.RemoveAllListeners();

            if (division) division.onClick.RemoveAllListeners();
            if (multiplication) multiplication.onClick.RemoveAllListeners();
            if (subtraction) subtraction.onClick.RemoveAllListeners();
            if (addition) addition.onClick.RemoveAllListeners();
            if (equals) equals.onClick.RemoveAllListeners();
        }

        public void RenderResult(string result) => resultField.text = result;
    }
}