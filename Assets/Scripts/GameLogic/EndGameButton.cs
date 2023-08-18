using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Jeœli po dwóch sekundach po naciœniêciu guzika EndGame gracz nie naciœnie go ponownie to guzik 
"Are u sure" sie wy³¹cza 

----------------------------------------------------------------------------------------------------------- */

public class EndGameButton : MonoBehaviour
{

        public Button button;
        private bool buttonClicked = false;

        public void Start()
        {
            //korutyna, która sprawdzi, czy guzik zosta³ klikniêty po dwóch sekundach
            StartCoroutine(CheckButtonClicked());
        }

        private IEnumerator CheckButtonClicked()
        {
            yield return new WaitForSeconds(2.0f);

            // Jeœli guzik nie zosta³ klikniêty po dwóch sekundach, to ukryj go
            if (!buttonClicked)
            {
                button.gameObject.SetActive(false);
            }
        }

        public void OnButtonClick()
        {
            buttonClicked = true;
            Debug.Log("Guzik zosta³ klikniêty!");
        }
}
