using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductPagesV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mainFlowLayoutPanel.AutoScroll = true;
            mainFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            
        }

        private void bikesButton_Click(object sender, EventArgs e)
        {
            getData("Bikes");
        }

        private void compButton_Click(object sender, EventArgs e)
        {
            getData("Components");
        }

        private void clothingButton_Click(object sender, EventArgs e)
        {
            getData("Clothing");
        }

        private void accessButton_Click(object sender, EventArgs e)
        {
            getData("Accessories");
        }

        private void getData(string catName)
        {
            mainFlowLayoutPanel.Controls.Clear();
            var SQLData = DBConnection.GetCatSpecificSQLData(catName);

            foreach (DataRow dr in SQLData.Rows)
            {
                
                var nameLabel = new Label();
                nameLabel.Text = dr["ProductName"].ToString();
                nameLabel.AutoSize = true;
                var priceLabel = new Label();
                priceLabel.Text = dr["ListPrice"].ToString();
                priceLabel.AutoSize = true;
                var descripLabel = new Label();
                descripLabel.AutoSize = true;
                descripLabel.Text = dr["Description"].ToString();
                var thumbnailPhotoPictureBox = new PictureBox();
                // FromStream = from bit stream      instantiate MemoryStream and send it Large photo in byte array format
                Image fromDB = thumbnailPhotoPictureBox.Image = Image.FromStream(new MemoryStream(dr["LargePhoto"] as byte[]));
                thumbnailPhotoPictureBox.Width = fromDB.Width;
                thumbnailPhotoPictureBox.Height = fromDB.Height;

                var itemFlowLayoutPanel = new FlowLayoutPanel();
                itemFlowLayoutPanel.BorderStyle = BorderStyle.Fixed3D;
                itemFlowLayoutPanel.BackColor = Color.Gray;
                itemFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                itemFlowLayoutPanel.Width = 300;
                itemFlowLayoutPanel.Height = 250;
                itemFlowLayoutPanel.WrapContents = true;
                itemFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowOnly;
                itemFlowLayoutPanel.Controls.Add(nameLabel);
                itemFlowLayoutPanel.Controls.Add(thumbnailPhotoPictureBox);
                itemFlowLayoutPanel.Controls.Add(priceLabel);
                itemFlowLayoutPanel.Controls.Add(descripLabel);
                mainFlowLayoutPanel.Controls.Add(itemFlowLayoutPanel);

            }
        }
    }
}
