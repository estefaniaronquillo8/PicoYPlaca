using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PicoYPlaca.Helper;

namespace PicoYPlaca
{
    public partial class Predictor : Form
    {
        private DateTimePicker timePicker;
        int borrar;

        public Predictor()
        {
            InitializeComponent();
            InitializeTimePicker();

            // Code por the Start position of the application on the screen .
            StartPosition = FormStartPosition.CenterScreen;

            // Maximum length for the input values on the TextBoxs
            txtLicenseLetters.MaxLength = 3;
            txtLicenseNumbers.MaxLength = 4;
        }

        // Manual creation of the TimePicker
        private void InitializeTimePicker()
        {
            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(242, 455);
            timePicker.Width = 100;
            timePicker.Font = new Font("Microsoft Sans Serif", 10);
            Controls.Add(timePicker);
        }

        private void btnEnterData_Click(object sender, EventArgs e)
        {
            // Use of the two FieldValidation boolean methods created on "Validation" class
            if (!txtLicenseLetters.letterFieldValidation())
            {
                MessageBox.Show("The plate letters field must be letters only and with 3 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtLicenseNumbers.numberFieldValidation())
            {
                MessageBox.Show("The plate number field must be numbers only and with 3 or 4 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Creation of a new variable to get the last digit of the License plate number
            char last_char = txtLicenseNumbers.Text[txtLicenseNumbers.Text.Length - 1];
            int flag = 0;

            // Creation of a switch for checking each day's restriction 
            switch (datePicker.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    if (last_char == '1' || last_char == '2') flag = 1;
                    break;

                case DayOfWeek.Tuesday:
                    if (last_char == '3' || last_char == '4') flag = 1;
                    break;

                case DayOfWeek.Wednesday:
                    if (last_char == '5' || last_char == '6') flag = 1;
                    break;

                case DayOfWeek.Thursday:
                    if (last_char == '7' || last_char == '8') flag = 1;
                    break;

                case DayOfWeek.Friday:
                    if (last_char == '9' || last_char == '0') flag = 1;
                    break;

                default:
                    flag = 0;
                    break;
            }

            // IF to validate the day for the restriction
            if (flag == 1) TimePickerRestriction();
            else
                MessageBox.Show("Your vehicle does not have restriction today.", "You can leave home", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Void method to validate the TimePicker restriction in case the day and last digit of the license plate number match the cases from the switch
        private void TimePickerRestriction()
        {
            int horaInicioManana = 7;
            int horaFinManana = 9;

            int minFin = 30;

            int horaInicioTarde = 16;
            int horaFinTarde = 19;

            if (timePicker.Value.Hour >= horaInicioManana && timePicker.Value.Hour < horaFinManana 
                || timePicker.Value.Hour >= horaInicioTarde && timePicker.Value.Hour < horaFinTarde
                || timePicker.Value.Hour == horaFinManana && timePicker.Value.Minute >= 0 && timePicker.Value.Minute <= minFin
                || timePicker.Value.Hour == horaFinTarde && timePicker.Value.Minute >= 0 && timePicker.Value.Minute <= minFin)
            {
                MessageBox.Show("Your vehicle cannot go out because the time is: " + timePicker.Value.TimeOfDay.ToString(), "Stay Home", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Your vehicle can go out as the time is: " + timePicker.Value.TimeOfDay.ToString(), "You can leave home", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
