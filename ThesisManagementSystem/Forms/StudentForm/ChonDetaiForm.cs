// SelectThesisForm.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms.StudentForm
{
    public partial class ChonDetaiForm : Form
    {
        public Topic SelectedThesis { get; private set; }

        private readonly IEnumerable<Topic> _availableTheses;

        public ChonDetaiForm(IEnumerable<Topic> availableTheses)
        {
            InitializeComponent();
            _availableTheses = availableTheses;
            LoadTheses(_availableTheses);
        }

        private void InitializeComponent()
        {
            dgvTheses = new DataGridView();
            btnSelect = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTheses).BeginInit();
            SuspendLayout();
            // 
            // dgvTheses
            // 
            dgvTheses.AllowUserToAddRows = false;
            dgvTheses.AllowUserToDeleteRows = false;
            dgvTheses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTheses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTheses.Location = new Point(12, 12);
            dgvTheses.MultiSelect = false;
            dgvTheses.Name = "dgvTheses";
            dgvTheses.ReadOnly = true;
            dgvTheses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheses.Size = new Size(560, 300);
            dgvTheses.TabIndex = 0;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelect.Location = new Point(416, 325);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(75, 30);
            btnSelect.TabIndex = 1;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(497, 325);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SelectThesisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 367);
            Controls.Add(btnCancel);
            Controls.Add(btnSelect);
            Controls.Add(dgvTheses);
            Name = "SelectThesisForm";
            Text = "Select Thesis";
            Load += SelectThesisForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTheses).EndInit();
            ResumeLayout(false);
        }

        private void LoadTheses(IEnumerable<Topic> availableTheses)
        {
            dgvTheses.DataSource = availableTheses.Select(t => new
            {
                t.TopicID,
                t.Title,
                t.Description,
                Supervisor = t.Lecturer != null ? t.Lecturer.Name : "Not specified"
            }).ToList();

            // Hide the TopicID column if not needed
            if (dgvTheses.Columns.Contains("TopicID"))
            {
                dgvTheses.Columns["TopicID"].Visible = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvTheses.SelectedRows.Count > 0)
            {
                var selectedRow = dgvTheses.SelectedRows[0];
                var thesisId = (Guid)selectedRow.Cells["TopicID"].Value;
                var title = selectedRow.Cells["Title"].Value.ToString();
                var description = selectedRow.Cells["Description"].Value.ToString();
                var supervisor = selectedRow.Cells["Supervisor"].Value.ToString();

                // Create a Thesis object based on the selection
                SelectedThesis = new Topic
                {
                    TopicID = thesisId,
                    Title = title,
                    Description = description,
                    Lecturer = new Lecturer { Name = supervisor } // Simplified
                };

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a thesis.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private DataGridView dgvTheses;
        private Button btnSelect;
        private Button btnCancel;

        private void SelectThesisForm_Load(object sender, EventArgs e)
        {

        }
    }
}
