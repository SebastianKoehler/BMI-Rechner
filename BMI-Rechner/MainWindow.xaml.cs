using System;
using System.Windows;
using System.Windows.Controls;

namespace BMI_Rechner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TB_re_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            Eingabe_pruefen();
        }

        private void TB_li_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            Eingabe_pruefen();
        }

        private void Button_auswerten_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double bmi_wert = Eingabe_auswerten();
                string bmi = Eingabe_auswerten().ToString();
                string ergebnis = "";
                if (bmi_wert < 16.0)
                {
                    ergebnis = "Sie befinden sich im starken Untergewicht!\nBitte konsultieren Sie ihren Hausarzt!";
                }
                else if (bmi_wert < 18.5 && bmi_wert >= 16.0)
                {
                    ergebnis = "Sie befinden sich im Untergewicht!\nSie haben ein niedriges Risiko für Begleiterkrankungen!";
                }
                else if (bmi_wert >= 18.5 && bmi_wert <= 24.9)
                {
                    ergebnis = "Sie befinden sich im Normalgewicht!\nSie haben ein durchschnittliches Risiko für Begleiterkrankungen!";
                }
                else if (bmi_wert >= 25.0 && bmi_wert <= 29.9)
                {
                    ergebnis = "Sie befinden sich im Präadipositas Bereich!\nSie haben ein schwach erhöhtes Risiko für Begleiterkrankungen!";
                }
                else if (bmi_wert >= 30.0 && bmi_wert <= 34.9)
                {
                    ergebnis = "Sie befinden sich im Bereich einer moderaten Adipositas(Grad 1)!\nSie haben ein erhöhtes Risiko für Begleiterkrankungen!\nBitte konsultieren Sie ihren Hausarzt!";
                    TBL_Output.Padding = new Thickness(0, 8, 0, 0);
                }
                else if (bmi_wert >= 35.0 && bmi_wert <= 39.9)
                {
                    ergebnis = "Sie befinden sich im Bereich einer starken Adipositas(Grad 2)!\nSie haben ein hohes Risiko für Begleiterkrankungen!\nBitte konsultieren Sie ihren Hausarzt!";
                    TBL_Output.Padding = new Thickness(0, 8, 0, 0);
                }
                else if (bmi_wert >= 40.0)
                {
                    ergebnis = "Sie befinden sich im Bereich einer extremen Adipositas(Grad 3)!\nSie haben ein sehr hohes Risiko für Begleiterkrankungen!\nBitte konsultieren Sie ihren Hausarzt!";
                    TBL_Output.Padding = new Thickness(0, 8, 0, 0);
                }
                else
                {
                    TBL_Output.Text = "Etwas ist Schiefgelaufen, bitte versuche es nochmal!";
                }

                TBL_Output.Text = string.Format("Ihr BMI beträgt {0:0.0}.\n {1}", bmi, ergebnis);
            }
            catch (Exception)
            {
                TBL_Output.Text = "Falsche Eingabe!\nBitte geben Sie nur Zahlen ein!";
            }
        }

        private void Eingabe_pruefen()
        {
            Button_auswerten.IsEnabled = TB_re_Input.Text.Trim().Length != 0 && TB_li_Input.Text.Trim().Length != 0;
        }

        private double Eingabe_auswerten()
        {
            double User_Gewicht_Eingabe = Convert.ToDouble(TB_re_Input.Text);
            double User_Groesse_Eingabe = Convert.ToDouble(TB_li_Input.Text);
            double User_Groesse_m = User_Groesse_Eingabe / 100;

            double bmi_unbearbeitet = User_Gewicht_Eingabe / Math.Pow(User_Groesse_m, 2);
            double bmi = Math.Round(bmi_unbearbeitet, 1);
            return bmi;
        }
    }
}
