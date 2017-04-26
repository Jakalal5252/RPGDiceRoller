using RPGDiceRoller.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RPGDiceRoller.View
{
    public partial class DiceView : ContentPage
    {

        public DiceView()
        {
            InitializeComponent();
            BindingContext = new DiceViewModel();
        }
    }
}
