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

        public Command RollDieCommand { get; set; }
        public Command MinusNumDiceCommand { get; set; }
        public Command PlusNumDiceCommand { get; set; }
        private Random random = new Random();
        private int numDice = 1;
        private ObservableCollection<Rolls> rolls = new ObservableCollection<Rolls>();

        public DiceViewModel()
        {
            RollDieCommand = new Command<string>(async (x) => await RollDie(x));
            MinusNumDiceCommand = new Command(MinusNumDice);
            PlusNumDiceCommand = new Command(PlusNumDice);
        }

        private void PlusNumDice(object obj)
        {
            NumDice += 1;
        }

        private void MinusNumDice()
        {
            NumDice -= 1;
        }

        public ObservableCollection<Rolls> Rolls

        {
            get { return rolls; }
            set
            {
                rolls = value;
                OnPropertyChanged();
            }
        }
        public int NumDice
        {
            get { return numDice; }
            set
            {
                numDice = value;
                OnPropertyChanged();
            }
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

        
        async Task RollDie(string sideCountString)
        {
            try
            {
                int sideCount = Convert.ToInt32(sideCountString);
                int total = 0;
                for(int i = 0; i<numDice; i++)
                {
                    total+= random.Next(1, sideCount + 1);
                }
                LatestRoll = total;
                Rolls.Insert(0, new Rolls(sideCount, LatestRoll, numDice));
            }
            catch (FormatException e)
            {
                throw new FormatException("Input string is not a sequence of digits.", e);
            }
            catch (OverflowException e)
            {
                throw new OverflowException("The number cannot fit in an Int32.", e);
            }
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
