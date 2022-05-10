using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using JobProc.BLL.DTO;
using JobProc.BLL.Interfaces;


namespace JobProc.Client
{
    public partial class Main : Form
    {
        private IJobService JobService { get; }
        private ICalculateService CalculateService { get; }

        public Main(IJobService jobService, ICalculateService calculateService)
        {
            JobService = jobService;
            CalculateService = calculateService;
            InitializeComponent();
            fastCalculation.Checked=true;
            this.resetButton.Enabled = false;
            this.startButton.Enabled = false;
        }

        private void FillTimesButton_Click(object sender, EventArgs e)
        {
            int.TryParse(countImages.Text, out int dtocountImages);
            int.TryParse(countPeople.Text, out int dtocountPeople);

            DTOCountImagesAndPeopleViewModel dTOCountImagesAndPeopleViewModel = new DTOCountImagesAndPeopleViewModel()
            {
                CountImages = dtocountImages,
                CountPeople = dtocountPeople
            };

            string response = JobService.SaveCountImagesAndPeople(dTOCountImagesAndPeopleViewModel);

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
            {
                MainGroupBox.Enabled = false;

                Calculate();
            }
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

        private void Calculate()
        {
            DTOResultViewModel result = CalculateService.Calculate(fastCalculation.Checked);

            StringBuilder message = new StringBuilder();

            DateTime timeElapsed=new DateTime(result.Ticks);

            message.AppendLine("Time elapsed " + timeElapsed.ToString("HH:mm:ss:fff") + "\n");

            for (int i = 0; i < result.PeoplesCountOfImages.Length; i++)
            {
                message.AppendLine("Person "+(i+1) + "-"  + result.PeoplesCountOfImages[i]);
            }

            MessageBox.Show(message.ToString());

            MainGroupBox.Enabled = true;
        }

    }
}
