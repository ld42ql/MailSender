using System.Windows;
using System.Windows.Controls;

namespace TabSwitcher
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TabSwitcherControl : UserControl
    {
        public event RoutedEventHandler BtnNextClick;
        public event RoutedEventHandler BtnPreviosClick;

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            BtnNextClick?.Invoke(sender, e);
        }
        private void BtnPrevios_Click(object sender, RoutedEventArgs e)
        {
            BtnPreviosClick?.Invoke(sender, e);
        }

        #region properties
        private bool HideBtnPrevios = false; 
        private bool HideBtnNext = false;

        public bool IsHideBtnPrevios
        {
            get => this.HideBtnPrevios;
            set
            {
                this.HideBtnPrevios = value;
                SetButtons(); 
            }
        }

        public bool IsHideBtnNext
        {
            get => this.HideBtnNext;
            set
            {
                this.HideBtnNext = value;
                SetButtons();
            }
        }

        private void BtnNextTrueBtnPreviosFalse()
        {
            btnNext.Visibility = Visibility.Hidden;
            btnPrevios.Visibility = Visibility.Visible;
            btnPrevios.Width = 229;
            btnNext.Width = 0;
            btnPrevios.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void BtnPreviosTrueBtnNextFalse()
        {
            btnPrevios.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Visible;
            btnNext.Width = 229;
            btnPrevios.Width = 0;
            btnNext.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void BtnPreviosFalseBtnNextFalse()
        {
            btnNext.Visibility = Visibility.Visible;
            btnPrevios.Visibility = Visibility.Visible;
            btnNext.Width = 115;
            btnPrevios.Width = 114;
        }

        private void BtnPreviosTrueBtnNextTrue()
        {
            btnPrevios.Visibility = Visibility.Hidden;
            btnNext.Visibility = Visibility.Hidden;
        }
        

        private void SetButtons()
        {
            if (this.HideBtnPrevios && this.HideBtnNext) BtnPreviosTrueBtnNextTrue();
            else if (!this.HideBtnNext && !this.HideBtnPrevios) BtnPreviosFalseBtnNextFalse();
            else if (this.HideBtnNext && !this.HideBtnPrevios) BtnNextTrueBtnPreviosFalse();
            else if (!this.HideBtnNext && this.HideBtnPrevios) BtnPreviosTrueBtnNextFalse();
        }
        #endregion
    }
}
