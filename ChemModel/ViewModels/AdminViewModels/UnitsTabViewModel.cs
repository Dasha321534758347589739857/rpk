using ChemModel.Data;
using ChemModel.Data.DbTables;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChemModel.Messeges;
using CommunityToolkit.Mvvm.Messaging;
using ChemModel.Windows;
using Microsoft.Office.Core;
using System.Windows;

namespace ChemModel.ViewModels
{
    public partial class UnitsTabViewModel : ObservableObject, IRecipient<ChangeDbMEssage>, ICloseWindow.ICloseWindows
    {
        [ObservableProperty]
        private ObservableCollection<Unit> units;
      
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddUnitCommand))]
        private string newUnit = "";
        public UnitsTabViewModel() 
        {
            using Context ctx = new Context();
            Units = new ObservableCollection<Unit>(ctx.Units.ToList());
            WeakReferenceMessenger.Default.Register<ChangeDbMEssage>(this);


        }
        [RelayCommand]
        private void AddUnits()
        {
            using Context ctx = new Context();
            AddUnitWindow add = new AddUnitWindow();
            add.ShowDialog();
            Units = new ObservableCollection<Unit>(ctx.Units.ToList());

        }
        public bool CanAdd() => !string.IsNullOrEmpty(NewUnit);
        [RelayCommand(CanExecute = nameof(CanAdd))]
        private void AddUnit(Window window)
        {
            using Context ctx = new Context();
            var unit = new Unit { Name = NewUnit };
            Units.Add(unit);
            ctx.Units.Add(unit);
            ctx.SaveChanges();
            NewUnit = "";
            
        }

        [RelayCommand]

        public void DeleteUnit(Unit unit)
        {
          
            using Context ctx = new Context();
            ctx.Units.Remove(unit!);
            ctx.SaveChanges();
            Units.Remove(unit!);
          
        }

        public void Receive(ChangeDbMEssage message)
        {
            using Context ctx = new Context();
            Units = new ObservableCollection<Unit>(ctx.Units.ToList());
        }
        public Action Close { get; set; }
        public bool CanClose()
        {
            return true;
        }
    }
}
