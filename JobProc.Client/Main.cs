using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JobProc.BLL.DTO;
using JobProc.BLL.Interfaces;

namespace JobProc.Client
{
    public partial class Main : Form
    {
        private IJobService JobService { get; }
        public Main(IJobService jobService)
        {
            JobService = jobService;
            InitializeComponent();
            this.resetButton.Enabled = false;
            this.startButton.Enabled = false;
        }

        private void FillTimesButton_Click(object sender, EventArgs e)
        {
            int.TryParse(countImages.Text, out int dtocountImages);
            int.TryParse(countPeople.Text, out int dtocountPeople);

            DTOCountImagesAndPeopleViewModel dTOCountImagesAndPeoplesViewModel = new DTOCountImagesAndPeopleViewModel()
            {
                CountImages = dtocountImages,
                CountPeoples = dtocountPeople
            };

            string response = JobService.SaveCountImagesAndPeoples(dTOCountImagesAndPeoplesViewModel);

            if (response != "")
            {
                MessageBox.Show(response);
                return;
            }
            SetupGrid();
            this.resetButton.Enabled = true;
            this.startButton.Enabled = true;
        }

        private void SetupGrid()
        {
            fillTimesButton.Enabled = false;
            countImages.Enabled = false;
            countPeople.Enabled = false;

            dataGridTimes.AllowUserToAddRows = true;
            dataGridTimes.ColumnCount = 2;
            dataGridTimes.Columns[0].HeaderText = "Number of person";
            dataGridTimes.Columns[1].HeaderText = "Time of processing";
            dataGridTimes.AllowUserToAddRows = false;
            dataGridTimes.AllowUserToDeleteRows = false;
            dataGridTimes.Columns[1].ValueType = typeof(int);

            for (int i = 1; i <= Convert.ToInt32(countPeople.Text); i++)
            {
                dataGridTimes.Rows.Add(i, null);
            }

            dataGridTimes.Columns[0].ReadOnly = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            List<DTOPeopleTimesViewModel> dtoPeopleTimesViewModel = new List<DTOPeopleTimesViewModel>();

            foreach (DataGridViewRow item in dataGridTimes.Rows)
            {
                if (item.Cells[1].Value == null)
                {
                    MessageBox.Show("Fill all Times of processing");
                    return;
                }

                int.TryParse(item.Cells[1].Value.ToString(), out int cellValue);
                dtoPeopleTimesViewModel.Add(new DTOPeopleTimesViewModel { PeopleTime = cellValue });
            }

            string response = JobService.SaveListPeopleTimes(dtoPeopleTimesViewModel);
            if (response != "")
            {
                MessageBox.Show(response);
                return;
            }
            else
                Calculate();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            fillTimesButton.Enabled = true;
            this.startButton.Enabled = false;

            countImages.Enabled = true;
            countPeople.Enabled = true;
            dataGridTimes.Columns.Clear();
        }

        private void DataGridTimes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Only digits are required");
        }

        void Calculate()
        {
            MessageBox.Show("Calculate");
        }
    }
}
