//  Bet__List__Viewer.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Bet List Viewer.
/// </summary>
namespace Bet__List__Viewer
{
    // Directives
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Bet List Viewer class.
    /// </summary>
    public class Bet__List__Viewer : Form
    {
        /// <summary>
        /// The location data grid view text box column.
        /// </summary>
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;

        /// <summary>
        /// The bet data grid view text box column.
        /// </summary>
        private DataGridViewTextBoxColumn betDataGridViewTextBoxColumn;

        /// <summary>
        /// The bets data grid view.
        /// </summary>
        private DataGridView betsDataGridView;

        /// <summary>
        /// Set a bigger font for DataGrid rows
        /// </summary>
        private Font bigFont = new Font(FontFamily.GenericMonospace, 15.75F, FontStyle.Bold ^ FontStyle.Italic, GraphicsUnit.Point, (byte)0);

        /// <summary>
        /// Tracker as BindingList of BetListData (bound to DataGridView)
        /// </summary>
        private BindingList<BetListData> tracker = new BindingList<BetListData>();

        /// <summary>
        /// The marshal object.
        /// </summary>
        private object marshal = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bet__List__Viewer.Bet__List__Viewer"/> class.
        /// </summary>
        public Bet__List__Viewer()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            this.betsDataGridView = new DataGridView();
            this.betDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)this.betsDataGridView).BeginInit();
            this.SuspendLayout();

            // betsDataGridView
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.betsDataGridView.AutoSize = true;
            this.betsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.betsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.betsDataGridView.Columns.AddRange(new DataGridViewColumn[]
                {
                    this.betDataGridViewTextBoxColumn,
                    this.locationDataGridViewTextBoxColumn
                });
            this.betsDataGridView.Dock = DockStyle.Fill;
            this.betsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.betsDataGridView.Name = "betsDataGridView";
            this.betsDataGridView.RowHeadersVisible = false;
            this.betsDataGridView.Size = new System.Drawing.Size(173, 237);
            this.betsDataGridView.TabIndex = 0;

            // betDataGridViewTextBoxColumn
            this.betDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.betDataGridViewTextBoxColumn.HeaderText = "Bet";
            this.betDataGridViewTextBoxColumn.Name = "betDataGridViewTextBoxColumn";
            this.betDataGridViewTextBoxColumn.DataPropertyName = "Bet";
            this.betDataGridViewTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.betDataGridViewTextBoxColumn.DefaultCellStyle.Font = this.bigFont;

            // locationDataGridViewTextBoxColumn
            this.locationDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.locationDataGridViewTextBoxColumn.HeaderText = "Location";
            this.locationDataGridViewTextBoxColumn.Name = "cLocation";
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            this.locationDataGridViewTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.locationDataGridViewTextBoxColumn.DefaultCellStyle.Font = this.bigFont;

            // BetListViewer
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(173, 237);
            this.Controls.Add(this.betsDataGridView);
            this.Name = "BetListViewer";
            this.Text = "Bet List Viewer";
            ((System.ComponentModel.ISupportInitialize)this.betsDataGridView).EndInit();
            this.ResumeLayout(false);

            // Set DataSource
            this.betsDataGridView.DataSource = this.tracker;
        }

        /// <summary>
        /// Inits the instance.
        /// </summary>
        /// <param name="passedMarshal">Passed marshal.</param>
        public void Init(object passedMarshal)
        {
            // Set marshal
            this.marshal = passedMarshal;

            // Set icon
            this.Icon = (Icon)this.marshal.GetType().GetProperty("Icon").GetValue(this.marshal, null);

            // Show form
            this.Show();
        }

        /// <summary>
        /// Processes input.
        /// </summary>
        public void Input()
        {
            // Set last
            string lastBet = (string)this.marshal.GetType().GetProperty("Bet").GetValue(this.marshal, null);

            // Clear DataGridView's rows
            this.tracker.Clear();

            // Check if there's something to work with
            if (lastBet.Length > 0)
            {
                // Add rows
                string[] bets = lastBet.Split('|');

                // Add bets
                foreach (string bet in bets)
                {
                    // Split in parts
                    string[] betP = bet.Split('@');

                    // Add current bet
                    this.tracker.Add(new BetListData(betP[0], betP[1]));
                }
            }
        }
    }
}