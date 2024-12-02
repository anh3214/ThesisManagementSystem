using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ThesisManagement.BLL.Interfaces;
using ThesisManagement.Entities;

namespace ThesisManagementSystem.Forms
{
    public partial class RemoveLecturerForm : Form
    {
        private List<CommitteeMember> _lecturers;
        private readonly ILecturerService _lecturerService;

        public List<CommitteeMember> SelectedLecturers { get; private set; }

        public RemoveLecturerForm(ILecturerService lecturerService)
        {
            InitializeComponent();
            _lecturerService = lecturerService;
            SelectedLecturers = [];
        }
        public void SetUpLecture(List<CommitteeMember> lecturers)
        {
            _lecturers = lecturers;
        }

        private async void RemoveLecturerForm_Load(object sender, EventArgs e)
        {
            foreach (var cm in _lecturers)
            {
                var lecturer = await _lecturerService.GetLecturerById(cm.LecturerID);
                if (lecturer != null)
                {
                    lstLecturers.Items.Add(new ListBoxItem
                    {
                        LecturerID = cm.LecturerID,
                        Name = lecturer.Name,
                        Role = cm.Role
                    });
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var selectedItems = lstLecturers.SelectedItems.Cast<ListBoxItem>().ToList();
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one Lecturer to remove.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var item in selectedItems)
            {
                var cm = _lecturers.Find(l => l.LecturerID == item.LecturerID);
                if (cm != null)
                {
                    SelectedLecturers.Add(cm);
                    _lecturers.Remove(cm);
                }
            }

            // Update the ListBox
            foreach (var item in selectedItems)
            {
                lstLecturers.Items.Remove(item);
            }

            MessageBox.Show("Selected Lecturers removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper class to display items in ListBox
        private class ListBoxItem
        {
            public Guid LecturerID { get; set; }
            public string Name { get; set; }
            public RoleCommitteeMember Role { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Role})";
            }
        }
    }
}
