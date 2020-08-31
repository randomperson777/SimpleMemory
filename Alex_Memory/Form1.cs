using System;
using System.Drawing;
using System.Windows.Forms;

namespace Alex_Memory
{
    public partial class Form1 : Form
    {





        public Form1()
        {
            InitializeComponent();
            StartGame();
        }

        private const string V = "";
        int[] buttonValues = new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        int? currentNumber;
        int score;
        int clickcounter = 0;
        //bool hasRevealedOnce = false;
        Button lastPickedButton; // = null;
        Button lastPickedButton2;// = null;
        private void StartGame()
        {//initializes the game, cleans used variables to allow for replayability
            ClearClickMemory();
            CleanButtons();
            textBox1.Text = "";
            score = 0; button18.Text = score.ToString();
            currentNumber = null;
            buttonValues = ShuffleArray(buttonValues);
            //MessageBox.Show(buttonValues[0].ToString());
        }

        public void PickNumber(Button BButton, int buttonSlot)
        {//retrieves the number associated to the array slot associated to the button clicked
            ToggleCurrentButtonVisibility(BButton, buttonSlot);
            Button localB = lastPickedButton;
            Button localC = lastPickedButton2;
            if (currentNumber == null)
            {
                currentNumber = buttonValues[buttonSlot];
                textBox1.Text = "You have picked " + BButton.Name + ".";
                //ben
                // clickcounter = 1;
            }
            else if (currentNumber == buttonValues[buttonSlot] & score >= 8)
            {
                textBox1.Text = "Congratulations, you have won this game of Memory!";
                score = 0;

                //ben
                //clickcounter = 2;
                StartGame();
                return;
            }
            else if (currentNumber == buttonValues[buttonSlot])
            {
                score++;
                textBox1.Text = "Congratulations, you have done it! Now try again.";
                currentNumber = null;
                button18.Text = score.ToString();
                lastPickedButton.Visible = false;
                lastPickedButton2.Visible = false;
                //ben
                //clickcounter = 0;
                // lastPickedButton.Visible = false;
                // lastPickedButton2.Visible = false;

            }
            else if (currentNumber != null)
            {
                System.Media.SystemSounds.Exclamation.Play();
                currentNumber = null;
                // clickcounter = 0;
                textBox1.Text = "Not quite right. Try again.";
                //  System.Threading.Thread.Sleep(2000);

            }
            ClickMemory(BButton);
        }

        private void ToggleCurrentButtonVisibility(Button BButton, int buttonSlot)
        { //copies number from button-associated array slot to button.Text
            Button localB = BButton;
            if (localB.Text == V)
            {
                localB.Text = buttonValues[buttonSlot].ToString();
                localB.BackColor = Color.LightBlue;
            }
        }

        private void ClickMemory(object sender)
        {//"wipes the table" every 2 clicks in order to maintain sanity
            if (clickcounter == 0)
            {
                lastPickedButton = (Button)sender;
                clickcounter++;
                return;
            }
            else if (clickcounter == 1)
            {
                lastPickedButton2 = (Button)sender;
                clickcounter++;

                return;
            }
            else if (clickcounter == 2)
            {
                Button localB = lastPickedButton;
                Button localC = lastPickedButton2;

                clickcounter = 0;
                CleanButtons();
                ClearClickMemory();
            }

            /*
              if (lastPickedButton == null)
            {
                lastPickedButton = (Button)sender;
                return;
            }
            else if (lastPickedButton2 == null)
            {
                lastPickedButton2 = (Button)sender;
             

                return;
            }
            else if (lastPickedButton != null && lastPickedButton2 != null)
            {
                //Button localB = lastPickedButton;
                //Button localC = lastPickedButton2;
                CleanButtons();
                ClearClickMemory();
            } 
             */


        }
        private void ClearClickMemory()
        { //clears click memory

            clickcounter = 0;
            // CleanButtons();


            //ben
            //lastPickedButton = null;
            //lastPickedButton2 = null;
        }

        private void CleanButtons()
        { //clears ALL buttons and colors
            button1.Text = V;
            button2.Text = V;
            button3.Text = V;
            button4.Text = V;
            button5.Text = V;
            button6.Text = V;
            button7.Text = V;
            button8.Text = V;
            button10.Text = V;
            button11.Text = V;
            button12.Text = V;
            button13.Text = V;
            button14.Text = V;
            button15.Text = V;
            button16.Text = V;
            button17.Text = V;
            //colors
            button1.BackColor = SystemColors.Control;
            button2.BackColor = SystemColors.Control;
            button3.BackColor = SystemColors.Control;
            button4.BackColor = SystemColors.Control;
            button5.BackColor = SystemColors.Control;
            button6.BackColor = SystemColors.Control;
            button7.BackColor = SystemColors.Control;
            button8.BackColor = SystemColors.Control;
            button10.BackColor = SystemColors.Control;
            button11.BackColor = SystemColors.Control;
            button12.BackColor = SystemColors.Control;
            button13.BackColor = SystemColors.Control;
            button14.BackColor = SystemColors.Control;
            button15.BackColor = SystemColors.Control;
            button16.BackColor = SystemColors.Control;
            button17.BackColor = SystemColors.Control;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //start game, has debug for strings
            StartGame();
            string debug = V;
            for (int i = 0; i < 16; i++)
            {
                debug += buttonValues[i].ToString();
            }
            MessageBox.Show(debug);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 0);
            //ToggleCurrentButtonVisibility(localB2, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 1);
            //ToggleCurrentButtonVisibility(localB2, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 2);
            //ToggleCurrentButtonVisibility(localB2, 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 3);
            //ToggleCurrentButtonVisibility(localB2, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 4);
            //ToggleCurrentButtonVisibility(localB2, 5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 5);
            //ToggleCurrentButtonVisibility(localB2, 6);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 6);
            //ToggleCurrentButtonVisibility(localB2, 7);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 7);
            //ToggleCurrentButtonVisibility(localB2, 8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 8);
            //ToggleCurrentButtonVisibility(localB2, 9);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 9);
            //ToggleCurrentButtonVisibility(localB2, 10);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 10);
            //ToggleCurrentButtonVisibility(localB2, 11);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 11);
            //ToggleCurrentButtonVisibility(localB2, 12);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 12);
            //ToggleCurrentButtonVisibility(localB2, 13);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 13);
            //ToggleCurrentButtonVisibility(localB2, 14);
        }

        private void button16_Click(object sender, EventArgs e)
        {

            Button localB2 = (Button)sender;
            PickNumber(localB2, 14);
            //ToggleCurrentButtonVisibility(localB2, 15);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button localB2 = (Button)sender;
            PickNumber(localB2, 15);
            //ToggleCurrentButtonVisibility(localB2, 16);
        }

        int[] ShuffleArray(int[] array)
        {
            Random r = new Random();
            for (int i = array.Length; i > 0; i--)
            {
                int j = r.Next(i);
                int k = array[j];
                array[j] = array[i - 1];
                array[i - 1] = k;
            }
            return array;
        }
    }
}
