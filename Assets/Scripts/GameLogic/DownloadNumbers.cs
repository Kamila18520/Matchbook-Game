using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Losuje na podstawie wubranego wczesniej poziomu trudnosci dwie pary cyfr
te ktore znajda sie w rownaniu i te na ktore zostana zamienione
generuje rownanie matematyczne i zamienia je na to z niewlasciwymi danymi

sprawdza czy wygenerowane rownanie faktycznie jest niewlasciwe


----------------------------------------------------------------------------------------------------------- */

public class DownloadNumbers : MonoBehaviour
{
    [SerializeField] private int maxAdditionValue = 99;
    [SerializeField] private int maxSubtractionValue = 99;
    [SerializeField] private int maxMultiplicationDivisionValue = 99;

    public string mode;
    public string difficulty;
    private int numberOfLines;
    private int randomNumber;

    private string[] linesEasyOryginalNumbers;
    private string[] linesEasyChangedNumbers;
    public char[] oryginalNumber;
    public char[] changedNumber;
    
    public bool allCharsFound = true;
    bool check;

    List<Action> methodList = new List<Action>();

    public int a;
    public int b;
    public int c;
    public int choseEquat;
    public string MathEquation;
    public string RandomEquation;
    public string ChangedRandomEquation;
    public int numbers;
    public char[] oryginalEquation;
    public char[] changedEquation;
    public int[] ints;
    public void Start()
    {

 
        methodList.Add(() => Dodawanie());
        methodList.Add(() => Odejmowanie());
        methodList.Add(() => Mnozenie());
        methodList.Add(() => Dzielenie());

        difficulty = ModeDifManager.difficulty;
        mode = ModeDifManager.mode;

        Choselvl();

    }

    private void Choselvl()
    {

        if (difficulty == "Easy")
        {
            EasyLevel();
        }
        else if (difficulty == "Medium")
        {
            MediumLevel();
        }
        else if (difficulty == "Hard")
        {
            HardLevel();
        }

    }

    private void EasyLevel()
    {
        TextAsset easyOryginalNumbers = Resources.Load<TextAsset>("EasyOryginalNumbers");
        TextAsset easyChangedNumbers = Resources.Load<TextAsset>("EasyChangedNumbers");

        linesEasyOryginalNumbers = easyOryginalNumbers.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        linesEasyChangedNumbers = easyChangedNumbers.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        RandomNumbers();
    }

    private void MediumLevel()
    {
        TextAsset easyOryginalNumbers = Resources.Load<TextAsset>("MediumOryginalNumbers");
        TextAsset easyChangedNumbers = Resources.Load<TextAsset>("MediumChangedNumbers");

        linesEasyOryginalNumbers = easyOryginalNumbers.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        linesEasyChangedNumbers = easyChangedNumbers.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        RandomNumbers();
    }

    private void HardLevel()
    {
        TextAsset easyOryginalNumbers = Resources.Load<TextAsset>("HardOryginalNumbers");
        TextAsset easyChangedNumbers = Resources.Load<TextAsset>("HardChangedNumbers");

        linesEasyOryginalNumbers = easyOryginalNumbers.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        linesEasyChangedNumbers = easyChangedNumbers.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        RandomNumbers();
    }

    private void RandomNumbers()
    {
        numberOfLines = linesEasyChangedNumbers.Length;
        randomNumber = UnityEngine.Random.Range(0, numberOfLines);

        Debug.Log("INFORMACYJNIE wylosowana linijka to: " + randomNumber);
        Debug.Log("INFORMACYJNIE cyfry w grze to: " + linesEasyOryginalNumbers[randomNumber]);
        Debug.Log("INFORMACYJNIE zamienione na: " + linesEasyChangedNumbers[randomNumber]);

        oryginalNumber = linesEasyOryginalNumbers[randomNumber].ToCharArray();
        changedNumber = linesEasyChangedNumbers[randomNumber].ToCharArray();

        CheckIfThereASign();

    }

    private void CheckIfThereASign()
    {


        check = linesEasyOryginalNumbers[randomNumber].Contains("+") || linesEasyOryginalNumbers[randomNumber].Contains( "-" ) || linesEasyOryginalNumbers[randomNumber].Contains("x") || linesEasyOryginalNumbers[randomNumber].Contains("/");

        if (check) 
        {
            Debug.Log("[CheckIfThereASign] Wylosowany zestaw zawiera znak. Wybrane rownanie to: ");
            

            if(linesEasyOryginalNumbers[randomNumber].Contains("+"))
            {
                choseEquat = 0;
                Debug.Log("+");
                Dodawanie();
            }
            else if (linesEasyOryginalNumbers[randomNumber].Contains("-"))
            {
                choseEquat = 1;
                Debug.Log("-");

                Odejmowanie();
            }
            else if (linesEasyOryginalNumbers[randomNumber].Contains("x"))
            {
                choseEquat = 2;
                Debug.Log("x");

                Mnozenie();
            }
            else if (linesEasyOryginalNumbers[randomNumber].Contains("/"))
            {
                choseEquat = 3;
                Debug.Log("/");

                Dzielenie();
            }
          // .. methodList[choseEquat].Invoke();


        }
        else if(!check)
        {
            Debug.Log("[CheckIfThereASign] Wylosowany zestaw nie zawiera znaku. Wylosowane rownanie to: ");
            choseEquat = UnityEngine.Random.Range(0, 4);
            //  methodList[choseEquat].Invoke();
            if (choseEquat == 0)
            {
                
                Dodawanie();
            }
            else if (choseEquat == 1)
            {
               
                Odejmowanie();
            }
            else if (choseEquat == 2)
            {
                
                Mnozenie();
            }
            else if (choseEquat == 3)
            {
              
                Dzielenie();
            }

        }

    }



    private void Dodawanie()
    {

        RandomEquation = null;
        MathEquation = "Dodawanie";
        Debug.Log(MathEquation);
        do
        {           
            c = UnityEngine.Random.Range(1, maxAdditionValue + 1);
            a = UnityEngine.Random.Range(1, c);

            b = c - a;
        }
        while (!oryginalNumber.All(z => (a + "+" + b + "=" + c).Contains(z)));


       // CheckEquation();


        RandomEquation = a + "+" + b + "=" + c;

        Debug.Log("Wylosowane równanie matematyczne [DODAWANIE]: " + RandomEquation);


        WrongEquationGenerator();
        SplitInChars();


    }
    private void Odejmowanie()
    {
        RandomEquation = null;

        MathEquation = "Odejmowanie";
        Debug.Log(MathEquation);


        do
        {
            a = UnityEngine.Random.Range(1, maxSubtractionValue+1);
            c = UnityEngine.Random.Range(1, a);
            b = a - c;

        }
        while (!oryginalNumber.All(z => (a + "-" + b + "=" + c).Contains(z)));

      //  CheckEquation();

        RandomEquation = a + "-" + b + "=" + c;
        Debug.Log("Wylosowane równanie matematyczne [ODEJMOWANIE]: " + RandomEquation);



        WrongEquationGenerator();
        SplitInChars();

    }
    private void Mnozenie()
    {
        int maxAttempts = 300; // Maksymalna liczba prób generowania równania
        int attempts = 0; // Licznik prób

        bool equationContainsOriginalDigits = false;

        while (!equationContainsOriginalDigits && attempts < maxAttempts)
        {
            a = UnityEngine.Random.Range(1, 30);

            do
            {
                b = UnityEngine.Random.Range(2, 30);
            }
            while (a * b >= maxMultiplicationDivisionValue + 1);

            c = a * b;

            string equation = $"{a}x{b}={c}";

            equationContainsOriginalDigits = oryginalNumber.All(z => equation.Contains(z));

            attempts++; // Zwiêkszamy liczbê prób
        }

        Debug.Log("Liczba prob losowania: " + attempts);
       // CheckEquation();

        if (choseEquat == 2 && equationContainsOriginalDigits)
        {

            RandomEquation = a + "x" + b + "=" + c;
            MathEquation = "Mnozenie";
            Debug.Log(MathEquation);

            Debug.Log("Wylosowane równanie matematyczne [MNOZENIE]: " + RandomEquation + " || Wylosowano po " + attempts + " probach");
            WrongEquationGenerator();
            SplitInChars();

        }
        else if (choseEquat == 2 &&  !equationContainsOriginalDigits)
        {

            Debug.Log("Nie uda³o siê wygenerowaæ równania matematycznego po " + maxAttempts + " próbach.");
            RandomNumbers();
        }
        else if(choseEquat ==3 && !equationContainsOriginalDigits)
        {
            Debug.Log("Nie uda³o siê wygenerowaæ równania matematycznego po " + maxAttempts + " próbach.");

            RandomNumbers();
        }
        else if(choseEquat == 3 && equationContainsOriginalDigits)
        {
            Debug.Log(MathEquation);

            b = c;
            c = b / a;
            if (a <= b)
            {
                a = b;
                b = a / c;
            }


            RandomEquation = a + "/" + b + "=" + c;
            Debug.Log("Wylosowane równanie matematyczne [DZIELENIE]: " + RandomEquation);

            WrongEquationGenerator();
            SplitInChars();

        }



    }

    private void InvokeOtherMethod()
    {
        //Choselvl();
        RandomNumbers();
        //  if (!check)
        //  {
        //      Debug.Log("Po nieudanym losowaniu mno¿enia/dzielenia zostaje wywo³ane dodawanie/odejmowanie: ");
        //      int choseEquat2 = UnityEngine.Random.Range(0, 2);
        //      methodList[choseEquat2].Invoke();
        //  }
        //  else if(check)
        //  {
        //      Debug.Log("Po nieudanym losowaniu mno¿enia/dzielenia zostaje losowany nowy zestaw liczb do zmiany");
        //      Choselvl();
        //  }

    }

    private void Dzielenie()
    {
        RandomEquation = null;

        MathEquation = "Dzielenie";
        if(choseEquat ==3)
        {
        Mnozenie();
        }
        


    }
    private void WrongEquationGenerator()
    {
       changedEquation = RandomEquation.ToCharArray();
       ints = new int[oryginalNumber.Length];
     
       for(int i=0; i<ints.Length;i++ )
       {
           ints[i] = 99;
       }
     
     
       for (int i = 0; i< oryginalNumber.Length; i++)
       {
     
           char sign = oryginalNumber[i];
           char changedSign = changedNumber[i];
     
           for(int z = 0; z<RandomEquation.Length; z++) 
           {
               if (changedEquation[z]==sign) 
               {
                   bool containsDuplicates = CheckForDuplicates(ints, z);
     
                   if (!containsDuplicates) 
                   {
                   ints[i] = z;
                   Debug.Log("Na pozycje: " + i + " Zostala dodana liczba: " + z);
                   changedEquation[z]= changedSign;
                   break;
                   
                   }
               }
           }
       }

        ChangedRandomEquation = new string(changedEquation);
        CheckWrongEquationGenerator();
        SplitInChars();



    }
    // Metoda ta sprawdza czy cyfra nie zostala juz wczesniej zamieniona 
    private bool CheckForDuplicates(int[] array, int z)
    {

        foreach (int number in array)
        {
            if (number == z)
            {
                Debug.Log("Znaleziono powtarzaj¹c¹ siê liczbê " + number +" || " + z);
                return true;
            }
 
        }
                Debug.Log("Nie znaleziono powtarzaj¹cych siê liczby " + " || " + z);
                return false;

    }
  //  Metoda ta sprawdza czy wygenerowane zle rownanie nie jest przypadkowo prawidlowe 
   private void CheckWrongEquationGenerator()
   {
       char sign='o';
       int index = 0;
       int[] numbers = new int[3] ;
 
       for(int i=0;i<ChangedRandomEquation.Length;i++)
       {
 
           if (!char.IsDigit(ChangedRandomEquation[i]) && ChangedRandomEquation[i] != '=')
           {
               sign = ChangedRandomEquation[i];
               index=1;
           }
           else if (ChangedRandomEquation[i] == '=')
           {
               index=2;
           }
           else if(char.IsDigit(ChangedRandomEquation[i]))
           {
               int charToInt = (int)ChangedRandomEquation[i] - (int)'0'; ;
              numbers[index] = (numbers[index]*10) + charToInt;
           }
       }
 
 
 
       bool isWrong = true;
 
       if(sign== '+' && (numbers[0] + numbers[1] == numbers[2])) 
       { 
           isWrong= false;
       
       }
       else if(sign== '-' && (numbers[0] - numbers[1] == numbers[2])) 
       { 
           isWrong= false;
       
       }
       else if(sign== 'x' && (numbers[0] * numbers[1] == numbers[2])) 
       { 
           isWrong= false;
       
       }
        else if (sign == '/' && numbers[1] >= 1 && (numbers[0] / numbers[1] == numbers[2]))
        {
            isWrong = false;

        }
        else if (sign == '/' && numbers[1] < 1)
        {
            isWrong = true;

        }

        if (isWrong) 
       {
           Debug.Log("[CheckWrongEquationGenerator] Wygenerowane niewlasciwe rownanie jest niewlasciwe.");
            SplitInChars();
        }
       else if(!isWrong) 
       {
           Debug.Log("[CheckWrongEquationGenerator] Wygenerowane niewlasciwe rownanie jest wlasciwe. Zostanie wygenerowane ponownie");
           Choselvl();
       }
 
   }



   private void CheckEquation()
     {
    // string Equation = a.ToString() + b.ToString() + c.ToString();
    //
    // if(check)//zawiera znak
    // {
    //     if(Equation.Length < oryginalNumber.Length-1)
    //     {
    //          
    //          Debug.Log("[CheckEquation] Wylosowane rownanie zawiera mniej znakow niz jest liczba znakow do zmiany. Ponowne wywolanie metody.");
    //           methodList[choseEquat].Invoke();
    //      }
    //     else
    //      {
    //          Debug.Log("[CheckEquation] Wylosowane rownanie jest zgodne z liczb¹ znakow do zamiany");
    //      }
    //
    //  }
    // else if(!check) //nie zawiera znaku
    // {
    //     if (Equation.Length < oryginalNumber.Length)
    //     {
    //          methodList[choseEquat].Invoke();
    //          Debug.Log("[CheckEquation] Wylosowane rownanie zawiera mniej znakow niz jest liczba znakow do zmiany. Ponowne wywolanie metody.");
    //      }
    //      else
    //      {
    //          Debug.Log("[CheckEquation] Wylosowane rownanie jest zgodne z liczb¹ znakow do zamiany");
    //      }
    //  }
   }


    private void SplitInChars()
    {

     oryginalEquation = RandomEquation.ToCharArray();

     gameObject.GetComponent<ClonePrefab>().enabled = true;


    }


}
