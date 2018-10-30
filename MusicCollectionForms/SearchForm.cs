using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicCollectionController;
using MusicCollectionModel.Interfaces;

namespace MusicCollectionForms
{
    public partial class SearchForm : Form
    {
        private readonly IConsumerService _mConsumerService;
        private IList<IAlbum> _mSearchList;
        private readonly BindingSource _bindingSource1 = new BindingSource();
        public SearchForm()
        {
            InitializeComponent();
            Load += SearchForm_Load;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            searchDataGridView.DataSource = _bindingSource1;
        }

        public SearchForm(IConsumerService consumerService) : this()
        {
            _mConsumerService = consumerService;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            UseWaitCursor = true;

            string searchString = searchTextBox.Text;

            _mSearchList = Controller.Search(_mConsumerService, searchString);

            foreach (IAlbum a in _mSearchList)
            {
                _bindingSource1.Add(a);
            }

            UseWaitCursor = false;
        }

        public IList<IAlbum> SelectedAlbums
        {
            get
            {
                //TODO: This is all hard coded cell access. This needs to be fixed.
                List<IAlbum> selectedList = new List<IAlbum>();

                int rowNumber = 0;
                foreach (DataGridViewRow row in searchDataGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if ((bool)row.Cells[0].Value == true)
                        {
                            selectedList.Add(_bindingSource1[rowNumber] as IAlbum);
                        }
                    }
                    rowNumber++;
                }

                return selectedList;
            }
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (ActiveForm != null) ActiveForm.AcceptButton = searchButton;
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (ActiveForm != null) ActiveForm.AcceptButton = null;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
