using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicCollectionController;
using MusicCollectionModel;

namespace MusicCollectionForms
{
    public partial class TestForm : Form
    {
        private static readonly String TEST_LIBRARY_NAME = "TEST_LIBRARY";
        public TestForm()
        {
            InitializeComponent();
            InitializeData();
        }

        protected void InitializeData()
        {
            AlbumLibrary albumLibrary = Controller.ReadLibrary(TEST_LIBRARY_NAME);
            musicLibraryLabel.Text = albumLibrary.LibraryName;

            foreach (Album a in albumLibrary.Albums)
            {
                musicCollectionGridView.Rows.Add(new object[] {a.Name, a.Artist, a.Year.ToString(), a.PlayCount.ToString(), a.Url});
            }
        }
    }
}
