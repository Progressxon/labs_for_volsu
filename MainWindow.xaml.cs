using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using Newtonsoft.Json;
using Практика.Models;

namespace MilitaryApp
{
    public partial class MainWindow : Window
    {
        public List<Soldier> Soldiers { get; set; }
        public Soldier SelectedSoldier { get; set; }
        public List<MilitaryUnit> MilitaryUnits { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadJsonData();
        }

        private void LoadJsonData()
        {
            string jsonFileName = @"C:\Users\Zver\Desktop\чет для учебы\лабы\Практика\var6.json";
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFileName);

            if (File.Exists(jsonFilePath))
            {
                try
                {
                    string jsonData = File.ReadAllText(jsonFilePath);
                    var root = JsonConvert.DeserializeObject<Root>(jsonData);
                    Soldiers = root.Военнослужащие;
                    MilitaryUnits = root.ВоеннаяЧасть;
                    DataContext = this;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show($"Файл {jsonFilePath} не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnInfoButtonClick(object sender, RoutedEventArgs e)
        {
            if (SelectedSoldier != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"ФИО: {SelectedSoldier.ФИО}");
                sb.AppendLine($"Звание: {SelectedSoldier.Звание}");

                if (SelectedSoldier.ВоеннаяЧасть >= 0 && SelectedSoldier.ВоеннаяЧасть < MilitaryUnits.Count)
                {
                    var militaryUnit = MilitaryUnits[SelectedSoldier.ВоеннаяЧасть];
                    sb.AppendLine($"Военная часть: {militaryUnit.Название} ({militaryUnit.СубъектРФ})");
                }

                sb.AppendLine("Специализации:");
                foreach (var spec in SelectedSoldier.Специализации)
                {
                    sb.AppendLine($"- {spec}");
                }

                MessageBox.Show(sb.ToString(), "Информация о военнослужащем");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите военного", "Ошибка");
            }
        }

        private void OnShowMilitaryUnitsButtonClick(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var unit in MilitaryUnits)
            {
                sb.AppendLine($"Название: {unit.Название}, Субъект: {unit.СубъектРФ}");
            }

            MessageBox.Show(sb.ToString(), "Список военных частей");
        }
    }
}
