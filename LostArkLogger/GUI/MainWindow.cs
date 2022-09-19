using AccessoryOptimizerLib.Models;
using AccessoryOptimizerLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static AccessoryOptimizerLib.Services.PermutationService;

namespace LostArkLogger
{
    public partial class MainWindow : Form, INotifyPropertyChanged
    {
        private PermutationService _permutationService;

        Parser sniffer;
        Overlay overlay;
        private int _packetCount;
        private int _auctionPacketCount;

        public event PropertyChangedEventHandler PropertyChanged;

        public string PacketCount
        {
            get { return "Logged Packets: " + _packetCount; }
        }

        public string AuctionPacketCount
        {
            get { return "Logged Auction Packets: " + _auctionPacketCount; }
        }

        public MainWindow()
        {
            InitializeComponent();
            var version = typeof(MainWindow).Assembly.GetName().Version;
            versionLabel.Text = $"Version {version.Major}.{version.Minor}.{version.Build}";
            Oodle.Init();
            if (!Directory.Exists("logs")) Directory.CreateDirectory("logs");
            sniffer = new Parser();
            sniffer.onPacketTotalCount += (int totalPacketCount) =>
            {
                _packetCount = totalPacketCount;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PacketCount)));
            };

            sniffer.onAuctionPacketTotalCount += (int totalAuctionPacketCount) =>
             {
                 _auctionPacketCount = totalAuctionPacketCount;
                 PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuctionPacketCount)));
             };

            loggedPacketCountLabel.Text = "Logged Packets: 0";
            loggedPacketCountLabel.DataBindings.Add("Text", this, nameof(PacketCount));

            loggedAuctionPacketCountLabel.Text = "Logged Auction Packets: 0";
            loggedAuctionPacketCountLabel.DataBindings.Add("Text", this, nameof(AuctionPacketCount));

            overlay = new Overlay();
            overlay.AddSniffer(sniffer);
            // overlay.Show();

            _permutationService = new PermutationService();
            InitializeOptions();
        }

        #region Other Stuff
        private void sniffModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            this.sniffModeCheckbox.Enabled = false;
            this.sniffer.use_npcap = sniffModeCheckbox.Checked;
            this.sniffer.InstallListener();
            // This will unset the checkbox if it fails to initialize
            this.sniffModeCheckbox.Checked = this.sniffer.use_npcap;
            this.sniffModeCheckbox.Enabled = true;
            Properties.Settings.Default.Npcap = sniffModeCheckbox.Checked;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region My Stuff
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearAccessories();
            UpdateCountText();
        }

        private void processButton_Click(object sender, EventArgs e)
        {
            message_Label.Text = "Processing now!";
            string message = string.Empty;
            List<DesiredEngravings> allDesiredEngravings = GetOverallDesiredEngravings().Where(des => des.Engravings.All(de => de.Amount > 0)).ToList();

            if (string.IsNullOrEmpty(desiredStatType1.SelectedItem.ToString()))
            {
                message = "Desired stat type 1 needs to be set";
            }
            else
            {
                PSO.DesiredStatType1 = (Stat_Type?)Enum.Parse(typeof(Stat_Type), desiredStatType1.SelectedItem.ToString());
            }

            if (string.IsNullOrEmpty(desiredStatType2.SelectedItem.ToString()))
            {
                message = "Desired stat type 2 needs to be set";
            }
            else
            {
                PSO.DesiredStatType2 = (Stat_Type?)Enum.Parse(typeof(Stat_Type), desiredStatType2.SelectedItem.ToString());
            }

            if (!string.IsNullOrEmpty(message))
            {
                message_Label.Text = message;
                return;
            }

            _permutationService._necklaces = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Necklace).ToList();
            _permutationService._earrings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Earring).ToList();
            _permutationService._rings = PSO.CurrentAccessories.Where(a => a.AccessoryType == AccessoryType.Ring).ToList();

            if (PSO.DesiredStatType1 != null && PSO.DesiredStatType2 != null)
            {
                _permutationService._necklaces = _permutationService._necklaces.Where(n => (n.Stats.StatType1 == PSO.DesiredStatType1 && n.Stats.StatType2 == PSO.DesiredStatType2) || (n.Stats.StatType1 == PSO.DesiredStatType2 && n.Stats.StatType2 == PSO.DesiredStatType1)).ToList();
            }

            (int numberOfPermutations, List<PermutationDisplay> permutationDisplays) = _permutationService.Process(allDesiredEngravings, int.Parse(minCost.Text), int.Parse(maxCost.Text), reuse_checkBox.Checked, filterWorryingNeg_checkBox.Checked, filterZeroNegEngraving_checkBox.Checked);

            if (!string.IsNullOrEmpty(atkPowMax.Text))
            {
                permutationDisplays = permutationDisplays.Where(pd => pd.NegativeSummary.AmountOfAtkPower <= int.Parse(atkPowMax.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(atkSpdMax.Text))
            {
                permutationDisplays = permutationDisplays.Where(pd => pd.NegativeSummary.AmountOfAtkSpeed <= int.Parse(atkSpdMax.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(moveSpdMax.Text))
            {
                permutationDisplays = permutationDisplays.Where(pd => pd.NegativeSummary.AmountOfMoveSpeed <= int.Parse(moveSpdMax.Text)).ToList();
            }

            if (!string.IsNullOrEmpty(defMax.Text))
            {
                permutationDisplays = permutationDisplays.Where(pd => pd.NegativeSummary.AmountOfDefenceReduction <= int.Parse(defMax.Text)).ToList();
            }

            message_Label.Text = $"Matching any engraving profile results = {numberOfPermutations}      Negative engraving filter results = {permutationDisplays.Count}";


            if (MinimumStatHasValue(min_stat1, out int amount1))
            {
                permutationDisplays = FilterByMinStat(permutationDisplays, (Stat_Type)PSO.DesiredStatType1, amount1);
            }

            if (MinimumStatHasValue(min_stat2, out int amount2))
            {
                permutationDisplays = FilterByMinStat(permutationDisplays, (Stat_Type)PSO.DesiredStatType2, amount2);
            }

            message_Label.Text += $"      Minimum Stat filter results = {permutationDisplays.Count}";

            var cheap = permutationDisplays
                .OrderBy(p => p.Cost)
                .Take(100)
                .ToList();

            cheapest_Textbox.Text = GetStringOutputOfResults(cheap);

            cheapest500HighStat1_textBox.Text = GetStringOutputOfResults(permutationDisplays
                .OrderBy(p => p.Cost)
                .Take(500)
                .OrderBy(p => PSO.DesiredStatType1 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType1 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue))
                .Reverse()
                .Take(5)
                .ToList());

            cheapest500HighStat2_textBox.Text = GetStringOutputOfResults(permutationDisplays
                .OrderBy(p => p.Cost)
                .Take(500)
                .OrderBy(p => PSO.DesiredStatType2 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType2 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue))
                .Reverse()
                .Take(5)
                .ToList());

            cheapest80Q_textBox.Text = GetStringOutputOfResults(permutationDisplays
                .Where(p => p.AverageQuality >= 80)
                .OrderBy(p => p.Cost)
                .Take(5)
                .ToList());

            cheapest90Q_textBox.Text = GetStringOutputOfResults(permutationDisplays
                .Where(p => p.AverageQuality >= 90)
                .OrderBy(p => p.Cost)
                .Take(5)
                .ToList());

            cheapest95Q_textBox.Text = GetStringOutputOfResults(permutationDisplays
                .Where(p => p.AverageQuality >= 95)
                .OrderBy(p => p.Cost)
                .Take(5)
                .ToList());

            cheapestWithRelicNeck_textBox.Text = GetStringOutputOfResults(permutationDisplays
                .Where(p => p.Necklace.AccessoryRank == AccessoryRank.Relic)
                .OrderBy(p => p.Cost)
                .Take(5)
                .ToList());

            var highestStat1 = permutationDisplays
                .OrderBy(p => PSO.DesiredStatType1 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType1 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue));
                

            highestStat1_textBox.Text = GetStringOutputOfResults(highestStat1
                .Reverse()
                .Take(5)
                .ToList());

            var highestStat2 = permutationDisplays
                .OrderBy(p => PSO.DesiredStatType2 == Stat_Type.Crit ? p.StatsValue.CritValue : (PSO.DesiredStatType2 == Stat_Type.Specialization ? p.StatsValue.SpecValue : p.StatsValue.SwiftValue));

            highestStat2_textBox.Text = GetStringOutputOfResults(highestStat2
                .Reverse()
                .Take(5)
                .ToList());


            stat1CostChart.Series.Clear();
            stat2CostChart.Series.Clear();

            var highestStatCost1Series = new Series
            {
                Name = "HighestStatCost1",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Point,
            };

            var highestStatCost2Series = new Series
            {
                Name = "HighestStatCost2",
                Color = System.Drawing.Color.Red,
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Point,
            };

            stat1CostChart.Series.Add(highestStatCost1Series);
            stat2CostChart.Series.Add(highestStatCost2Series);
            
            stat1CostChart.ChartAreas[0].AxisX.Title = PSO.DesiredStatType1.ToString();
            stat1CostChart.ChartAreas[0].AxisY.Title = "Cost";

            stat2CostChart.ChartAreas[0].AxisX.Title = PSO.DesiredStatType2.ToString();
            stat2CostChart.ChartAreas[0].AxisY.Title = "Cost";

            foreach (var highestStatPermutation in highestStat1.GroupBy(hs => (hs.StatsValue.GetStatValue((Stat_Type)PSO.DesiredStatType1), hs.Cost)).Select(g => g.First()))
            {
                highestStatCost1Series.Points.AddXY(highestStatPermutation.StatsValue.GetStatValue((Stat_Type)PSO.DesiredStatType1), highestStatPermutation.Cost);
            }

            foreach (var highestStatPermutation in highestStat2.GroupBy(hs => (hs.StatsValue.GetStatValue((Stat_Type)PSO.DesiredStatType1), hs.Cost)).Select(g => g.First()))
            {
                highestStatCost2Series.Points.AddXY(highestStatPermutation.StatsValue.GetStatValue((Stat_Type)PSO.DesiredStatType2), highestStatPermutation.Cost);
            }
        }

        private List<PermutationDisplay> FilterByMinStat(List<PermutationDisplay> permutationDisplays, Stat_Type statType, int minAmount)
        {
            switch (statType)
            {
                case Stat_Type.Crit:
                    return permutationDisplays.Where(p => p.StatsValue.CritValue >= minAmount).ToList();
                case Stat_Type.Specialization:
                    return permutationDisplays.Where(p => p.StatsValue.SpecValue >= minAmount).ToList();
                case Stat_Type.Swiftness:
                    return permutationDisplays.Where(p => p.StatsValue.SwiftValue >= minAmount).ToList();
            }

            return permutationDisplays;
        }

        private bool MinimumStatHasValue(TextBox textBox, out int amount)
        {
            amount = 0;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                return false;
            }

            if (!int.TryParse(textBox.Text, out int result))
            {
                return false;
            }

            if (result > 0)
            {
                amount = result;
                return true;
            }

            return false;
        }

        private void InitializeOptions()
        {
            engraving1Choice.DataSource = GetChoices<EngravingType>();
            engraving2Choice.DataSource = GetChoices<EngravingType>();
            engraving3Choice.DataSource = GetChoices<EngravingType>();
            engraving4Choice.DataSource = GetChoices<EngravingType>();
            engraving5Choice.DataSource = GetChoices<EngravingType>();
            engraving6Choice.DataSource = GetChoices<EngravingType>();

            desiredStatType1.DataSource = GetChoices<Stat_Type>().Where(stc => stc != Stat_Type.Unset.ToString()).ToArray();
            desiredStatType2.DataSource = GetChoices<Stat_Type>().Where(stc => stc != Stat_Type.Unset.ToString()).ToArray();
        }

        private void manualNegativeEngravingInputsCheckBox_CheckedChanged(Object sender, EventArgs e)
        {
            if (manualNegativeEngravingInputsCheckBox.Checked)
            {
                filterWorryingNeg_checkBox.Checked = false;
                filterWorryingNeg_checkBox.Enabled = false;
                filterZeroNegEngraving_checkBox.Checked = false;
                filterZeroNegEngraving_checkBox.Enabled = false;
                maxNegEngValuesPanel.Visible = true;
                atkPowMax.Text = "0";
                atkSpdMax.Text = "0";
                moveSpdMax.Text = "0";
                defMax.Text = "0";
            }
            else
            {
                filterWorryingNeg_checkBox.Checked = true;
                filterWorryingNeg_checkBox.Enabled = true;
                filterZeroNegEngraving_checkBox.Checked = true;
                filterZeroNegEngraving_checkBox.Enabled = true;
                maxNegEngValuesPanel.Visible = false;
                atkPowMax.Text = string.Empty;
                atkSpdMax.Text = string.Empty;
                moveSpdMax.Text = string.Empty;
                defMax.Text = string.Empty;
            }
        }

        private string[] GetChoices<T>()
        {
            string[] choices = new[] { string.Empty };
            choices = choices.Concat(Enum.GetNames(typeof(T))).OrderBy(c => c).ToArray();
            return choices;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateCountText();
        }

        public void UpdateCountText()
        {
            accessoryCount.Text = PSO.CurrentAccessories.Count.ToString();
            earringCount.Text = PSO.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Earring).Count().ToString();
            ringCount.Text = PSO.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Ring).Count().ToString();
            necklaceCount.Text = PSO.CurrentAccessories.Where(ca => ca.AccessoryType == AccessoryType.Necklace).Count().ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StoreAccessories();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            LoadAccessories();
            UpdateCountText();
        }

        private List<DesiredEngravings> GetOverallDesiredEngravings()
        {
            List<DesiredEngravings> overallDesiredEngravings = new List<DesiredEngravings>();

            for (int i = 1; i < 7; i++)
            {
                overallDesiredEngravings.Add(GetDesiredEngravings(i));
            }

            return overallDesiredEngravings;
        }

        private DesiredEngravings GetDesiredEngravings(int columnIndex)
        {
            DesiredEngravings desiredEngravings = new DesiredEngravings();

            for (int i = 1; i < 7; i++)
            {
                AddEngravingIfSet(desiredEngravings.Engravings, Controls[$"engraving{i}Choice"] as ComboBox, Controls[$"engraving{i}Quantity_{columnIndex}"] as TextBox);
            }

            return desiredEngravings;
        }

        private string GetStringOutputOfResults(List<PermutationDisplay> permutations)
        {
            StringBuilder overallString = new StringBuilder();

            foreach (PermutationDisplay p in permutations)
            {
                overallString.AppendLine("------------------------------------------------------");

                overallString.AppendLine("\n");
                overallString.AppendLine($"Cost: {p.Cost}       AverageQuality: {p.AverageQuality}       Cost per Quality: {p.Cost / p.AverageQuality}");
                overallString.AppendLine($"Crit: {p.StatsValue.CritValue}       Swiftness: {p.StatsValue.SwiftValue}           Specialization: {p.StatsValue.SpecValue}");
                overallString.AppendLine($"Atk Pow: -{p.NegativeSummary.AmountOfAtkPower}       Atk Spd: -{p.NegativeSummary.AmountOfAtkSpeed}       Mov: -{p.NegativeSummary.AmountOfMoveSpeed}       Def: -{p.NegativeSummary.AmountOfDefenceReduction}");
                overallString.AppendLine("\n");

                foreach (var a in p.GetAccessories())
                {
                    string output = string.Format("{0,-30} {1,-60} {2,-60} {3,-60} {4,-15} {5,-15}", $"{a.AccessoryType} {a.Quality}", $"{a.Engravings[0].EngravingType} ({a.Engravings[0].EngravingValue})", $"{a.Engravings[1].EngravingType}({a.Engravings[1].EngravingValue})", $"{a.NegativeEngraving.EngravingType} ({a.NegativeEngraving.EngravingValue})", $"Bid: {a.MinimumBid}", $"Cost: {a.BuyNowPrice}");
                    overallString.AppendLine(output);
                }

                overallString.AppendLine("\n");
            }

            return overallString.ToString();
        }

        private static void AddEngravingIfSet(List<DesiredEngraving> desiredEngravings, ComboBox choiceComboBox, TextBox quantityTextBox)
        {
            if (choiceComboBox == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(choiceComboBox.Text))
            {
                if (!string.IsNullOrEmpty(quantityTextBox.Text))
                {
                    desiredEngravings.Add(new DesiredEngraving(int.Parse(quantityTextBox.Text), (EngravingType)Enum.Parse(typeof(EngravingType), choiceComboBox.Text)));
                }
            }
        }

        private void saveLastEngravingsButton_Click(object sender, EventArgs e)
        {
            List<DesiredEngravings> allDesiredEngravings = GetOverallDesiredEngravings();

            string json = JsonSerializer.Serialize(allDesiredEngravings, new JsonSerializerOptions() { IncludeFields = true });
            File.WriteAllText(@".\savedEngravings.json", json);
        }

        private void loadLastEngravingsButton_Click(object sender, EventArgs e)
        {
            try
            {
                string json = File.ReadAllText(@".\savedEngravings.json");
                if (string.IsNullOrEmpty(json))
                {
                    return;
                }
                else
                {
                    List<DesiredEngravings> allDesiredEngravings = JsonSerializer.Deserialize<List<DesiredEngravings>>(json);

                    foreach (var (desiredEngravings, k) in allDesiredEngravings.Select((value, k) => (value, k)))
                    {
                        foreach (var (desiredEngraving, j) in desiredEngravings.Engravings.Select((value, j) => (value, j)))
                        {
                            ComboBox comboBox = ((ComboBox)Controls[$"engraving{j + 1}Choice"]);
                            comboBox.SelectedIndex = comboBox.FindString(desiredEngraving.EngravingType.ToString());
                            Controls[$"engraving{j + 1}Quantity_{k + 1}"].Text = desiredEngraving.Amount.ToString();
                        }
                    }

                }
            }
            catch
            {


            }
        }

        private void ClearAccessories()
        {
            PSO.CurrentAccessories = new List<Accessory>();
        }

        private void StoreAccessories()
        {
            string json = JsonSerializer.Serialize(PSO.CurrentAccessories, new JsonSerializerOptions() { IncludeFields = true });
            File.WriteAllText(@".\data.json", json);
        }

        private bool LoadAccessories()
        {
            try
            {
                string json = File.ReadAllText(@".\data.json");
                if (string.IsNullOrEmpty(json))
                {
                    return false;
                }
                else
                {
                    PSO.CurrentAccessories = JsonSerializer.Deserialize<List<Accessory>>(json);
                    return PSO.CurrentAccessories?.Count() > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
