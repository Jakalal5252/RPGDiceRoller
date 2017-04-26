using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.ComponentModel;
using RPGDiceRoller.Model;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace RPGDiceRoller.ViewModel
{
    public class DiceViewModel : INotifyPropertyChanged
    {
        public Command RollD4Command { get; set; }
        public Command RollD6Command { get; set; }
        public Command RollD8Command { get; set; }
        public Command RollD10Command { get; set; }
        public Command RollD12Command { get; set; }
        public Command RollD20Command { get; set; }
        public Command RollD100Command { get; set; }
        private ObservableCollection<Rolls> rolls = new ObservableCollection<Model.Rolls>();
        public ObservableCollection<Rolls> Rolls

        {
            get { return rolls; }
            set
            {
                rolls = value;
                OnPropertyChanged();
            }
        }
        Random random = new Random();

        public DiceViewModel()
        {
            RollD4Command = new Command(async () => await RollD4());
            RollD6Command = new Command(async () => await RollD6());
            RollD8Command = new Command(async () => await RollD8());
            RollD10Command = new Command(async () => await RollD10());
            RollD12Command = new Command(async () => await RollD12());
            RollD20Command = new Command(async () => await RollD20());
            RollD100Command = new Command(async () => await RollD100());
        }

        int latestRoll;
        public int LatestRoll
        {
            get { return latestRoll; }
            set
            {
                latestRoll = value;
                OnPropertyChanged();
            }
        }

        


        async Task RollD4()
        {
            LatestRoll = random.Next(1, 5);
            Rolls.Insert(0,new Rolls(4, LatestRoll));
        }
        async Task RollD6()
        {
            LatestRoll = random.Next(1, 7);
            Rolls.Insert(0, new Rolls(6, LatestRoll));
        }
        async Task RollD8()
        {
            LatestRoll = random.Next(1, 9);
            Rolls.Insert(0, new Rolls(8, LatestRoll));
        }
        async Task RollD10()
        {
            LatestRoll = random.Next(1, 11);
            Rolls.Insert(0, new Rolls(10, LatestRoll));
        }
        async Task RollD12()
        {
            LatestRoll = random.Next(1, 13);
            Rolls.Insert(0, new Rolls(12, LatestRoll));
        }
        async Task RollD20()
        {
            LatestRoll = random.Next(1, 21);
            Rolls.Insert(0, new Rolls(20, LatestRoll));
        }
        async Task RollD100()
        {
            LatestRoll = random.Next(1, 101);
            Rolls.Insert(0, new Rolls(100, LatestRoll));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var changed = PropertyChanged;

            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
