using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Je�li po dw�ch sekundach po naci�ni�ciu guzika EndGame gracz nie naci�nie go ponownie to guzik 
"Are u sure" sie wy��cza 

----------------------------------------------------------------------------------------------------------- */

public class EndGameButton : MonoBehaviour
{

        public Button button;
        private bool buttonClicked = false;

        public void Start()
        {
            //korutyna, kt�ra sprawdzi, czy guzik zosta� klikni�ty po dw�ch sekundach
            StartCoroutine(CheckButtonClicked());
        }

        private IEnumerator CheckButtonClicked()
        {
            yield return new WaitForSeconds(2.0f);

            // Je�li guzik nie zosta� klikni�ty po dw�ch sekundach, to ukryj go
            if (!buttonClicked)
            {
                button.gameObject.SetActive(false);
            }
        }

        public void OnButtonClick()
        {
            buttonClicked = true;
            Debug.Log("Guzik zosta� klikni�ty!");
        }
}
