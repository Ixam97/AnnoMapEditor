﻿using AnnoMapEditor.MapTemplates.Enums;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AnnoMapEditor.UI.Controls.IslandProperties
{
    /// <summary>
    /// Interaction logic for FixedIslandProperties.xaml 
    /// </summary>
    public partial class FixedIslandProperties : UserControl
    {
        private static readonly Dictionary<IslandType, List<IslandSize>> _allowedSizesPerType = new()
        {
            [IslandType.Normal] = new() { IslandSize.Large, IslandSize.Medium, IslandSize.Small },
            [IslandType.ThirdParty] = new() { IslandSize.Small },
            [IslandType.PirateIsland] = new() { IslandSize.Small }
        };


        private FixedIslandPropertiesViewModel _viewModel => DataContext as FixedIslandPropertiesViewModel
            ?? throw new Exception($"DataContext of {nameof(FixedIslandProperties)} must extend {nameof(FixedIslandPropertiesViewModel)}.");
        

        public FixedIslandProperties()
        {
            InitializeComponent();
        }


        private void OnRotateRandom(object sender, RoutedEventArgs args)
        {
            _viewModel.SetIslandRotationRandom();
        }

        private void OnRotateClockwise(object sender, RoutedEventArgs args)
        {
            _viewModel.RotateIsland(true);
        }

        private void OnRotateCounterClockwise(object sender, RoutedEventArgs args)
        {
            _viewModel.RotateIsland(false);
        }
    }
}
