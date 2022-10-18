using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visor_Multimedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            { Multiselect = true, ValidateNames = true,
                Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv"
            })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> file = new List<MediaFile>();
                    foreach(string FileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(FileName);
                        file.Add(new MediaFile() { FileName =
                            Path.GetFileNameWithoutExtension(fi.FullName),
                        Path = fi.FullName });
                    }
                    listArchivo.DataSource = file;
                }
            }
        }

        private void listArchivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listArchivo.SelectedItem as MediaFile;
            if(file != null)
            {
                axMediaPlayer.URL = file.Path;
                axMediaPlayer.Ctlcontrols.play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listArchivo.ValueMember = "Path";
            listArchivo.DisplayMember = "FileName";
        }
    }
}
