﻿using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;


namespace HunterPie {
    /// <summary>
    /// Interaction logic for settingsWindow.xaml
    /// </summary>
    public partial class settingsWindow : UserControl {

        private string[] AvailableBranches = new string[2] { "master", "BETA" };

        public settingsWindow()
        {
            InitializeComponent();
            PopulateBranchBox();
        }

        private void PopulateBranchBox() {
            foreach (string branch in AvailableBranches) {
                branchesCombobox.Items.Add(branch);
            }
        }

        private void TypeColor(object sender, KeyEventArgs e) {
            char[] HEX_CHARS = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            Console.WriteLine(e.Key);
            if (HEX_CHARS.Contains(e.Key.ToString()[e.Key.ToString().Length - 1])) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
            return;
        }

        private void TypeColor(object sender, TextChangedEventArgs e) {
            TextBox obj = (TextBox)sender;
            char[] HEX_CHARS = new char[17] {'#' , '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            int offset = 0;
            if (!obj.Text.StartsWith("#")) {
                obj.Text = "";
                return;
            }
            if (obj.Text.Length > 9) {
                obj.Text = obj.Text.Substring(0, 9);
                obj.CaretIndex = 10;
                return;
            }
            foreach (char character in obj.Text) {
                
                if (!HEX_CHARS.Contains(char.ToUpper(character))) {
                    break;
                } else {
                    offset++;
                }
            }
            obj.Text = obj.Text.Substring(0, offset).ToUpper();
            obj.CaretIndex = offset;
        }

        private void TypeNumber(object sender, TextChangedEventArgs e) {
            char[] NUMBERS = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            TextBox obj = (TextBox)sender;
            int offset = 0;
            foreach (char n in obj.Text) {
                if (!NUMBERS.Contains(n)) {
                    break;
                } else {
                    offset++;
                }
            }
            obj.Text = obj.Text.Substring(0, offset);
            obj.CaretIndex = offset;
        }
    }
}